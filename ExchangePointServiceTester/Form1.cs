using Exchange.ClientLib;
using Exchange.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ExchangePointServiceTester
{
    public partial class Form1 : Form
    {
        private string _loadingImage = Environment.CurrentDirectory + @"\loading.gif";
        private string _tempFileName = "";
        private StringBuilder _pubSubLog = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSection clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;

            ChannelEndpointElementCollection endpointCollection = clientSection.ElementInformation.Properties[string.Empty].Value as ChannelEndpointElementCollection;
            List<string> endpointNames = new List<string>();
            foreach (ChannelEndpointElement endpointElement in endpointCollection)
            {
                if (endpointElement.Address.AbsolutePath.ToLower().Contains("pubsubservice.svc"))
                {
                    txtPubSubURI.Text = endpointElement.Address.AbsoluteUri;
                    txtPubSubURI.Enabled = false;
                    break;
                }
            }

            txtURL.Text = ConfigurationManager.AppSettings["EPSURL"].ToString();

            txtUser.Text = ConfigurationManager.AppSettings["UserName"].ToString();
            txtPassword.Text = ConfigurationManager.AppSettings["Password"].ToString();

            this.Text = "FriendlyDBName = " + System.Configuration.ConfigurationManager.AppSettings["FriendlyName"];
            txtFDBN.Text = System.Configuration.ConfigurationManager.AppSettings["FriendlyName"];

            LoadMessageTypes();
        }

        private SubscriptionServiceManager m_SubMgr = null;

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                var dynamicMessage = ((Type)cbMessages.SelectedValue).Assembly.CreateInstance(cbMessages.SelectedValue.ToString()) as Exchange.Contracts.Message;
                Subscription sub; 

                m_SubMgr = new SubscriptionServiceManager();
                //m_SubMgr.SubscriptionServiceCallbackEvent += new SubscriptionServiceCallBackEventHander(exchangeSubscriptionClient_SubscriptionServiceCallbackEvent);
                m_SubMgr.SubscriptionServiceCallbackEvent += (s, msg) => 
                {
                    string msgText;
                    msgText = "Callback>>. " + "(" + msg.message.RequestID + ") Message: " + msg.message.RequestName;

                    if (msg.message is StatusMessage)
                    {
                        msgText += " - Status: " + (msg.message as StatusMessage).Status.ToString();
                        msgText += " - Data: " + Convert.ToString((msg.message as StatusMessage).Data);
                    }
                    else if (msg.message is ExchangeMessage)
                    {
                        msgText += " - ExchangeName: " + (msg.message as ExchangeMessage).ExchangeName;
                        msgText += " - ExchangeData: " + Convert.ToString((msg.message as ExchangeMessage).ExchangeData);
                    }

                    this.Invoke(new MethodInvoker(delegate(){
                        lbLog.Items.Add(msgText);
                        lbLog.Items.Add("--------------------------------------------------------------------------------------------------------------");
                    }));
                };
                sub = m_SubMgr.CreateSubscription<Exchange.Contracts.Message>(dynamicMessage);

                m_SubMgr.Subscribe();

                btnSubscribe.Text = "Subscribed";
                btnSubscribe.Enabled = false;
                lbLog.Items.Add("Client Subscribed Successfully to the " + sub.Message.GetType().ToString()+ "!!!");
            }
            catch (Exception ex)
            {
                lbLog.Items.Add(ex.ToString());
            }
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {                
                btnSubscribe.Enabled = true;
                if (m_SubMgr != null)
                {
                    m_SubMgr.UnSubscribe();
                    lbLog.Items.Add("Client Unsubscribed!!!");
                }
                btnSubscribe.Enabled = true;
            }
            catch (Exception ex)
            {
                lbLog.Items.Add(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
        }

        private void LoadMessageTypes()
        {
            Assembly asm = typeof(Exchange.Contracts.Message).Assembly;

            var messageTypes = asm.GetTypes().Where(type => typeof(Exchange.Contracts.Message).IsAssignableFrom(type)).
                Select(messageType => new { type = messageType, desc = messageType.ToString()}).ToList();

            cbMessages.ValueMember = "type";
            cbMessages.DisplayMember = "desc";
            cbMessages.DataSource = messageTypes;

        }

        private async void btnPost_Click(object sender, EventArgs e)
        {

            this.Text = "FriendlyDBName = " + txtFDBN.Text;
            string data = "";
            string response = "";
            txtPubSubLog.Text = "";
            XmlDocument datax = new XmlDocument();

            if (String.IsNullOrEmpty(txtDataPath.Text))
            {
                MessageBox.Show(this, "XML path is empty");
                return;
            }
            
            if (File.Exists(txtDataPath.Text))
            {
                using (StreamReader reader = File.OpenText(txtDataPath.Text))
                {
                    data = reader.ReadToEnd();
                }
                datax.LoadXml(data);
            }
            else
            {
                MessageBox.Show(this, "XML path is invalid");
                return;
            }

            wbResponse.Navigate(_loadingImage);

            try
            {
                await Task.Factory.StartNew(() =>
                    {
                        string sts = "";
                        if (chkAuthenticate.Checked)
                        {
                            var authResponse = Exchange.ClientLib.AuthenticationServiceClient.AuthenticateUser(txtUser.Text, txtPassword.Text, txtFDBN.Text);

                            if (!authResponse.HasError)
                                sts = authResponse.AuthenticationCookie;
                        }

                        response = ExchangeData.PostData(txtURL.Text, datax, sts);
                    });


                wbResponse.Navigate(SaveTempResponse(response));

                await Task.Factory.StartNew(() => { Subscribe(response); });
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Check the URL... " + ex.Message, ":-(");
            }
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            this.Text = "FriendlyDBName = " + txtFDBN.Text;
            txtPubSubLog.Text = "";
            string response = "";
            string sts = "";

            wbResponse.Navigate(_loadingImage);

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    if (chkAuthenticate.Checked)
                    {
                        var authResponse = Exchange.ClientLib.AuthenticationServiceClient.AuthenticateUser(txtUser.Text, txtPassword.Text, txtFDBN.Text);

                        if (!authResponse.HasError)
                            sts = authResponse.AuthenticationCookie;
                    }

                    response = Exchange.ClientLib.ExchangeData.RequestData(txtURL.Text, sts);
                });
                
                wbResponse.Navigate(SaveTempResponse(response));

                await Task.Factory.StartNew(() => { Subscribe(response); });
                
            }
            //catch (AuthenticatieonException  ex)
            catch (Exception ex)
            {
                MessageBox.Show(this, "Check the URL... " + ex.Message,":-(");
            }
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML|*.xml|Text (.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    txtDataPath.Text = openFileDialog1.FileName;

                    if (File.Exists(txtDataPath.Text))
                    {
                        wbXML.Navigate(txtDataPath.Text);
                    }
                    else
                    {
                        MessageBox.Show("The File in " + txtDataPath.Text + " does not exists.");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void chkAuthenticate_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = chkAuthenticate.Checked;
            txtPassword.Enabled = chkAuthenticate.Checked;
            txtFDBN.Enabled = chkAuthenticate.Checked;
        }

        private string SaveTempResponse(string response)
        {
            if (string.IsNullOrEmpty(_tempFileName))
                _tempFileName = Path.GetTempFileName() + ".xml";

            if (File.Exists(_tempFileName))
                File.Delete(_tempFileName);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);

            if(xdoc.FirstChild.Name.ToUpper() =="HTML")
            {
                _tempFileName = Path.ChangeExtension(_tempFileName, ".html");
            }

            xdoc.Save(_tempFileName);

            return _tempFileName;
        }

        private void Subscribe(string response)
        {
            string requestID = "";

            if (m_SubMgr != null)
                m_SubMgr.Dispose();

            try
            {
                var xResponse = System.Xml.Linq.XDocument.Parse(response);
                requestID = (from n in xResponse.Descendants("ExchangeResponse")
                             select n.Element("RequestID").Value).First();
            }
            catch { }

            if (String.IsNullOrEmpty(requestID))
                return;
            
            try
            {
                Exchange.Contracts.Message dynamicMessage;
                if(cbMessages.InvokeRequired)
                {
                    cbMessages.Invoke(new MethodInvoker(delegate()
                    {
                        dynamicMessage = ((Type)cbMessages.SelectedValue).Assembly.CreateInstance(cbMessages.SelectedValue.ToString()) as Exchange.Contracts.Message;
                    }));
                }
                else
                    dynamicMessage = ((Type)cbMessages.SelectedValue).Assembly.CreateInstance(cbMessages.SelectedValue.ToString()) as Exchange.Contracts.Message;

                Subscription sub;

                m_SubMgr = new SubscriptionServiceManager();
                //m_SubMgr.SubscriptionServiceCallbackEvent += new SubscriptionServiceCallBackEventHander(exchangeSubscriptionClient_SubscriptionServiceCallbackEvent);
                m_SubMgr.SubscriptionServiceCallbackEvent += (s, msg) =>
                {
                    //string msgText;
                    _pubSubLog.Clear();
                    
                    _pubSubLog.AppendFormat("{0:T}-Callback>> MessageType: {2} - RequestName: {3}\n", DateTime.Now ,msg.message.RequestID, msg.message.GetType().Name, msg.message.RequestName);

                    //msgText = "Callback>>. " + "(" + msg.message.RequestID + ") Message: " + msg.message.RequestName;

                    if (msg.message is StatusMessage)
                    {
                        _pubSubLog.AppendFormat(" -Status: {0}\n", (msg.message as StatusMessage).Status.ToString());
                        _pubSubLog.AppendFormat(" -Data: {0}\n", (msg.message as StatusMessage).Data);
                    }
                    else if (msg.message is ExchangeMessage)
                    {
                        _pubSubLog.AppendFormat(" -ExchangeName: {0}\n", (msg.message as ExchangeMessage).ExchangeName);
                        _pubSubLog.AppendFormat(" -ExchangeData: {0}\n", (msg.message as ExchangeMessage).ExchangeData);
                    }

                    this.Invoke(new MethodInvoker(delegate()
                    {
                        txtPubSubLog.Text +=  _pubSubLog.ToString();
                        txtPubSubLog.Text += "--------------------------------------------------------------------------------------------------------------\n";
                    }));
                };
                
                sub = m_SubMgr.CreateSubscription(requestID);

                m_SubMgr.Subscribe();

                this.Invoke(new MethodInvoker(delegate()
                    {
                        txtPubSubLog.Text = "Subscribed to " + requestID;
                        txtPubSubLog.Text += "\n--------------------------------------------------------------------------------------------------------------\n";
                    }));
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    txtPubSubLog.Text += "\n" + ex.ToString();
                    txtPubSubLog.Text += "\n--------------------------------------------------------------------------------------------------------------\n";
                }));

            }

        }
    }
}

using Exchange.Contracts;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace CustomCodeWorkflow
{
    public class MyCodeWorkflow : IDataExchangeWorkflow
    {
        public string Run(ExchangeRequest request)
        {
            //TODO: magic

            string url = $"https://randomuser.me/api";

            var client = new HttpClient();

            //this is just a test... please don't .Result a Task ;-)
            var result = client.GetAsync(url).Result.
                Content.ReadAsStringAsync().Result;

            //var s = new JavaScriptSerializer();
            //var randomUserResult = s.Deserialize<UserResult>(result);

            return result;

        }
    }

}

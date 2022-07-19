# Workflow Workshop

Welcome to the Workflow Workshop!

The Workflow Workshop is a .NET solution for building and testing XAML and code workflows in DES.

## Getting Started

### Dependencies

- Visual Studio 2022 or higher
- Windows Workflow Foundation individual component from Visual Studio
- .NET Framework 4.7 or above

---

## Creating Workflows

### 1. Code workflow

```Csharp
      //1. Define a class that implements the IDataExchangeWorkflow interface from the Exchange.Contracts assembly
      public class MyCodeWorkflow : IDataExchangeWorkflow
      {
            //the run function is the entry point for DES
            public string Run(ExchangeRequest request)
            {
                  //TODO: magic

                  return result;
            }
      }
```

### 2. XAML workflow

```Csharp
//1. Set the path of the XAML workflow to invoke.

string workflowFilePath = @"..\..\..\WorkflowLib\Training\TestWorkflow.xaml";

//2. Optionally add any parameters required by the workflow

var exchangeParams = new Dictionary<string, string>()
{
      { "NAME", "Max" }
};

//3. Call ExecWorkflow or ExecWorkflowInDES if connected to a DES database.

//var response = WorkflowUtil.ExecWorkflowInDES(workflowFilePath, exchangeParams);

WorkflowUtil.ExecWorkflow(workflowFilePath, exchangeParams);
```

---

## Deploying Workflows

Workflows must be deployed in the server with the worker application. Any assembly dependency or configuration file introduced in a workflow must also be deployed typically in the **bin** directory of the DES worker app unless its independently loaded by the workflow.

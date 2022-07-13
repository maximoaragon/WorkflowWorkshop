# Workflow Workshop

Welcome to the Workflow Workshop!

The Workflow Workshop is a .NET solution for building and testing XAML workflows.

## Getting Started

### Dependencies

* Visual Studio 2022 or higher
* .NET Framework 4.7 or above

### Executing a workflow

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

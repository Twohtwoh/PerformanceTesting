using DecisionsFramework.Design.Flow;
using DecisionsFramework.ServiceLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceTesting;
using DecisionsFramework.Design;
using DecisionsFramework.Design.Flow.Service.Debugging;
using DecisionsFramework.Design.Flow.CoreSteps;
using DecisionsFramework.ServiceLayer.Services.UnitTesting;
using DecisionsFramework.Utilities.FrameworkUnitTests;

/// <summary>
/// The simplest types of steps are method based sync steps.  Simply write whatever
/// .NET code you want and use an attribute on the CLASS or on the METHOD itself to 
/// register that code with the workflow engine as a flow step.
/// </summary>
namespace PerformanceTesting.Steps
{
    [AutoRegisterMethodsOnClass(true, "Integration", "Performance Testing")]
    public class BatchRunFlow
    {
        public void BatchRun(string flowId, int executions, int numberOfThreads)
        {
            //AbstractUserContext UC = new PasswordCredentialsUserContext();
            //UserContextHolder.Register(UC);
            AbstractUserContext a = new SystemUserContext();
            //var UT = UnitTest.GetEntityById(UnitTestId);
            
            //DecisionsFramework.ServiceLayer.Services.UnitTesting.UnitTestService unitTestService = new UnitTestService();
            //unitTestService.EvaluateUnitTest(unitTestService.GetSessionUserContext("admin@decisions.com","admin"), new DecisionsFramework.Design.Flow.Service.MappingContext(), UnitTestId);
            ///UnitTestController.
            //UT = new UnitTest();
            //var Flow = FlowEngine.GetFlow(flowId);
            RunFlowFolderBehavior folder = new RunFlowFolderBehavior();
            _Mapper mapper = new _Mapper() { executions = executions, numberOfThreads = numberOfThreads, flowId = flowId };
            folder.RunTest(a,null,mapper);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Decisions.Utilities.OpenXmlPowerTools;
using DecisionsFramework;
using DecisionsFramework.Design;
using DecisionsFramework.Design.EntityActions;
using DecisionsFramework.Design.Flow.CoreSteps;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Actions;
using DecisionsFramework.ServiceLayer.Actions.Common;
using DecisionsFramework.ServiceLayer.Services.Folder;
using DecisionsFramework.ServiceLayer.Utilities;
using DecisionsFramework.Utilities.CodeGeneration.FlowSteps;

namespace PerformanceTesting
{
    /*
    * This class is extending the DesignerProjectFolder to inherit most behavior from the Designer Project Folder Behavior
    * and just override what we need to override for a specific use case.
    */
    public class RunUnitTestBatch
    {
        //Wrapper method to call a method on action execution that requires more than the standard action parameters
        //Parameters:
        //User Context - The User Context of the User who executed the Action
        //Entity ID - The Entity ID of the Folder the Action Lives on
        //Answer - The integer input in the action input field
       
        public void RunTest(AbstractUserContext userContext, _Mapper answer)
        {
            //PerformanceTestingSettings Settings = ModuleSettingsAccessor<PerformanceTestingSettings>.GetSettings();

            SetExecutionsValue(userContext, answer.executions, answer.numberOfThreads, answer.flowId, answer.UnitTestName);
        }


        public static void SetExecutionsValue(AbstractUserContext userContext, int executions, int numberOfThreads, string flowId, string unitTestName)
        {
            //PerformanceTestingSettings Settings = ModuleSettingsAccessor<PerformanceTestingSettings>.GetSettings();
            Log Log = new Log("Performance Testing");
           //Stopwatch TotalStopWatch = new Stopwatch();
            //TotalStopWatch.Start();
            int TotalFlowRuns = numberOfThreads * executions;
            Log.Error("Starting " + TotalFlowRuns + " Flow Runs for " + unitTestName);
            for (int i = 0; i < numberOfThreads; i++)
            {
                FlowExecutionThread flowExecutionThread = new FlowExecutionThread(executions, userContext, flowId);
                Thread thread = new Thread(new ThreadStart(flowExecutionThread.StartFlowExecution));
                thread.Start();
            }
            //TotalStopWatch.Stop();

            //Log.Error("Kicked Off " + TotalFlowRuns + " Flow Runs In " + TotalStopWatch.Elapsed.TotalSeconds);
            //Log.Error("Flow Run " + flowExecutionId + " took: " + innerStopWatch.Elapsed.TotalMilliseconds +
            //          " milliseconds.");

        }
    }

}
using System.Diagnostics;
using DecisionsFramework;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.Mapping;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Utilities;

namespace PerformanceTesting
{
    public class FlowExecutionThread
    {
        //Create the logger
        private static readonly Log Log = new Log("Performance Testing");

        //Create private variables
        private readonly int _executions;
        private readonly AbstractUserContext _userContext;
        private readonly string _flowId;

        //Constructor to initialize the private variables
        public FlowExecutionThread(int executions, AbstractUserContext userContext)
        {
            PerformanceTestingSettings Settings = ModuleSettingsAccessor<PerformanceTestingSettings>.GetSettings();
            this._executions = executions;
            this._userContext = userContext;
            this._flowId= Settings.DecisionsElementToTest;
        }

        //Method to execute the specified flow a specified number of times.
        public void StartFlowExecution()
        {
            //Register the user
            using (UserContextHolder.Register(_userContext))
            {
                //Create a stopwatch and kick it off, logging a guid to identify the batch of flow runs
                string threadExecutionId = System.Guid.NewGuid().ToString();
                Stopwatch outerStopWatch = new Stopwatch();
                Log.Error("Starting Thread: " + threadExecutionId + ", number of executions: " + _executions + ",flow: " + _flowId);
                outerStopWatch.Start();

                //Kick off the specified flow executions with the Flow Engine
                for (int i = 0; i < _executions; i++)
                {
                    //Create a stopwatch and kick it off, logging a guid to identify the individual flow run
                    string flowExecutionId = System.Guid.NewGuid().ToString();
                    Stopwatch innerStopWatch = new Stopwatch();
                    Log.Error("Starting Flow Run: " + flowExecutionId);
                    innerStopWatch.Start();

                    //Execute the flow with canned data
                    FlowEngine.StartSyncFlow(FlowEngine.GetFlow(_flowId),
                        GetFlowStateData());

                    //Stop the stopwatch and log how much time it took for the individual flow run
                    innerStopWatch.Stop();
                    Log.Error("Flow Run " + flowExecutionId + " took: " + innerStopWatch.Elapsed.TotalMilliseconds +
                              " milliseconds.");
                }

                //Stop the stopwatch and log how much time it took for the batch of flow runs
                outerStopWatch.Stop();
                Log.Error("Thread: " + threadExecutionId + ", number of executions: " + _executions + ",flow: " + _flowId + ", took " + outerStopWatch.Elapsed.TotalSeconds + " seconds.");
            }
        }

        //Private method containing canned data to use per flow run.
        private static FlowStateData GetFlowStateData()
        {
            PerformanceTestingSettings Settings = ModuleSettingsAccessor<PerformanceTestingSettings>.GetSettings();
            FlowStateData Out = new FlowStateData();
            //Out.AddValues();
            //return Out;
            int i = 0;
            foreach (var item in Settings.Inputs)
            {
                Out.Add(new KeyValuePairDataStructure(Settings.Inputs[i].key, Settings.Inputs[i].value));
                i++;
            }
            return Out;
                    //new KeyValuePairDataStructure("ID", "13d71ddb-51ac-11ea-8232-a72eeb3fabdb"),
                    //new KeyValuePairDataStructure("ClaimInput", "<Claim> <ClaimBatchID>5658907</ClaimBatchID> <ClaimerBatchID>0000831965</ClaimerBatchID> <ClaimerID>2158792</ClaimerID> <SoldtoCode>100108494</SoldtoCode> <ShiptoCode>100108494</ShiptoCode> <IsAR>false</IsAR> <Currency>EUR</Currency> <DateCreated>2020-01-24T00:00:00</DateCreated> <ClaimID>23158437</ClaimID> <ClaimerClaimID>6141348</ClaimerClaimID> <ClaimStatus>Submitted</ClaimStatus> <RefurbisherClaim>false</RefurbisherClaim> <ClaimKind>Repair</ClaimKind> <IsARClaim>false</IsARClaim> <ClaimLocation>Workshop</ClaimLocation> <ClaimedModelNumber>HD8603/01</ClaimedModelNumber> <ClaimedProductNumber>ATW901346620153</ClaimedProductNumber> <DatePurchase>2017-06-08T00:00:00</DatePurchase> <DateRepairReceivedFromConsumer>2020-01-11T00:00:00</DateRepairReceivedFromConsumer> <DateRepairReceivedByRepairer>2020-01-21T00:00:00</DateRepairReceivedByRepairer> <DateRepairCompleted>2020-01-24T00:00:00</DateRepairCompleted> <SellingDealerAddress> <Name>Tchibo Filiale 5782</Name> <CountryID>AT</CountryID> <Address>Malserstr. 37</Address> <ZipCode>6500</ZipCode> <City>Landeck</City> </SellingDealerAddress> <ConsumerAddress> <Name>Nagele</Name> <CountryID>AT</CountryID> <Address>Rifenal 23</Address> <ZipCode>6511</ZipCode> <City>Zams</City> <Phone>D</Phone> </ConsumerAddress> <ConsumerType>Unknown</ConsumerType> <Condition>1</Condition> <Symptom>670</Symptom> <ClaimRepair> <ClaimID>23158437</ClaimID> <Position>P327</Position> <Flag>1</Flag> <Defect>D</Defect> <Repair>AX</Repair> <Section>G36</Section> <PartNumberCalculated>996530073811</PartNumberCalculated> <Quantity>1</Quantity> </ClaimRepair> <ClaimRepair> <ClaimID>23158437</ClaimID> <Position>P126</Position> <Defect>A1</Defect> <Repair>A</Repair> <Section>G30</Section> <PartNumberCalculated>421946018401</PartNumberCalculated> <Quantity>1</Quantity> </ClaimRepair> <ClaimRepair> <ClaimID>23158437</ClaimID> <Position>391</Position> <Defect>1</Defect> <Repair>2</Repair> <Section>SYS</Section> <Quantity>0</Quantity> </ClaimRepair> <ClaimRepair> <ClaimID>23158437</ClaimID> <Position>P346</Position> <Defect>D</Defect> <Repair>A</Repair> <Section>G33</Section> <PartNumberCalculated>996530017348</PartNumberCalculated> <Quantity>1</Quantity> </ClaimRepair> </Claim>")
                    
                
            }
    }


}

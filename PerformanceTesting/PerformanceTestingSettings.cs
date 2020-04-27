using DecisionsFramework.Data.ORMapper;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.Mapping;
using DecisionsFramework.ServiceLayer;
using DecisionsFramework.ServiceLayer.Actions;
using DecisionsFramework.ServiceLayer.Actions.Common;
using DecisionsFramework.ServiceLayer.Services.ConfigurationStorage;
using DecisionsFramework.ServiceLayer.Utilities;
using System.Collections.Generic;
using System.Runtime.Serialization;

/// <summary>
/// This class is used to create a single settings object that can be used
/// by flows and steps.  It will show up in the portal in /System/Settings for 
/// Portal Administrators.
/// </summary>
namespace PerformanceTesting
{
    [ORMEntity]
    [DataContract]
    public class PerformanceTestingSettings : AbstractModuleSettings
    {

       
        public PerformanceTestingSettings()
        {
            EntityName = "Performance Testing Configuration";
        }

        //private readonly KeyValuePairDataStructure[] Ins;
        //private readonly FlowStateData _Input;

        [ORMField]
        public string DecisionsElementToTest { get; set; }

        public FlowInputThing[] Inputs { get; set; }
        
 
        //public KeyValuePairDataStructure[] InputData { get; set;}

        //public MappingUtility mappingUtility { get; set; }
        //public InlineMapping mapping { get; set; }

        //public DecisionsFramework.Design.Flow.Mapping.IInputMapping InputMapping { get; set; }
        //public DecisionsFramework.Design.InputData.InputData Input { get; set; }
        //public DecisionsFramework.Design.InputData.InputDataService InputService { get; set; }
        //public DecisionsFramework.Design.InputData.IInputDataService InDataSer { get; set; }
        //public FlowInputThing[] flowInputThings { get; set; }






        public override BaseActionType[] GetActions(AbstractUserContext userContext, EntityActionType[] types)
        {
            List<BaseActionType> results = new List<BaseActionType>(base.GetActions(userContext, types));

            results.Add(new EditObjectAction(typeof(PerformanceTestingSettings), "Edit", null, "Edit", () => { return this; }, SaveChanges));

            return results.ToArray();
        }

        private void SaveChanges(AbstractUserContext userContext, object obj)
        {
            new DynamicORM().Store((IORMEntity)obj);
        }
    }
}

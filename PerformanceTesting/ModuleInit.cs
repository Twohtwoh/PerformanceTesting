//using DecisionsFramework.Design;
//using DecisionsFramework.ServiceLayer;
//using DecisionsFramework.ServiceLayer.Services.Folder;
//using DecisionsFramework.ServiceLayer.Services.Portal;
//using DecisionsFramework.ServiceLayer.Utilities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///// <summary>
///// This is a module initializer.  This is an optional aspect to a module.
///// This code is run whenever ServiceHostManager is started so this code can be
///// used to check and enforce branding, ensure certain things are present, make registrations,
///// enforce licensing and more.  Since this code is run on EVERY start of SHM it should not 
///// always recreate the same things, but should check and create as needed.
///// </summary>
//namespace PerformanceTesting
//{
//    public class ModuleInit : IInitializable
//    {
//        private void EnsureCustomSettingsObject()
//        {
//            ModuleSettingsAccessor<PerformanceTestingSettings>.GetSettings();
//            ModuleSettingsAccessor<PerformanceTestingSettings>.SaveSettings();
//        }

        
//            //Setting a hardcoded folder id for the example folder is not necessary, but may 
//            //make it easier to have code elsewhere that makes references to this folder
//            private const string FLOW_PERFORMANCE_TESTS_FOLDER = "FLOW_PERFORMANCE_TEST_FOLDER";

//            //This method is called when the module is initialized
//            public void Initialize()
//            {
//                //Create the Base Flow Folder which will take on the implemented behavior if it doesn't already exist
//                //This folder will be added for everyone
//                SystemUserContext suc = new SystemUserContext();
//                if (DecisionsFramework.ServiceLayer.Services.Folder.FolderService.Instance.Exists(suc, FLOW_PERFORMANCE_TESTS_FOLDER) == false)
//                {
//                    //Create the folder under System > Administration > System Tools
//                    DecisionsFramework.ServiceLayer.Services.Folder.FolderService.Instance.CreateSubFolder(suc, FLOW_PERFORMANCE_TESTS_FOLDER, "Flow Performance Tests", typeof(RunFlowFolderBehavior).FullName, "PERFORMANCE_FOLDER_ID");
//                }
//            }
//        }

//        //private void SetupFolders()
//        //{
//        //    SystemUserContext system = new SystemUserContext();
//        //    if (FolderService.Instance.Exists(system, "MY CO ROOT FOLDER") == false) {
//        ///        // The null here is for a Folder Bheavior which allows a lot of customization
//        //        // of a folder including custom actions and a lot of filtering capability.
//        //        FolderService.Instance.CreateRootFolder(system, "MY CO ROOT FOLDER", "My Company Designs", null);
//        //    }
//        //}

//        //private void ChangedBranding()
//        //{
//        //    ModuleSettingsAccessor<PortalSettings>.Instance.SloganText = "My Custom Rule Portal";

//        //    ModuleSettingsAccessor<DesignerSettings>.Instance.StudioSlogan = "My Custom Rule Studio";

//        //}
   
//}

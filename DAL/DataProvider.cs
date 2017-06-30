using CommandTestAutomation.Enums;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.DAL
{

    /// <summary>
    /// A data source that provides raw data objects.  In a real
    /// application this class would make calls to a database.
    /// </summary>
    public static class DataProvider
    {
        // Get Static Data
        #region staticdata
        public static ObservableCollection<INode> GetTestCases()
        {
            //Project definiation
            ObservableCollection<INode> _ProjectData = new ObservableCollection<INode>();
            _ProjectData.Add(new ProjectNode { NodeName = "My Project" });

            //initialize and add
            ObservableCollection<INode> TreeData = new ObservableCollection<INode>();


            //add Root items
            TreeData.Add(new FolderNode { NodeName = "Create" });
            TreeData.Add(new FolderNode { NodeName = "Login" });
            TreeData.Add(new FolderNode { NodeName = "Folder3" });
            TreeData.Add(new FolderNode { NodeName = "Folder4" });
            //Folders.Add(new File { NodeName = "File1.txt", FullPath = @"C:\File1.txt" });

            //add sub items
            (TreeData[0] as INodeWithChildren).Children.Add(new TestCaseNode
            {
                NodeName = "Create",
                TestStepsData = new ObservableCollection<TestStep>()
                {
                    new TestStep()
                    {
                        TestStepFieldActionValue = "https://www.google.com/gmail/about/",
                        TestStepFieldActionName = "Navigate",
                        
                    },
                     new TestStep()
                    {
                        TestStepFieldActionValue = "",
                        TestStepFieldActionName = "Click",

                    },
                }
            });
            
            (TreeData[0] as INodeWithChildren).Children.Add(new FolderNode { NodeName = "Folder12" });
          

            (TreeData[0] as INodeWithChildren).Children.Add(new TestCaseNode { NodeName = "Login" });
            (TreeData[0] as INodeWithChildren).Children.Add(new TestCaseNode { NodeName = "Login2" });
            (TreeData[0] as INodeWithChildren).Children.Add(new TestCaseNode { NodeName = "Logout" });
            foreach (var item in TreeData)
            {
                (_ProjectData[0] as INodeWithChildren).Children.Add(item);
            }
            return _ProjectData;

        }
        public static ObservableCollection<INode> GetUIObjects()
        {
            //Project definiation
            //ObservableCollection<INode> _ObjectMapData = new ObservableCollection<INode>();
            //_ObjectMapData.Add(new ProjectNode { NodeName = "Root" });

            //initialize and add
            ObservableCollection<INode> ProjectData = new ObservableCollection<INode>();

            //add Root items
            ProjectData.Add(new ProjectNode { NodeName = "ScotiaWeb" });
            ProjectData.Add(new ProjectNode { NodeName = "ScotiaDesktop" });

            ObservableCollection<INode> FolderrData = new ObservableCollection<INode>();

            //add sub items
            FolderrData.Add(new FolderNode { NodeName = "Login" });
           
            foreach (var item in DataProvider.GetStaticTestObjects())
            {
                (FolderrData[0] as INodeWithChildren).Children.Add(item);

            }

            foreach (var item in FolderrData)
            {
                (ProjectData[0] as INodeWithChildren).Children.Add(item);
            }

            //foreach (var item in ProjectData)
            //{
            //    (_ObjectMapData[0] as INodeWithChildren).Children.Add(item);
            //}
            return ProjectData;
        }
        #endregion

        #region GetUIFields
        public static ObservableCollection<UIFieldNode> GetUIFields()
        {
            return new ObservableCollection<UIFieldNode>()
            {
                new UIFieldNode(){NodeName="Browser"},
                new UIFieldNode(){NodeName="Window"},
                new UIFieldNode(){NodeName="WinForm"},
                new UIFieldNode(){NodeName="Wpf"}
            };
        
        }

     
        #endregion       


        #region GetTestSteps
        public static ObservableCollection<TestStep> GetTestSteps(string testCaseName)
        {
            switch (testCaseName)
            {
                case "Login":
                    return new ObservableCollection<TestStep>
                    {
                         new TestStep(){
                             AutomationTypePlatform=AutomationEnvironmentType.Web ,
                             //TestStepFieldNodeName="Browser",
                             TestStepFieldActionName="Navigate",
                             TestStepFieldActionValue="http://localhost:53556/",
                             UiFieldNodeItem =
                                                         new UIFieldNode(){
                                                             NodeName = "Browser",
                                                             UIFieldType = WebUIElementType.Browser,
                                                        }
                         },
                         
                    };

                case "Logout":
                    return new ObservableCollection<TestStep>
                    {
                        
                        new TestStep(){TestStepFieldActionName="Click",TestStepFieldActionValue=""},
                    };

            }

            return null;
        }

        //public static ObservableCollection<TestStep> GetTestSteps(TestCase testCase)
        //{
        //    return GetTestSteps(testCase.TestCaseName);
        //}

        #endregion // GetTestSteps

        #region GetTestObjects

        internal static ObservableCollection<UIFieldNode> GetTestObjects()
        {
            return new ObservableCollection<UIFieldNode>();
            //var data = new ObservableCollection<UIFieldNode>() { 
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.Browser,
            //        NodeName = "Browser",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.type,Value=BrowserType.ie.ToString()}
            //        },
            //        //Parent = null,
            //        IsParentRoot = true
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.Link,
            //        NodeName = "lnkRegister",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.id,Value="registerLink"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.TextBox,
            //        NodeName = "txtUserName",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.name,Value="UserName"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.TextBox,
            //        NodeName = "txtPassword",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.name,Value="Password"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.TextBox,
            //        NodeName = "txtConfirmPassword",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.name,Value="ConfirmPassword"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.RadioButton,
            //        NodeName = "GenderRadioButton",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.id,Value="Male"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.CheckBox,
            //        NodeName = "checkBoxTermsCond",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.id,Value="TermsConditions"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.ComboBox,
            //        NodeName = "cmbEmploymentType",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.id,Value="EmploymentType"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.Button,
            //        NodeName = "btnSubmit",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.type,Value="submit"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //    new UIFieldNode(){
            //        UIFieldType = WebUIElementType.Label,
            //        NodeName = "lblRegister",
            //        UIFieldPropCollection = new ObservableCollection<MyKeyValueModel<WebAttributeBy>>(){
            //             new MyKeyValueModel<WebAttributeBy>(){Key = WebAttributeBy.labelfor,Value="Register"}
            //        },
            //        //Parent = null,
            //        IsParentRoot = false
            //    },
            //};
            //return data;
        }

        internal static ObservableCollection<UIFieldNode> GetStaticTestObjects()
        {
          

            // or statc data

            var data = new ObservableCollection<UIFieldNode>() {
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.Browser,
                    NodeName = "Browser",
                    UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            
                        }
                    },
                    //Parent = null,
                    IsParentRoot = true
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.TextBox,
                    NodeName = "txtBingSearch",
                       UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "xpath",
                            PropertyValue= "//form[@id='sb_form']/div/input"
                        }
                    },
                  
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.Link,
                    NodeName = "lnkRegister",
                     UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "Class",
                            PropertyValue= "hero_home__link__desktop"
                        }
                    },
                   
                    //Parent = null,
                    IsParentRoot = false
                },
                 new UIFieldNode(){
                    UIFieldType = WebUIElementType.Page,
                    NodeName = "gmailPage",
                     UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        
                    },
                   
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.TextBox,
                    NodeName = "txtUserName",
                       UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "name",
                            PropertyValue= "UserName"
                        }
                    },
                  
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.TextBox,
                    NodeName = "txtPassword",
                     UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "name",
                            PropertyValue= "Password"
                        }
                    },
                   
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.TextBox,
                    NodeName = "txtConfirmPassword",
                       UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "name",
                            PropertyValue= "ConfirmPassword"
                        }
                    },

                  
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.RadioButton,
                    NodeName = "GenderRadioButton",
                        UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "id",
                            PropertyValue= "Male"
                        }
                    },
                  
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.CheckBox,
                    NodeName = "checkBoxTermsCond",
                         UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "id",
                            PropertyValue= "TermsConditions"
                        }
                    },
                  
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.ComboBox,
                    NodeName = "cmbEmploymentType",
                     UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "id",
                            PropertyValue= "EmploymentType"
                        }
                    },
                
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.Button,
                    NodeName = "submit",
                     UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "id",
                            PropertyValue= "myid"
                        }
                    },
                    //Parent = null,
                    IsParentRoot = false
                },
                new UIFieldNode(){
                    UIFieldType = WebUIElementType.Label,
                    NodeName = "lblRegister",
                     UIFieldPropCollection = new ObservableCollection<CommandTestAutomation.Models.PropertyNameValueModel>()
                    {
                        new CommandTestAutomation.Models.PropertyNameValueModel()
                        {
                            PropertyName= "labelfor",
                            PropertyValue= "Register"
                        }
                    },
                 
                    //Parent = null,
                    IsParentRoot = false
                },
            };
            return data;
        }

        
        public static UIFieldNode GetSampleTestObjects()
        {
            // Test data for example purposes
            UIFieldNode root = new UIFieldNode() { NodeName = "UI Objects" };

            UIFieldNode a = new UIFieldNode() { NodeName = AutomationEnvironmentType.Web.ToString() };
            a.Children.Add(new UIFieldNode()
            {
                NodeName = "txtUserName",
                UIFieldType = WebUIElementType.TextBox,
                //UIFieldEnvironmentType = AutomationEnvironmentType.Web,
                
            });
            root.Children.Add(a);
            UIFieldNode b = new UIFieldNode() { NodeName = AutomationEnvironmentType.Windows.ToString() };
            root.Children.Add(b);
            UIFieldNode c = new UIFieldNode() { NodeName = AutomationEnvironmentType.Windows.ToString() };
            root.Children.Add(c);
            UIFieldNode d = new UIFieldNode() { NodeName = AutomationEnvironmentType.Windows.ToString() };
            root.Children.Add(d);
            return root;
        }
        #endregion


    }
}

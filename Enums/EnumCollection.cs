using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Enums
{

    public enum TestDataSource
    {
        Local,
        SqlServer,
        Oracle,
        hpQualityCentter,
    }
        public enum AutomationEnvironmentType
        {         
          Web,
          Windows,
          WebServices,
          DataBase,
          AndroidMobile,
          AndroidWeb,
          iOSMobile,
          iOSWeb
        };

        public enum BrowserType
        {
           ie,
           firefox,
           chrome
        };

        public enum WebAttributeBy
        {
            id,
            name,
            type,
            Class,
            className,
            title,
            href,
            tab,
            value,
            action,
            method,
            multiple,
            labelfor,
            xpath

        };

        public enum WebUIElementTagType
        {  
           browser,
           button,
           calendar,
           checkbox,
           radio,
           combobox,
           datagrid,
           edit,
           list,
           text,
           window,
           link,
           input,
           label,
           submit,
           select,
           a,
        };

        //Thihs is for user understanding
        public enum WebUIElementType
        {
            Browser,
            Button,
            Calendar,
            CheckBox,
            DoNotKnow,
            Div,
            RadioButton,
            ComboBox,
            DataGrid,
            DropDown,
            Edit,
            ListBox,
            TextBox,
            Window,
            Link,
            Input,
            Label,
            Page,
            Tab
            
        };

        public enum WebUIElementAttirbuteType
        {
            id,
            title,
            src,
            href,
            alt,
            disabled,
            style,
            type,
            value,
            name,
        }

        public enum WebUIAction
        {
            Click,
            Navigate,
            Launch,
            SetText,           
            SelectComboBoxItem,
            SelectDropDownItem,
            SetCheckBox,
            SelectRadioButton,
            SetActive,
            Quit,
            VerifyText,
            Wait,
        }

        public enum WindowsUIAction
        {
            Click,
            Navigate,
            Launch,
            SetText,
            SelectComboBoxItem,
            SelectDropDownItem,
            SetCheckBox,
            SelectRadioButton,
            Quit,
            VerifyText,
            Wait,
        }
    public enum StepRunStatus
        {
        [Display(Name = "Passed")]
        PASSED =1,

        [Display(Name = "Failed")]
        FAILED =2 ,

        [Display(Name = "No Run")]
        NORUN = 3,

        }
    
}

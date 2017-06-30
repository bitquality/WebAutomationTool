using CommandTestAutomation.DAL;
using CommandTestAutomation.Enums;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Models;
using CommandTestAutomation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Helpers
{
    public class TestCaseRunner
    {
        static BrowserAutomationHelper browserAutomationHelper = null;
        static AutomationHelper automationHelper = new AutomationHelper();

        [STAThread]
        public StepRunStatus RunTestStep(TestStep testStep)
        {
            
            //initialize all the automation platforms...
            Win32ApiHelper winAutomationHelper = new Win32ApiHelper();

            //execute the test steps
            //Web Automation
            if (testStep.AutomationTypePlatform == AutomationEnvironmentType.Web)
            {
                if (testStep.TestStepFieldActionName == WebUIAction.Navigate.ToString())
                {
                    browserAutomationHelper = new BrowserAutomationHelper(new IeBrowserAutomationHelper());
                    return browserAutomationHelper.Navigate(testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.SetActive.ToString())
                {
                    return browserAutomationHelper.SetActive(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.SetText.ToString())
                {
                    return browserAutomationHelper.SetText(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }

                else if (testStep.TestStepFieldActionName == WebUIAction.Click.ToString())
                {
                    return browserAutomationHelper.Click(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.SetCheckBox.ToString())
                {
                    return browserAutomationHelper.SetCheckBox(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.SelectComboBoxItem.ToString())
                {
                    return browserAutomationHelper.SelectItem(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.SelectDropDownItem.ToString())
                {
                    return browserAutomationHelper.SelectItem(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.SelectRadioButton.ToString())
                {
                    return browserAutomationHelper.SelectRadioButton(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.VerifyText.ToString())
                {
                    return browserAutomationHelper.VerifyText(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                }
                else if (testStep.TestStepFieldActionName == WebUIAction.Wait.ToString())
                {
                    TimeSpan interval = TimeSpan.FromMilliseconds(Double.Parse(testStep.TestStepFieldActionValue));
                    return automationHelper.Wait(interval);
                }
            }//ed off if for ie

            //Windows Automation

            //WpfAutomation

            return StepRunStatus.FAILED;
        }


        [STAThread]
        public void RunTestCase(string strTestCaseName)
        {
            TestStep[] testSteps = DataProvider.GetTestSteps(strTestCaseName).ToArray();

            //initialize all the automation platforms...
            Win32ApiHelper winAutomationHelper = new Win32ApiHelper();
            BrowserAutomationHelper browserAutomationHelper = new BrowserAutomationHelper(new IeBrowserAutomationHelper());

            //execute the test steps
            foreach (TestStep testStep in testSteps)
            {
                //Web Automation
                if (testStep.AutomationTypePlatform == AutomationEnvironmentType.Web)
                {
                    if (testStep.TestStepFieldActionName == WebUIAction.Navigate.ToString())
                    {
                        browserAutomationHelper.Navigate(testStep.TestStepFieldActionValue);
                    }

                    else if (testStep.TestStepFieldActionName == WebUIAction.SetText.ToString())
                    {
                        browserAutomationHelper.SetText(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                    }

                    else if (testStep.TestStepFieldActionName == WebUIAction.Click.ToString())
                    {
                        browserAutomationHelper.Click(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                    }
                    else if (testStep.TestStepFieldActionName == WebUIAction.SetCheckBox.ToString())
                    {
                        browserAutomationHelper.SetCheckBox(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                    }
                    else if (testStep.TestStepFieldActionName == WebUIAction.SelectComboBoxItem.ToString())
                    {
                        browserAutomationHelper.SelectItem(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                    }
                    else if (testStep.TestStepFieldActionName == WebUIAction.SelectDropDownItem.ToString())
                    {
                        browserAutomationHelper.SelectItem(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                    }
                    else if (testStep.TestStepFieldActionName == WebUIAction.SelectRadioButton.ToString())
                    {
                        browserAutomationHelper.SelectRadioButton(testStep.UiFieldNodeItem, testStep.TestStepFieldActionValue);
                    }
                }

                //Windows Automation

                //WpfAutomation
            }
        }
    }
}

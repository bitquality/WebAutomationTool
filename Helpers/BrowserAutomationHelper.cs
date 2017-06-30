using mshtml;
using CommandTestAutomation.DAL;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Enums;

namespace CommandTestAutomation.Helpers
{
    class BrowserAutomationHelper:IBrowserAutomationHelper
    {
        IBrowserAutomationHelper browserAutomationHelper = null;

        public BrowserAutomationHelper(IBrowserAutomationHelper browserAutomationHelper)
        {
            this.browserAutomationHelper = browserAutomationHelper;
        }

        public StepRunStatus OpenBroswer()
        {
            return browserAutomationHelper.OpenBroswer();
        }

        public StepRunStatus Navigate(string url)
        {
            return browserAutomationHelper.Navigate(url);
        }

        public StepRunStatus Click(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.Click(FieldIdentifierData,  FieldActionValue);
        }

        public StepRunStatus SetCheckBox(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.SetCheckBox(FieldIdentifierData, FieldActionValue);
        }
        public StepRunStatus SelectItem(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.SelectItem(FieldIdentifierData, FieldActionValue);
        }

        public StepRunStatus SetActive(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.SetActive(FieldIdentifierData, FieldActionValue);
        }

        public StepRunStatus SelectRadioButton(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.SelectRadioButton(FieldIdentifierData, FieldActionValue);
        }
        public StepRunStatus Quit()
        {
            return browserAutomationHelper.Quit();
        }

      

        public List<Object> FindElement(UIFieldNode FieldIdentifierData)
        {
            return browserAutomationHelper.FindElement(FieldIdentifierData);
        }


        public StepRunStatus SetText(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
           return browserAutomationHelper.SetText( FieldIdentifierData,  FieldActionValue);
        }
        public StepRunStatus VerifyLabelText(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.VerifyLabelText( FieldIdentifierData, FieldActionValue);
        }

        public StepRunStatus VerifyListItem(UIFieldNode FieldIdentifierData, string FieldActionValue)
        {
            return browserAutomationHelper.VerifyListItem(FieldIdentifierData, FieldActionValue);
        }
        public StepRunStatus VerifyText(UIFieldNode FieldIdentifierData, string TextToVerify)
        {
            return browserAutomationHelper.VerifyText( FieldIdentifierData,  TextToVerify);
        }

        public StepRunStatus Wait(TimeSpan timeSpan)
        {
            return browserAutomationHelper.Wait(timeSpan);
        }
    }
}

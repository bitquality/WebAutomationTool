using mshtml;
using CommandTestAutomation.DAL;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandTestAutomation.Interfaces;
using CommandTestAutomation.Enums;

namespace CommandTestAutomation.Interfaces
{
    public interface IBrowserAutomationHelper: IAutomation
    {
        List<Object> FindElement(UIFieldNode FieldIdentifierData);

        StepRunStatus VerifyText(UIFieldNode FieldIdentifierData, string TextToVerify);
        StepRunStatus OpenBroswer();
        StepRunStatus Navigate(string Url);
        StepRunStatus SetText(UIFieldNode FieldIdentifierData, string FieldActionValue);
        StepRunStatus Click(UIFieldNode FieldIdentifierData, string FieldActionValue);
        StepRunStatus SelectItem(UIFieldNode FieldIdentifierData, string FieldActionValue);
        StepRunStatus SelectRadioButton(UIFieldNode FieldIdentifierData, string FieldActionValue);
        StepRunStatus Quit();
        StepRunStatus SetCheckBox(UIFieldNode FieldIdentifierData, string FieldActionValue);
        StepRunStatus VerifyLabelText(UIFieldNode FieldIdentifierData, string FieldActionValue);

        StepRunStatus VerifyListItem(UIFieldNode FieldIdentifierData, string FieldActionValue);
        StepRunStatus SetActive(UIFieldNode FieldIdentifierData, string FieldActionValue);
    }
}

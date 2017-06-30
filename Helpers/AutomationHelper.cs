using CommandTestAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandTestAutomation.Enums;
using System.Threading;

namespace CommandTestAutomation.Helpers
{
    public class AutomationHelper : IAutomation
    {
        public StepRunStatus Wait(TimeSpan timeSpan)
        {
            Thread.Sleep(Convert.ToInt32( timeSpan.TotalMilliseconds));
            return StepRunStatus.PASSED;
        }
    }
}

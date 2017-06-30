using CommandTestAutomation.Enums;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Interfaces
{
    public interface IAutomation
    {
        StepRunStatus Wait(TimeSpan timeSpan);
    }
}

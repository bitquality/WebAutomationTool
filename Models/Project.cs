using CommandTestAutomation.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.Models
{
    public class Project
    {
        public Project(string ProjectName)
        {
            this.ProjectName = ProjectName;
           
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; private set; }
        

        //private ObservableCollection<TestCase> _TestCases;

        //public virtual ObservableCollection<TestCase> TestCases
        //{
        //    get { return _TestCases; }
        //    set { _TestCases = value; }
        //}

        //private ObservableCollection<UIField> _UIFields;
        //public virtual ObservableCollection<UIField> UIFields
        //{
        //    get { return _UIFields; }
        //    set { _UIFields = value; }
        //}
    }
}

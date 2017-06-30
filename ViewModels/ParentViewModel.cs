using CommandTestAutomation.DAL;
using CommandTestAutomation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTestAutomation.ViewModels
{
   
    /// <summary>
    /// The ViewModel for the LoadOnDemand demo.  This simply
    /// exposes a read-only collection of projects.
    /// </summary>
    public class ParentViewModel:ViewModelBase
    {
        Project[] arrProjects;
        public ParentViewModel(ProjectChildrenType projectChildrenType)
        {
            arrProjects = DataProvider.GetProjects();

            ProjectViewModels = new ObservableCollection<ProjectViewModel>(
                (from project in arrProjects
                 select new ProjectViewModel(project, projectChildrenType))
                .ToList());
        }

        private ObservableCollection<ProjectViewModel> _projectViewModels;    
        public ObservableCollection<ProjectViewModel> ProjectViewModels
        {
            get { return _projectViewModels; }
            set {
                _projectViewModels = value;
                    NotifyPropertyChanged("ProjectViewModels");
                }
            
        }

        private ObservableCollection<Project> _Projects;
        public ObservableCollection<Project> Projects
        {
            get { return _Projects; }
            set { _Projects = value;
                NotifyPropertyChanged("Projects");
            }
        }
        

     
   

    }
}

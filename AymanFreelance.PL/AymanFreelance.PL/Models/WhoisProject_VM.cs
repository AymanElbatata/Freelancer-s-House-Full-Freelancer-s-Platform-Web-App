using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.PL.Models
{
    public class WhoisProject_VM
    {
        public ProjectTBL_VM ProjectTBL_VM { get; set; } = new ProjectTBL_VM();
        public List<ProjectApplicationTBL_VM> ProjectApplicationTBL_VM { get; set; } = new List<ProjectApplicationTBL_VM>();
        public bool? HasAppliedBefore { get; set; } = false;
    }

}

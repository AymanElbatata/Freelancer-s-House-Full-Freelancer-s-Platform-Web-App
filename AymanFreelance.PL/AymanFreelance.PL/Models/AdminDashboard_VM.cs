using AymanFreelance.BLL.Repositories;
using AymanFreelance.DAL.BaseEntity;

namespace AymanFreelance.PL.Models
{
    public class AdminDashboard_VM
    {
        public int? TotalAdmins { get; set; }
        public int? TotalClients { get; set; }
        public int? TotalFreelancers { get; set; }
        public int? TotalProjects { get; set; }
        public int? TotalActiveProjects { get; set; }
        public int? TotalCompletedProjects { get; set; }
        public List<ProjectTBL_VM> ProjectTBL_VM { get; set; } = new List<ProjectTBL_VM>();
        public List<UserTBL_VM> UserTBL_VM { get; set; } = new List<UserTBL_VM>();
    }
}


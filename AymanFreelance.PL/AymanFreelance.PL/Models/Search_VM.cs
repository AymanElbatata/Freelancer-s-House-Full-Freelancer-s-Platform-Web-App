using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.PL.Models
{
    public class Search_VM
    {
        public List<UserTBL_VM> Freelancers_VM { get; set; } = new List<UserTBL_VM>();
        public List<UserTBL_VM> Clients_VM { get; set; } = new List<UserTBL_VM>();
        public List<ProjectTBL_VM> ProjectTBL_VM { get; set; } = new List<ProjectTBL_VM>();
        public List<FreelancerRatingTBL_VM> FreelancerRatingTBL_VM { get; set; } = new List<FreelancerRatingTBL_VM>();
    }



}

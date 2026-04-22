using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.PL.Models
{
    public class WhoisFreelancerClient_VM
    {
        public UserTBL_VM UserTBL_VM { get; set; } = new UserTBL_VM();
        //public List<FreelancerRatingTBL_VM> ProjectRatingTBL_VM { get; set; } = new List<FreelancerRatingTBL_VM>();
    }

}

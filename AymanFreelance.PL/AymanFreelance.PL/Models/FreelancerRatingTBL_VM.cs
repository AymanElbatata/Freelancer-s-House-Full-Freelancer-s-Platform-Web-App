using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.PL.Models
{
    public class FreelancerRatingTBL_VM : BaseEntity<int>
    {
        public int? ProjectTBLId { get; set; }
        public virtual ProjectTBL? ProjectTBL { get; set; }

        public string? AppUserWhoRatedId { get; set; }
        public virtual AppUser? AppUserWhoRated { get; set; }

        public string? AppUserWhoIsRatedId { get; set; }
        public virtual AppUser? AppUserWhoIsRated { get; set; }

        public int Stars { get; set; }
        public string? ReviewSubject { get; set; } = null!;
        public string? ReviewComment { get; set; } = null!;

        public bool IsHelpful { get; set; } = false;
    }
}

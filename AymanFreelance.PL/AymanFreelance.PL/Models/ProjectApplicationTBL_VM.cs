using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.PL.Models
{
    public class ProjectApplicationTBL_VM : BaseEntity<string>
    {
        public int? ProjectTBLId { get; set; }
        public virtual ProjectTBL? ProjectTBL { get; set; }

        public string? AppUserWhoWroteId { get; set; }
        public virtual AppUser? AppUserWhoWrote { get; set; }

        public string? Message { get; set; } = null!;
        public int? DaysOfDelivery { get; set; } = 0;
        public int? Cost { get; set; } = 0;
        public int? PaymentInAdvance { get; set; } = 0;

    }
}

using AymanFreelance.DAL.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace AymanFreelance.PL.Models
{
    public class ProjectTBL_VM : BaseEntity<int>
    {
        public string? ProjectOwnerTBLId { get; set; }
        public virtual AppUser? ProjectOwnerTBL { get; set; }

        public string? ProjectFreelancerTBLId { get; set; }
        public virtual AppUser? ProjectFreelancerTBL { get; set; }

        public string? HashCode { get; set; } = null!;
        public string? Image { get; set; } = null!;

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string? Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string? Description { get; set; } = null!;

        [Required(ErrorMessage = "Duration in days is required")]
        [Display(Name = "Duration in days")]
        public int? RequiredDaysOfDelivery { get; set; } = 0;

        [Required(ErrorMessage = "Total payment is required")]
        [Display(Name = "Total Payment")]
        public int? TotalCost { get; set; } = 0;

        [Required(ErrorMessage = "Advanced payment is required")]
        [Display(Name = "Advanced payment")]
        public int? PaymentInAdvance { get; set; } = 0;

        //public bool IsPaymentInAdvancePaid { get; set; } = false;
        public DateTime? DateOfStartWork { get; set; } = null!;
        //public bool IsDelivered { get; set; } = false;
        public DateTime? DateOfDelivery { get; set; } = null!;

        public int? IncomeProfit { get; set; } = 0;
    }
}

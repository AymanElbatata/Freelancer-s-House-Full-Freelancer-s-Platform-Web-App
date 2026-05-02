using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AymanFreelance.PL.Models
{
    public class UserTBL_VM : BaseEntity<string>
    {
        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country")]
        public int? CountryTBLId { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public int? GenderTBLId { get; set; }

        [Required(ErrorMessage = "Profession is required")]
        [Display(Name = "Profession")]
        public int? ProfessionTBLId { get; set; }

        public virtual CountryTBL? CountryTBL { get; set; }
        public virtual GenderTBL? GenderTBL { get; set; }
        public virtual ProfessionTBL? ProfessionTBL { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; } = null!;
        public string? Role { get; set; } = null!;

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        [MaxLength(10, ErrorMessage = "First Name must be at max 10 characters")]
        public string? FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        [MaxLength(10, ErrorMessage = "Last Name must be at max 10 characters")]
        public string? LastName { get; set; } = null!;

        public string? UserName { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200, ErrorMessage = "Last Name must be at max 200 character")]
        public string? Address { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(50, ErrorMessage = "Phone must be at max 50 character")]
        public string? Phone { get; set; } = null!;

        //public string? HashCode { get; set; } = null!;
        public string? PersonalImage { get; set; } = null!;
        public string? PassportOrNationalIdImage { get; set; } = null!;
        public string? Description { get; set; } = null!;

        public List<FreelancerRatingTBL_VM> FreelancerRatingTBL_VM { get; set; } = new List<FreelancerRatingTBL_VM>();
        public IEnumerable<SelectListItem> CountryOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> GenderOptions { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> ProfessionOptions { get; set; } = new List<SelectListItem>();

    }
}

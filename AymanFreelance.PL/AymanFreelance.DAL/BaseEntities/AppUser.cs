using AymanFreelance.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AymanFreelance.DAL.BaseEntity
{
    public class AppUser : IdentityUser
    {
        public int? CountryTBLId { get; set; }
        public int? GenderTBLId { get; set; }
        public int? UserTypeTBLId { get; set; }
        public int? ProfessionTBLId { get; set; }

        public virtual CountryTBL? CountryTBL { get; set; }
        public virtual GenderTBL? GenderTBL { get; set; }
        public virtual UserTypeTBL? UserTypeTBL { get; set; }
        public virtual ProfessionTBL? ProfessionTBL { get; set; }


        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public string? Phone { get; set; } = null!;
        public string? ActivationCode { get; set; } = null!;

        //public string? HashCode { get; set; } = null!;
        public string? PersonalImage { get; set; } = null!;
        public string? PassportOrNationalIdImage { get; set; } = null!;
        public string? Description { get; set; } = null!;

        public bool IsActivated { get; set; } = false;
        public bool IsDeleted { get; set; } = false;

    }
}

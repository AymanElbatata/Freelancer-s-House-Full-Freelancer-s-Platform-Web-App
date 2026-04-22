using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.DAL.Entities
{
    public class FreelancerRatingTBL : BaseEntity<int>
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

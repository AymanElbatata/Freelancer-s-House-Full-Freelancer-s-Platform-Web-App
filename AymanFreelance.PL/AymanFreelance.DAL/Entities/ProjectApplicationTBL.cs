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
    public class ProjectApplicationTBL : BaseEntity<int>
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

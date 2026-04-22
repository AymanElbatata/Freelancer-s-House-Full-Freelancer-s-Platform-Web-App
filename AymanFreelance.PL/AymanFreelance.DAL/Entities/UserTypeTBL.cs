using AymanFreelance.DAL.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AymanFreelance.DAL.Entities
{
    public class UserTypeTBL : BaseEntity<int>
    {
        public string? Name { get; set; } = null!;
    }
}

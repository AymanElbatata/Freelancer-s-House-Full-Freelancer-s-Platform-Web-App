using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.PL.Models
{
    public class ProfessionTBL_VM : BaseEntity<int>
    {
        public string? Name { get; set; } = null!;
        public string? Image { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}

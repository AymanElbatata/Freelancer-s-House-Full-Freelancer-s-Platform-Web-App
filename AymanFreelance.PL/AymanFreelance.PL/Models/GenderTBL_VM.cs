using AymanFreelance.DAL.BaseEntity;

namespace AymanFreelance.PL.Models
{
    public class GenderTBL_VM : BaseEntity<int>
    {
        public string? Name { get; set; } = null!;
    }
}

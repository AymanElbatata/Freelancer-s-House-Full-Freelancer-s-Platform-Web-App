using AymanFreelance.DAL.BaseEntity;

namespace AymanFreelance.PL.Models
{
    public class CountryTBL_VM : BaseEntity<int>
    {
        public string? Name { get; set; } = null!;
    }
}

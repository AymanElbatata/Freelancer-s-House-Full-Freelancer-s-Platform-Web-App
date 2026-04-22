using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class CountryTBLRepository : GenericRepository<CountryTBL>, ICountryTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public CountryTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

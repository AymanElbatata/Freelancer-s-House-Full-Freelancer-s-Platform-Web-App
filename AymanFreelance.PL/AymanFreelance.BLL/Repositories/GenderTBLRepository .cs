using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class GenderTBLRepository : GenericRepository<GenderTBL>, IGenderTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public GenderTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

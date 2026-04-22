using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class ProfessionTBLRepository : GenericRepository<ProfessionTBL>, IProfessionTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public ProfessionTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

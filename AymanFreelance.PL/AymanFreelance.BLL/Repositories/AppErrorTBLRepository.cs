using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class AppErrorTBLRepository : GenericRepository<AppErrorTBL>, IAppErrorTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public AppErrorTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

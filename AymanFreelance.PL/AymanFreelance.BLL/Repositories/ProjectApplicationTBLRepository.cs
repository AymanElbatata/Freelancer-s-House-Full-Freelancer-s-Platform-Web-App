using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class ProjectApplicationTBLRepository : GenericRepository<ProjectApplicationTBL>, IProjectApplicationTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public ProjectApplicationTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

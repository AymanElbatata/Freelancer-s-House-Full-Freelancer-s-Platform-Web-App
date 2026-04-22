using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class ProjectTBLRepository : GenericRepository<ProjectTBL>, IProjectTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public ProjectTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

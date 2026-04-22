using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.Contexts;
using AymanFreelance.DAL.Entities;

namespace AymanFreelance.BLL.Repositories
{
    public class FreelancerRatingTBLRepository : GenericRepository<FreelancerRatingTBL>, IFreelancerRatingTBLRepository
    {
        private readonly AymanFreelanceDbContext _context;

        public FreelancerRatingTBLRepository(AymanFreelanceDbContext context) :base(context)
        {
            _context = context;
        }

    }
}

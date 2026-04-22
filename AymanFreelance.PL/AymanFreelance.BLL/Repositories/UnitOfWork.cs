using AymanFreelance.BLL.Interfaces;
using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace AymanFreelance.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenderTBLRepository GenderTBLRepository { get; }
        public ICountryTBLRepository CountryTBLRepository { get; }
        public IProfessionTBLRepository ProfessionTBLRepository { get; }
        public IEmailTBLRepository EmailTBLRepository { get; }
        public IAppErrorTBLRepository AppErrorTBLRepository { get; }
        public SignInManager<AppUser> SignInManager { get; }
        public RoleManager<AppRole> RoleManager { get; }
        public UserManager<AppUser> UserManager { get; }
        public IMySPECIALGUID MySPECIALGUID { get; }
        public IUserTypeTBLRepository UserTypeTBLRepository { get; }
        public IProjectTBLRepository ProjectTBLRepository { get; }
        public IFreelancerRatingTBLRepository FreelancerRatingTBLRepository { get; }
        public IProjectApplicationTBLRepository ProjectApplicationTBLRepository { get; }


        public UnitOfWork( IGenderTBLRepository GenderTBLRepository
            ,ICountryTBLRepository CountryTBLRepository,
            IProfessionTBLRepository ProfessionTBLRepository,
            IEmailTBLRepository EmailTBLRepository,
            IAppErrorTBLRepository AppErrorTBLRepository,
            SignInManager<AppUser> SignInManager,
            RoleManager<AppRole> RoleManager, UserManager<AppUser> UserManager,
            IMySPECIALGUID MySPECIALGUID,
            IUserTypeTBLRepository UserTypeTBLRepository,
            IProjectTBLRepository ProjectTBLRepository,
            IFreelancerRatingTBLRepository FreelancerRatingTBLRepository,
            IProjectApplicationTBLRepository ProjectApplicationTBLRepository
            )
        {
            this.CountryTBLRepository = CountryTBLRepository;
            this.GenderTBLRepository = GenderTBLRepository;
            this.EmailTBLRepository = EmailTBLRepository;
            this.AppErrorTBLRepository = AppErrorTBLRepository;
            this.ProfessionTBLRepository = ProfessionTBLRepository;
            this.SignInManager = SignInManager;
            this.RoleManager = RoleManager;
            this.UserManager = UserManager;
            this.MySPECIALGUID = MySPECIALGUID;
            this.UserTypeTBLRepository = UserTypeTBLRepository;
            this.ProjectTBLRepository = ProjectTBLRepository;
            this.FreelancerRatingTBLRepository = FreelancerRatingTBLRepository;
            this.ProjectApplicationTBLRepository = ProjectApplicationTBLRepository;
        }
    }
}

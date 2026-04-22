using AymanFreelance.BLL.Repositories;
using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AymanFreelance.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        ICountryTBLRepository CountryTBLRepository { get; }
        IGenderTBLRepository GenderTBLRepository { get; }
        IProfessionTBLRepository ProfessionTBLRepository { get; }
        IAppErrorTBLRepository AppErrorTBLRepository { get; }
        IEmailTBLRepository EmailTBLRepository { get; }
        SignInManager<AppUser> SignInManager { get; }
        RoleManager<AppRole> RoleManager { get; }
        UserManager<AppUser> UserManager { get; }
        IMySPECIALGUID MySPECIALGUID { get; }
        IUserTypeTBLRepository UserTypeTBLRepository { get; }
        IProjectTBLRepository ProjectTBLRepository { get; }
        IFreelancerRatingTBLRepository FreelancerRatingTBLRepository { get; }
        IProjectApplicationTBLRepository ProjectApplicationTBLRepository { get; }
    }
}

using AutoMapper;
using AymanFreelance.DAL.BaseEntity;
using AymanFreelance.DAL.Entities;
using AymanFreelance.PL.Models;
using Microsoft.AspNetCore.Identity;

namespace AymanFreelance.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProfessionTBL, ProfessionTBL_VM>().ReverseMap();
            CreateMap<CountryTBL, CountryTBL_VM>().ReverseMap();
            CreateMap<GenderTBL, GenderTBL_VM>().ReverseMap();
            CreateMap<EmailTBL, EmailTBL_VM>().ReverseMap();
            CreateMap<AppUser, UserTBL_VM>().ReverseMap();
            CreateMap<ProjectTBL, ProjectTBL_VM>().ReverseMap();
            CreateMap<FreelancerRatingTBL, FreelancerRatingTBL_VM>().ReverseMap();
            CreateMap<ProjectApplicationTBL, ProjectApplicationTBL_VM>().ReverseMap();
        }
    }
}

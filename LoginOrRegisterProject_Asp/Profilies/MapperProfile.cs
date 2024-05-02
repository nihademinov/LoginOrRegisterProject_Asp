using AutoMapper;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.ViewModels;

namespace LoginOrRegisterProject_Asp.Profilies
{
    public class MapperProfile:Profile
    {

        public MapperProfile() 
        {
            CreateMap<User,LoginViewModel>();
            CreateMap<LoginViewModel, User>();
            CreateMap<User, RegisterViewModel>();
            CreateMap<RegisterViewModel, User>();
        }
    }
}

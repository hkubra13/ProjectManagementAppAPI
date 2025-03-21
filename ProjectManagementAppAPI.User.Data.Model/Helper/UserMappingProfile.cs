using AutoMapper;
using ProjectManagementAppAPI.User.Data.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.User.Data.Model.Helper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<Models.User, UserLoginRequest>();
            CreateMap<UserLoginRequest, Models.User>();
        }
    }
}

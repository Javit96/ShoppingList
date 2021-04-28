using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingList.Models.Auth;
using ShoppingList.Resources;

namespace ShoppingList.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Username));
        }
    }
}

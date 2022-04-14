using System;
using AutoMapper;
using UserPrivileges.Models;
using UserPrivileges.Models.DTOs;
using UserPrivileges.Repository;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Mapper
{
    public class UserPrivilegeMappings : Profile
    {

        public UserPrivilegeMappings()
        {

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserPrivilege, UserPrivilegeDto>().ReverseMap();
            CreateMap<PackingRule, PackingRuleDTO>().ReverseMap();
            CreateMap<PackingTickets, PackingTicketsDTO>().ReverseMap();
        }
    }
}

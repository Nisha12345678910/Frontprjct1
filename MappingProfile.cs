using AutoMapper;
using MVCUdemy1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUdemy1.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
           // CreateMap<CustomerDTO, Customer>();
            CreateMap<MembershipType, MembershipTypeDTO>();
            //CreateMap<MembershipTypeDTO,MembershipType>();

        }
    }
}
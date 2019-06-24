using AutoMapper;
using passportapi.Domain.Models;
using passportapi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePassportInfoResource, PassportInfo>()
                .ForMember(d => d.Value, opt => opt
                .MapFrom(s => Enum.Parse(typeof(Enumerations), s.visaStatus)));
        }
    }
}

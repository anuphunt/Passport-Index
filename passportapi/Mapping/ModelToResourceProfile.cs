using AutoMapper;
using passportapi.Domain.Models;
using passportapi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<PassportIndex, PassportInfoResource>();
        }
    }
}

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
            CreateMap<PassportInfo, PassportInfoResource>().ForMember(d=>d.VisaStatus, opt=>opt.MapFrom(source=> Enum.GetName(typeof(Enumerations), source.Value)));
        }
    }
}

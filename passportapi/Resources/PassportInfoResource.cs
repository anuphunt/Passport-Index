using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Resources
{
    public class PassportInfoResource
    {
        public string Passport { get; set; }
        public string Destination { get; set; }
        public string VisaStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace passportapi.Domain.Models
{
    public partial class PassportInfo
    {
        public int Id { get; set; }
        public string Passport { get; set; }
        public string Destination { get; set; }
        public int Value { get; set; }
    }
}

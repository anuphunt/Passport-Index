using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Resources
{
    public class SavePassportInfoResource
    {
        [Required]
        [MaxLength(50)]
        public string Passport { get; set; }

        [Required]
        [MaxLength(50)]
        public string Destination { get; set; }

        [Required]
        public int Code { get; set; }
    }
}

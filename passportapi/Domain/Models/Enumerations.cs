using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Models
{
    public enum Enumerations
    {
        [Description("Destination Same as origin country")]
        Same_Country = -1,

        [Description("Visa is Required")]
        Visa_Required = 0,

        [Description("Visa On Arrival")]
        Visa_On_Arrival = 1,

        [Description("Electronic Visa Required")]
        ETA_Required = 2,

        [Description("Visa Not Required")]
        Visa_Free_Travel = 3
    }
}

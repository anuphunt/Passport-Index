using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Services.Communication
{
    public class PassportInfoResponse: BaseResponse
    {
        public PassportIndex PassportIndex { get; private set; }

        private PassportInfoResponse(bool success, string message, PassportIndex passportIndex): base (success, message)
        {
            PassportIndex = passportIndex;
        }

        //produces success message
        public PassportInfoResponse(PassportIndex passportinfo) : this(true, string.Empty, passportinfo) { }

        //produces error message
        public PassportInfoResponse(string message) : this(false, message, null) { }
        


    }
}

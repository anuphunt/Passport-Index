using passportapi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passportapi.Domain.Services.Communication
{
    public class PassportInfoResponse: BaseResponse
    {
        public PassportInfo PassportInfo { get; private set; }

        private PassportInfoResponse(bool success, string message, PassportInfo passportInfo): base (success, message)
        {
            PassportInfo = passportInfo;
        }

        //produces success message
        public PassportInfoResponse(PassportInfo passportinfo) : this(true, string.Empty, passportinfo) { }

        //produces error message
        public PassportInfoResponse(string message) : this(false, message, null) { }
        


    }
}

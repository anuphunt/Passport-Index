using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using passportapi.Domain.Models;
using passportapi.Domain.Services;

namespace passportapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportInfoController : ControllerBase
    {
        private readonly IPassportInfoService _passportInfoService;

        public PassportInfoController(IPassportInfoService passportInfoService)
        {
            _passportInfoService = passportInfoService; 
        }

        [HttpGet]
        public async Task<IEnumerable<PassportInfo>> GetAllAsync()
        {
            var passportInfo = await _passportInfoService.ListAsync();
            return passportInfo;
        }
    }
}

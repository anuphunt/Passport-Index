using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using passportapi.Domain.Models;
using passportapi.Domain.Services;
using passportapi.Extensions;
using passportapi.Resources;

namespace passportapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportInfoController : ControllerBase
    {
        private readonly IPassportInfoService _passportInfoService;
        private readonly IMapper _mapper;

        public PassportInfoController(IPassportInfoService passportInfoService, IMapper mapper)
        {
            _passportInfoService = passportInfoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PassportInfoResource>> GetAllAsync()
        {
            var passportInfo = await _passportInfoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<PassportIndex>, IEnumerable<PassportInfoResource>>(passportInfo);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<PassportInfoResource> GetById(int id)
        {
            var passportInfo = await _passportInfoService.FindByIdAsync(id);
            var resources = _mapper.Map<PassportIndex, PassportInfoResource>(passportInfo);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePassportInfoResource resource)
        {
            //Check is Model State is Valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            //Map the view resource to db resource.
            var passportInfo = _mapper.Map<SavePassportInfoResource, PassportIndex>(resource);
            var result = await _passportInfoService.SaveAsync(passportInfo);

            if (!result.Success)
                return BadRequest(result.Message);

            var passportResource = _mapper.Map<PassportIndex, PassportInfoResource>(result.PassportIndex);

            return Ok(passportResource);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutAsync(int id, [FromBody] SavePassportInfoResource resource)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState.GetErrorMessages());
        //     }
        //
        //     var passportinfo = _mapper.Map<SavePassportInfoResource, PassportIndex>(resource);
        //     var result = await _passportInfoService.UpdateAsync(id, passportinfo);
        //
        //     if (!result.Success)
        //     {
        //         return BadRequest(result.Message);
        //     }
        //
        //     var passportinforesource = _mapper.Map<PassportIndex, PassportInfoResource>(result.PassportIndex);
        //     return Ok(passportinforesource);                
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteAsync (int id)
        // {
        //     var result = await _passportInfoService.DeleteAsync(id);
        //
        //     if (!result.Success)
        //     {
        //         return BadRequest(result.Message);
        //     }
        //
        //     var passportInfoResource = _mapper.Map<PassportIndex, PassportInfoResource>(result.PassportIndex);
        //     return Ok(passportInfoResource);
        // }

        //Get info for source and destination
        [HttpGet("{source}/{destination}")]
        public async Task<PassportInfoResource> GetBySourceAndDestination(string source, string destination)
        {
            var passportInfo =await _passportInfoService.GetBySourceAndDestination(source, destination);
            var resource = _mapper.Map<PassportIndex, PassportInfoResource>(passportInfo);

            return resource;
        }

        //Get all info of a single country
        [HttpGet("{country}")]
        public async Task<IEnumerable<PassportInfoResource>> GetBySingleCountry(string country)
        {
            var passportInfo = await _passportInfoService.GetBySingleCountry(country);
            var resource = _mapper.Map<IEnumerable<PassportIndex>, IEnumerable<PassportInfoResource>>(passportInfo);

            return resource;
        }

        [HttpGet("countryandcode/{country}/{code}")]
        public async Task<IEnumerable<PassportInfoResource>> GetByCountryAndCode(string country, int code)
        {
            var passportInfo = await _passportInfoService.GetByCountryAndCode(country, code);
            var resource = _mapper.Map<IEnumerable<PassportIndex>, IEnumerable<PassportInfoResource>>(passportInfo);

            return resource;
        }
    }
}

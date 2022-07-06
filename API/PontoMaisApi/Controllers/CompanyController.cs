using Microsoft.AspNetCore.Mvc;
using PontoMaisDomain.Companies.Dto;
using PontoMaisDomain.Companies.Entities;
using PontoMaisDomain.Companies.Services;
using System;

namespace PontoMaisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("company")]
        public async Task<ActionResult> addCompany([FromBody] AddCompanyRequestDto request)
        {
            var company = new Company(
                request.Name,
                request.Adress,
                request.Sector,
                request.CreatedBy);

            await _companyService.Add(company);

            return Created(new Uri($"{Request.Path}/{company.Id}") ,company);
        }

        [HttpGet]
        [Route("getCompany/{id}")]
        public ActionResult GetCompany(Guid id){
            var company = _companyService.Get(id);

            return Ok(company);
        }
    }
}

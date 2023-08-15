
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Application.Features.SystemProducts.Companies.Queries.GetCompaniesList;
using PointOfSale.Application.Features.SystemProducts.Companies.Commands.CreateCompany;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllCompanies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompaniesListVm>>> GetAllCompanies()
        {
            var dtos = await _mediator.Send(new GetCompaniesListQuery());
            return Ok(dtos);
        }


        [HttpPost(Name = "AddCompany")]
        public async Task<ActionResult<CreateCompanyCommandResponse>> Create([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var response = await _mediator.Send(createCompanyCommand);
            return Ok(response);
        }
    }
}

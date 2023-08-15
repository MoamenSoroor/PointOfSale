
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Application.Features.SystemProducts.ProductCategories.Commands.CreateProductCategory;
using PointOfSale.Application.Features.SystemProducts.SystemProductCategory.Queries.GetProductCategoryList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSale.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllProductCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductCategoryVm>>> GetAllProductCategories()
        {
            var dtos = await _mediator.Send(new GetProductCategoryListQuery());
            return Ok(dtos);
        }


        [HttpPost(Name = "AddProductCategory")]
        public async Task<ActionResult<CreateProductCategoryCommandResponse>> Create([FromBody] CreateProductCategoryCommand createProductCategoryCommand)
        {
            var response = await _mediator.Send(createProductCategoryCommand);
            return Ok(response);
        }
    }
}

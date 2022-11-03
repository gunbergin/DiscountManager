using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Requests;
using Domain.Responses;
using MediatR;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetCustomerDiscountResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetCustomerDiscountResponse>> GetCustomerDiscountPrice(GetCustomerDiscountRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

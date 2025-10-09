using GenericShop.Services.Customers.Application.Commands.AddCustomer;
using GenericShop.Services.Customers.Application.Commands.UpdateCustomer;
using GenericShop.Services.Customers.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GenericShop.Services.Customers.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerCommand command)
        {
            var id = await _mediator.Send(command);

            return Created($"api/customers/{id}", value: null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);

            var customerViewModel = await _mediator.Send(query);

            if (customerViewModel is null) return NotFound();      

            return Ok(customerViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }
    }
}

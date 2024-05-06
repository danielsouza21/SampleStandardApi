using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamplePersonalStandard.Application.CQRS.Commands;
using SamplePersonalStandard.Application.CQRS.Queries;
using SamplePersonalStandard.Application.DTOs;

namespace SamplePersonalStandard.Api.Controllers
{
    //TODO [Template]: DELETE IT {TEMPLATE}

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all orders.
        /// </summary>
        /// <param name="query.Id">The unique order identifier.</param>
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> RetrieveOrder([FromRoute] GetOrder query) 
        {
            //TODO: Implement automapper
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Returns a single order by `ID`.
        /// </summary>
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [HttpGet("/all")]
        public async Task<IActionResult> RetrieveOrders([FromRoute] GetOrders query)
        {
            //TODO: Implement automapper
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// Create and insert a new order.
        /// </summary>
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromRoute] CreateOrder command)
        {
            //TODO: Implement automapper
            await _mediator.Send(command);
            return Created();
        }

        /// <summary>
        /// Update a order.
        /// </summary>
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status202Accepted)]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromRoute] UpdateOrder command)
        {
            //TODO: Implement automapper
            await _mediator.Send(command);
            return Accepted();
        }
    }
}

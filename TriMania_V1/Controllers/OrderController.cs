using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TriMania_V1.Filters;

namespace TriMania_V1.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("createOrder")]
        [ErrorsValidation]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderRequest command,
            [FromServices]IMediator handler)
        {
            try
            {
                if (command.Items.Count.Equals(0))
                    return BadRequest("Informe ao menos um produto no seu pedido");

                foreach(var item in command.Items)
                {
                    if (!TryValidateModel(item))
                        return BadRequest(ModelState.Values);
                }

                var response = await handler.Send(command);

                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Nao foi possivel criar um pedido");
            }
        }
    }
}

using Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest command,
            [FromServices] IMediator handler)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(command.UserId))
                    return BadRequest("Usuario informado não existe");

                if (command.Items.Count.Equals(0))
                    return BadRequest("Informe ao menos um produto no seu pedido");

                foreach (var item in command.Items)
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

        [HttpPost]
        [Route("completedOrder")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> CompletedOrder(CompletedOrderRequest command,
        [FromServices]IMediator handler)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(command.UserId))
                    return BadRequest("Usuario informado não existe");

                var response = await handler.Send(command);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel completar o pedido");
            }
        }

        [HttpPost]
        [Route("updateOrder")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> UpdateOrder([FromBody]UpdateOrderRequest command,
            [FromServices]IMediator handler)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(command.UserId))
                    return BadRequest("Usuario informado não existe");

                if (command.Items.Count.Equals(0))
                    return BadRequest("Informe ao menos um item para ser adicionado ou atualizado no pedido");

                foreach (var item in command.Items)
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
                return BadRequest("Não foi possivel atualizar o seu pedido");
            }
        }

        [HttpPost]
        [Route("removeOrderItem")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> RemoveOrderItem([FromBody]RemoveOrderItemRequest command,
            [FromServices]IMediator handler)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(command.UserId))
                    return BadRequest("Usuario informado não existe");

                if (command.Items.Count.Equals(0))
                    return BadRequest("Informe ao menos um item para ser removido do seu pedido");

                foreach (var item in command.Items)
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
                return BadRequest("Não Foi possivel remover os itens do seu pedido");
            }
        }

        [HttpPost]
        [Route("cancelledOrder")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> CancelledOrder([FromBody]CancelledOrderRequest command,
            [FromServices]IMediator handler)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(command.UserId))
                    return BadRequest("Usuario informado não existe");

                var response = await handler.Send(command);

                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex )
            {
                return BadRequest("Não foi possivel cancelar o seu pedido");
            }
        }
    }
}

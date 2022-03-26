using Core.Interfaces;
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
        #region swagger
        /// <summary>
        /// Realiza a criação de um pedido 
        /// || O usário deve está logado 
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     POST /Login
        ///     {
        ///         "userId": 2,
        ///         "items": [
        ///          {
        ///             "productId": 2,
        ///             "quantity": 2,
        ///             "price": 499.99
        ///          }
        ///        ]
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o pedido criado</response>
        /// <response code="400">Quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        #endregion
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

        #region swagger
        /// <summary>
        /// Finalizar um pedido criado pelo usuário
        /// || O usário deve está logado 
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     {
        ///         "userId": 0,
        ///         "type": 1
        ///     }
        /// </remarks>
        /// <response code="200">Retorno quando o pedido foi finalizado com sucesso</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        #endregion
        [HttpPost]
        [Route("completedOrder")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> CompletedOrder(CompletedOrderRequest command,
        [FromServices] IMediator handler)
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

        #region swagger
        /// <summary>
        /// Realizar a alteração ou adicionar algum novo produto no pedido feito pelo usuário
        /// || O usário deve está logado 
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     {
        ///         "userId": 0,
        ///         "items": [
        ///             {
        ///                 "productId": 2,
        ///                 "quantity": 2,
        ///                 "price": 10
        ///             },
        ///             {
        ///                 "productId": 1,
        ///                 "quantity": 2,
        ///                 "price": 100
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o pedido atualizado</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        #endregion
        [HttpPost]
        [Route("updateOrder")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest command,
            [FromServices] IMediator handler)
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

        #region swagger
        /// <summary>
        /// Remover produtos de um pedido
        /// || O usário deve está logado 
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     {
        ///         "userId": 0,
        ///         "items": [
        ///             {
        ///                 "orderItemId": 2
        ///             },
        ///             {
        ///                 "orderItemId": 1
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o pedido atualizado</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        #endregion
        [HttpPost]
        [Route("removeOrderItem")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> RemoveOrderItem([FromBody] RemoveOrderItemRequest command,
            [FromServices] IMediator handler)
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

        #region swagger
        /// <summary>
        /// Realizar o cancelamento de um pedido
        /// || O usário deve está logado 
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     {
        ///         "userId": 0,
        ///         "items": [
        ///             {
        ///                 "orderItemId": 2
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o pedido cancelado</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        #endregion
        [HttpPost]
        [Route("cancelledOrder")]
        [ErrorsValidation]
        [Authorize]
        public async Task<IActionResult> CancelledOrder([FromBody] CancelledOrderRequest command,
            [FromServices] IMediator handler)
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
            catch (Exception ex)
            {
                return BadRequest("Não foi possivel cancelar o seu pedido");
            }
        }


        #region swagger
        /// <summary>
        /// Retorna o relatorio de vendas 
        /// || só e acessado pelo usuário ADMIN
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        /// 
        ///     {
        ///         "initialDate": "2022-03-26",
        ///         "finishDate": "2022-03-28",
        ///         "status": [
        ///             0,2,1
        ///         ],
        ///         "users": [
        ///             0,22,33,2,6
        ///         ]
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o resultado do relatorio de acordo com os filtros</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        /// <response code="403">Retorno quando a autorização e negada</response>
        #endregion
        [HttpPost]
        [Route("salesReport")]
        [Authorize(Roles = "Manager")]
        [ErrorsValidation]
        public async Task<IActionResult> SalesReport([FromBody] SalesReportRequest salesReport,
            [FromServices] IOrderRepositoryDP query)
        {
            try
            {
                var response = await query.GetSalesReport(salesReport.InitialDate, salesReport.FinishDate, salesReport.Status, salesReport.Users);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível retorna o relatorio de vendas");
            }
        }
    }
}

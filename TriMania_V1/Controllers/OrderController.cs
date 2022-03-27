using Core.Interfaces;
using Domain.Commands.Requests;
using Domain.Language.API;
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
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                if (command.Items.Count.Equals(0))
                    return BadRequest(CreateOrderControllerMsg.TryValidateModel_Error_00001);

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
                return BadRequest(ApiMsg.Error_Status_500);
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
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                var response = await handler.Send(command);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiMsg.Error_Status_500);
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
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                if (command.Items.Count.Equals(0))
                    return BadRequest(CreateOrderControllerMsg.TryValidateModel_Error_00002);

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
                return BadRequest(ApiMsg.Error_Status_500);
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
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                if (command.Items.Count.Equals(0))
                    return BadRequest(CreateOrderControllerMsg.TryValidateModel_Error_00003);

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
                return BadRequest(ApiMsg.Error_Status_500);
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
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                var response = await handler.Send(command);

                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiMsg.Error_Status_500);
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
                if (salesReport.Status.Count.Equals(0))
                    return BadRequest(CreateOrderControllerMsg.TryValidateModel_Error_00004);

                if (salesReport.Users.Count.Equals(0))
                    return BadRequest(CreateOrderControllerMsg.TryValidateModel_Error_00005);

                if (DateTime.Parse(salesReport.InitialDate) >= DateTime.Parse(salesReport.FinishDate))
                    return BadRequest("A data inicial deve ser menor do que a data final");

                var response = await query.GetSalesReport(salesReport.InitialDate, salesReport.FinishDate, salesReport.Status, salesReport.Users);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiMsg.Error_Status_500);
            }
        }

        #region swagger
        /// <summary>
        /// Retorna o pedido que esteja aberto pelo usuário
        /// || O usúário deve está logado
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <response code="200">Retorna o pedido do usuário que ainda não esteja fechado ou finalizado </response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        /// <response code="403">Retorno quando a autorização e negada</response>
        #endregion
        [HttpGet]
        [Route("getOrderOpen/{userId:int}")]
        [Authorize]
        public async Task<IActionResult> GetOrderOpen(int userId,
            [FromServices]IOrderRepositoryDP query)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(userId))
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                var response = await query.GetOrderOpen(userId);

                if (response is null)
                    return Ok(CreateOrderControllerMsg.Result_Ok_00001);
                else
                    return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(ApiMsg.Error_Status_500);
            }
        }
    }
}

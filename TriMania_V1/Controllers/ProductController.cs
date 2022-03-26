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
    [Route("products")]
    public class ProductController : ControllerBase
    {
        #region swagger
        /// <summary>
        /// Realiza a criação de produtos
        /// || Só acessado pelo ADMIN
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Retorna o Produto criado</response>
        /// <response code="400">Retorna quando a dados invalidos</response>
        /// <response code="401">Retorna quando não foi feito o login</response>
        /// <response code="403">Retorna a autorição foi negada</response>
        #endregion
        [HttpPost]
        [Route("createproduct")]
        [Authorize(Roles = "Manager")]
        [ErrorsValidation]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductRequest command,
            [FromServices]IMediator handler)
        {
            try
            {
                var response = await handler.Send(command);

                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Tente novamente mais tarde");
            }
        }

        #region swagger
        /// <summary>
        /// Retorna a lista de todos os produtos
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Retorna o Produto criado</response>
        /// <response code="400">Retorna quando a dados invalidos ou alguma validação errada</response>
        #endregion
        [HttpGet]
        [Route("getallproduct")]
        public async Task<IActionResult> GetAllProduct([FromServices] IProductRepositoryDP query)
        {
            try
            {
                var response = await query.GetAllProduts();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível retorna a lista de produtos");
            }
        }
    }
}

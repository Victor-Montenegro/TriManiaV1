using Domain.Commands.Requests;
using Domain.Interfaces;
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
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Retorna o Produto criado</response>
        /// <response code="400">Retorna quando a dados invalidos</response>
        #endregion
        [HttpPost]
        [Route("createproduct")]
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
        /// <response code="200">Lista de produtos criados/response>
        #endregion
        [HttpGet]
        [Route("getallproduct")]
        public async Task<IActionResult> GetAllProduct([FromServices]IProductRepository productRepository)
        {
            try
            {
                var response = await productRepository.GetAll();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Tente novamente mais tarde");
            }
        }
    }
}

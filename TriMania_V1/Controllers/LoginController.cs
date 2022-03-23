using Domain.Commands.Requests;
using Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TriMania_V1.Filters;

namespace TriMania_V1.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        #region swagger
        /// <summary>
        /// Realiza o login de usuario no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     POST /Login
        ///     {
        ///        "Login" : "admin",
        ///        "Passworld" : "123456"
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o o user logado e seu token</response>
        /// <response code="404">Retorna quando a dados invalidos</response>
        #endregion
        [HttpPost]
        [Route("login")]
        [ErrorsValidation]
        public async Task<IActionResult> AuthenticationUser([FromBody]LoginUserRequest command,
            [FromServices]IMediator handler)
        {
            try
            {
                LoginUserResponse response = await handler.Send(command);

                if (response.Success)
                    return Ok(response);
                else
                    return  BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest("");
            }
        }
    }
}

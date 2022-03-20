using Domain.Commands.Requests;
using Domain.Commands.Responses;
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
    [Route("users")]
    public class UserController : ControllerBase
    {
        #region swagger
        /// <summary>
        /// Realizar a criação de um usuario
        /// </summary>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     POST /User
        ///     {
        ///        "Name" : "João Victor Montenegro Rocha",
        ///        "Login" : "48957309055",
        ///        "Passworld" : "ASD@!sad2",
        ///        "Cpf": "48957309055",
        ///        "Email" : "joaos@gmail.com.br",
        ///        "BirthDay":"10/11/2010",
        ///        "Address" : {
        ///             "Street":"Teodoro de Castro",
        ///             "Neighborhood":"Granja Portugal",
        ///             "Number":"13621",
        ///             "City":"Fortaleza",
        ///             "State":"Ceara"
        ///         }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Retorna o usuario criado</response>
        /// <response code="404">Retorna quando a dados invalidos</response>
        #endregion
        [HttpPost]
        [Route("createUser")]
        [ErrorsValidation]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest command,
           [FromServices]IMediator handler)
        {
            try
            {
                CreateUserResponse response = await handler.Send(command);

                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        #region swagger
        /// <summary>
        /// Lista de usuarios criados.
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Lista de 0 a 10 usuarios por pagina</returns>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Retorna uma lista paginada de até 10 usuarios</response>
        /// <response code="401">Retorna quando foi realizado a autenticação</response>
        /// <response code="403">Retorna quando a autorização e negada</response>
        #endregion
        [HttpGet]
        [Route("getusers/{page:int}")]
        [Authorize(Roles ="Manager")]
        [ErrorsValidation]
        public async Task<IActionResult> GetAllUser(int page,
            [FromServices]IUserRepository userRepository )
        {
            try
            {
                var users = await userRepository.GetAllByPage(page);

                if (users is null)
                    return BadRequest("");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("");
            }
        }
    }
}

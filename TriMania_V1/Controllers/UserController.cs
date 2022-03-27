using Core.Interfaces;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
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
        /// || Só é acessado pelo ADMIN
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        /// 
        ///     {
        ///         "filter": "Victorr",
        ///         "numberPage": 0
        ///     }
        /// </remarks>
        /// <response code="200">Retorna uma lista paginada de até 10 usuarios de acordo com o filtro</response>
        /// <response code="401">Retorna quando foi realizado a autenticação</response>
        /// <response code="403">Retorna quando a autorização e negada</response>
        #endregion
        [HttpPost]
        [Route("getAllUsers")]
        [Authorize(Roles = "Manager")]
        [ErrorsValidation]
        public async Task<IActionResult> GetAllUsers([FromBody]GetAllUserRequest request,
            [FromServices] IUserRepositoryDP query)
        {
            try
            {
                var response = await query.GetUserByFilters(request.Filter, request.NumberPage);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiMsg.Error_Status_500);
            }
        }

        #region swagger
        /// <summary>
        /// Retorna um usário criado no sistema
        /// || O usário deve está logado 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <response code="200">Retorna o usuário</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        #endregion
        [HttpGet]
        [Route("getUserById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int id,
            [FromServices]IUserRepositoryDP query)
        {
            try
            {
                var userAuthorize = int.Parse(User.Identity.Name);

                if (!userAuthorize.Equals(id))
                    return BadRequest(ApiMsg.Authorize_Error_00001);

                var response = await query.GetById(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ApiMsg.Error_Status_500);
            }
        }


        #region swagger
        /// <summary>
        /// Deleta um usário do sistema
        /// || só é acessado pelo ADMIN
        /// </summary>
        /// <remarks>
        /// 
        /// request:
        ///
        ///     {
        ///         "userId": 2
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o usuário deletado</response>
        /// <response code="400">Retorno quando a alguma informação ou validação errada</response>
        /// <response code="401">Retorno quando não foi feito o login</response>
        /// <response code="403">Retorno quando a autorização foi negada</response>
        #endregion
        [HttpPost]
        [Route("deleteUser")]
        [Authorize(Roles = "Manager")]
        [ErrorsValidation]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest command,
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
                return BadRequest(ApiMsg.Error_Status_500);
            }
        }
    }
}

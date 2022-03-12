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
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("createUser")]
        [ErrorsValidation]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest command,
           [FromServices]IMediator handler)
        {
            try
            {
                CreateUserResponse response = await handler.Send(command);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

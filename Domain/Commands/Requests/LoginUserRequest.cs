using Domain.Commands.Responses;
using Domain.Language.API;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string Login { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string Passworld { get; set; }
    }
}

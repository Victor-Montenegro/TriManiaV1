using Domain.Commands.Responses;
using Domain.Language.API;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        public string Login { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        public string Passworld { get; set; }
    }
}

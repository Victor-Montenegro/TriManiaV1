using Domain.Commands.Responses;
using Domain.Language.API;
using Domain.Models;
using Domain.Validations;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string Name { get; set; }

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

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public string Cpf { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [EmailAddress(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public string Email { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [DateTimeValidation(DataType.Date, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public string BirthDay { get; set; }

        public AddressRequest Address { get; set; }

        public CreateUserRequest()
        {
            Address = new AddressRequest();
        }
    }
}

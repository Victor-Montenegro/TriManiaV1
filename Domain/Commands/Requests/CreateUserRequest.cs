using Domain.Commands.Responses;
using Domain.Language.TriManiaV1;
using Domain.Models;
using Domain.Validations;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0003")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0003")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(50, ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0003")]
        public string Passworld { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0001")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0004")]
        public string Cpf { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0001")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0004")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(UserMsg), ErrorMessageResourceName = "MSG0004")]
        [DateTimeValidation(DataType.Date)]
        public string BirthDay { get; set; }

        public AddressRequest Address { get; set; }

        public CreateUserRequest()
        {
            Address = new AddressRequest();
        }
    }
}

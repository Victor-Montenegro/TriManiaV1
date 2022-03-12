using Domain.Language.TriManiaV1;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class AddressRequest
    {
        [Required(ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0003")]
        public string Street { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0003")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(1, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0003")]
        public string Number { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0003")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0001")]
        [MinLength(5, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(AddressMsg), ErrorMessageResourceName = "MSG0003")]
        public string State { get; set; }
    }
}

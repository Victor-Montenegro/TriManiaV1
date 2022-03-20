using Domain.Language.API;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class AddressRequest
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string Street { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string Neighborhood { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string Number { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string City { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [MinLength(5, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00002")]
        [MaxLength(30, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00003")]
        #endregion
        public string State { get; set; }
    }
}

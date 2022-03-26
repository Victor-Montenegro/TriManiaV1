using Domain.Enums;
using Domain.Language.API;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OrderStatusRequest
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [EnumDataType(typeof(OrderStatus), ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public OrderStatus? status { get; set; }
    }
}

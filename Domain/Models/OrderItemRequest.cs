using Domain.Language.API;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OrderItemRequest
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(0,int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public int ProductId { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public int Quantity { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(0.1, double.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public decimal Price { get; set; }
    }
}

using Domain.Language.API;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ListRemoveOrderItemRequest
    {
       
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public int OrderItemId { get; set; }
    }
}

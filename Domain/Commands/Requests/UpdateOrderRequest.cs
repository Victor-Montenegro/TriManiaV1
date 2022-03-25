using Domain.Commands.Responses;
using Domain.Language.API;
using Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class UpdateOrderRequest : IRequest<UpdateOrderResponse>
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public int UserId { get; set; }

        public List<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();
    }
}

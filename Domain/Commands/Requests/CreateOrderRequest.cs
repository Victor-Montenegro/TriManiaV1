using Domain.Commands.Responses;
using Domain.Enums;
using Domain.Language.API;
using Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class CreateOrderRequest : IRequest<CreateOrderResponse>
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public int UserId { get; set; }

        //#region validações
        //[Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        //[EnumDataType(typeof(OrderStatus), ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        //#endregion
        //public OrderStatus? Status { get; set; }

        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [EnumDataType(typeof(PaymentType), ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public PaymentType? Type { get; set; }

        public List<OrderItemRequest> Items { get; set; } = new List<OrderItemRequest>();

    }
}

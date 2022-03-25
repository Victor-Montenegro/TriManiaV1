using Domain.Commands.Responses;
using Domain.Language.API;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Domain.Commands.Requests
{
    public class CancelledOrderRequest : IRequest<CancelledOrderResponse>
    {
        #region validações
        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00001")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "DataAnnotationError_00004")]
        #endregion
        public int UserId { get; set; }
    }
}

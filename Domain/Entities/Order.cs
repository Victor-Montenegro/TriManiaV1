using Domain.Entities.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalValue { get; private set; }
        public DateTime? CancelDate { get; private set; }
        public DateTime? FinishedDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public PaymentType? Type { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }

        public Order(int userId)
        {
            UserId = userId;
        }

        public void CancelledOrder()
        {
            CancelDate = DateTime.Now;
            Status = OrderStatus.Cancelled;
        }

        public void CalculateTotalOrder(List<OrderItem> items)
        {
            TotalValue = 0;
            foreach (var item in items)
                TotalValue += item.Price * item.Quantity;
        }

        public bool IsOrderCompleted()
        {
            if (!TotalValue.Equals(0) &&
                Type != null)
                return true;

            return false;
        }

        public void SetStatusOrder(OrderStatus status)
        {
            Status = status;
        }

        public void SetPaymentType(PaymentType type)
        {
            Type = type;
        }

        public void CompletedOrder()
        {
            Status = OrderStatus.Completed;
            FinishedDate = DateTime.Now;
        }
    }
}

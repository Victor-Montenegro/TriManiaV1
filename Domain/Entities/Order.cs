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
        public PaymentType Type { get; private set; }
        public User User { get; private set; }
        public int UserId { get; private set; }

        public Order(PaymentType type, int userId)
        {
            Type = type;
            UserId = userId;
        }

        public void CancelOrder()
        {
            CancelDate = DateTime.Now;
            Status = OrderStatus.Cancelled;
        }

        public void CalculateTotalOrder(List<OrderItem> items)
        {
            foreach (var item in items)
                TotalValue += item.Price * item.Quantity;
        }

        public bool IsOrderCompleted()
        {
            if (Status.Equals(OrderStatus.Completed) && 
                !TotalValue.Equals(0))
                return true;

            return false;
        }

        public bool IsOrderCancelled()
        {
            if (Status.Equals(OrderStatus.Cancelled))
                return true;

            return false;
        }

        public void SetStatusOrder(OrderStatus status)
        {
            Status = status;
        }
    }
}

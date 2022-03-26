using System;

namespace Core.Models
{
    public class OrderModel 
    {
        public int Id { get; set; }
        
        public DateTime CreateDate { get; set; }
        
        public decimal TotalValue { get;  set; }
        
        public DateTime? CancelDate { get; set; }
        
        public DateTime? FinishedDate { get; set; }
        
        public int Status { get; set; }

        public int Type { get; set; }

        public int UserId { get; set; }
    }
}

using System.Collections.Generic;

namespace Core.Models
{
    public class SalesReportModel
    {
        public int Finished_orders_amount { get; set; }

        public int Cancelled_orders_amount { get; set; }

        public decimal Orders_total_value { get; set; }

        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}

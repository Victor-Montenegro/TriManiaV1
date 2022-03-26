using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepositoryDP 
    {
        public Task<SalesReportModel> GetSalesReport(string initialDate, string finishDate, List<int> status, List<int> users);
    }
}

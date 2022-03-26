using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepositoryDP
    {
        public Task<IEnumerable<ProductModel>> GetAllProduts();
    }
}

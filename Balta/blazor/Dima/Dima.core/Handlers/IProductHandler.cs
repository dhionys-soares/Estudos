using Dima.core.Models;
using Dima.core.Requests.Orders;
using Dima.core.Responses;

namespace Dima.core.Handlers
{
    public interface IProductHandler
    {
        Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request);
        Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request);
    }
}

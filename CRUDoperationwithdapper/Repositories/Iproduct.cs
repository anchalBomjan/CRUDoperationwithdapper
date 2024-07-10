using CRUDoperationwithdapper.Models;

namespace CRUDoperationwithdapper.Repositories
{
    public interface Iproduct
    {
        Task<IEnumerable<ProductModel>> Get();
        Task<ProductModel> Find(Guid uid);
        Task<ProductModel> Add(ProductModel model);
        Task<ProductModel> Update( ProductModel model);
        Task<ProductModel> Remove(ProductModel model);
    }
}

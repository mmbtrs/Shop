using System.Linq;

namespace Shop.Web.Models
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}

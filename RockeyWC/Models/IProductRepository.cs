using System.Linq;

namespace PupMart.Models {

    public interface IProductRepository {

        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productID);
    }
}

using System.Collections.Generic;
using System.Linq;

namespace PupMart.Models {

    public class FakeProductRepository /*: IProductRepository */{

        public IQueryable<Product> Products => new List<Product> {
            new Product { Name = "Greyhound", Price = 150 },
            new Product { Name = "Mastiff", Price = 500 },
            new Product { Name = "Retriever", Price = 95 }
        }.AsQueryable<Product>();
    }
}

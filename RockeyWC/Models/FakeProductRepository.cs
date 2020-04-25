using System.Collections.Generic;
using System.Linq;

namespace RockeyWC.Models
{

    public class FakeProductRepository /*: IProductRepository*/
    {

        public IQueryable<Product> Products => new List<Product> {
            new Product { Name = "Hypo Clean", Price = 15,Description = "Spray to disinfect", Category = "Cleaning Supplies", IsRental = false, ForPurchase = true, AvailableQty = 1000 },
            new Product { Name = "Peabody-5000", Price = 100, Description = "Robotic power window washer", Category = "Robotic Washer", IsRental = true, ForPurchase = false, AvailableQty = 3 },
            new Product { Name = "Moose-Size T-shirt", Price = 36, Description = "Moose-size t-shirt repping RWC", Category = "Apparel", IsRental = false, ForPurchase = true, AvailableQty = 80 }
        }.AsQueryable<Product>();
    }
}

using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RockeyWC.Models
{
    public static class SeedData
    {
        // When called, this method migrates and populates the data with test(seed) data.
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Hypo Clean", Price = 15, Description = "Spray to disinfect", Category = "Cleaning Supplies", IsRental = false, ForPurchase = true, AvailableQty = 1000 },
                    new Product { Name = "Wax On, Wax Off", Price = 22, Description = "Focus & Discipline", Category = "Cleaning Supplies", IsRental = false, ForPurchase = true, AvailableQty = 800 },
                    new Product { Name = "Magic Eraser", Price = 5, Description = "Abra Kadabra Alakazam", Category = "Cleaning Supplies", IsRental = false, ForPurchase = true, AvailableQty = 2000 },
                    new Product { Name = "Peabody-5000", Price = 100, Description = "Robotic power window washer", Category = "Robotic Washer", IsRental = true, ForPurchase = false, AvailableQty = 3 },
                    new Product { Name = "Moose-Size T-shirt", Price = 36, Description = "Moose-size t-shirt repping RWC", Category = "Apparel", IsRental = false, ForPurchase = true, AvailableQty = 80 },
                    new Product { Name = "XL T-shirt", Price = 18, Description = "XL t-shirt repping RWC", Category = "Apparel", IsRental = false, ForPurchase = true, AvailableQty = 150 },
                    new Product { Name = "L T-shirt", Price = 15, Description = "Large t-shirt repping RWC", Category = "Apparel", IsRental = false, ForPurchase = true, AvailableQty = 200 },
                    new Product { Name = "M T-shirt", Price = 12, Description = "Medium t-shirt repping RWC", Category = "Apparel", IsRental = false, ForPurchase = true, AvailableQty = 250 },
                    new Product { Name = "S T-shirt", Price = 10, Description = "Small t-shirt repping RWC", Category = "Apparel", IsRental = false, ForPurchase = true, AvailableQty = 300 }
                );
                context.SaveChanges();
            }
        }
    }
}

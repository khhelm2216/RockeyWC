using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RockeyWC.Models {

    // Implementation of the IOrderRepository interface using EF Core, allows the set of Order objects that have been retrieved and allows
    // them to be created/changed.
    public class EFOrderRepository : IOrderRepository {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
                            .Include(o => o.Lines)
                            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order) {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0) {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}

using System.Linq;

namespace PupMart.Models {

    // Provides access to order objects
    public interface IOrderRepository {

        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}

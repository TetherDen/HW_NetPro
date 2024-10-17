using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_Server
{
    public enum OrderStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }
    public class Order
    {
        public int Id { get; }
        private static int counter = 0;
        public List<Dish> Dishes { get; set; } = new();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public TimeSpan EstimatedTime { get; set; }
        public Order(params Dish[] dishes)
        {
            Id = ++counter;
            this.Dishes.AddRange(dishes);
        }
    }
}

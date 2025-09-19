// 代码生成时间: 2025-09-19 23:33:25
using System;
using System.Collections.Generic;

namespace OrderProcessing
{
    /// <summary>
    /// Represents the state of an order.
    /// </summary>
    public enum OrderStatus
    {
        Pending,
        Approved,
        Shipped,
        Delivered,
        Cancelled
    }

    /// <summary>
    /// Represents an order with properties and methods to process it.
    /// </summary>
    public class Order
    {
        public int OrderId { get; private set; }
        public List<string> Items { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(int orderId, List<string> items)
        {
            OrderId = orderId;
            Items = items;
            Status = OrderStatus.Pending;
        }

        /// <summary>
        /// Process the order to the next status.
        /// </summary>
        /// <param name="nextStatus">The next status of the order.</param>
        public void ProcessNextStatus(OrderStatus nextStatus)
        {
            if (Status == OrderStatus.Cancelled)
            {
                throw new InvalidOperationException("Order cannot be processed further once cancelled.");
            }

            Status = nextStatus;
            Console.WriteLine($"Order {OrderId} has been processed to {Status} status.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create an order with sample items.
                List<string> items = new List<string> { "Item1", "Item2", "Item3" };
                Order order = new Order(1, items);

                // Process the order through its lifecycle.
                order.ProcessNextStatus(OrderStatus.Approved);
                order.ProcessNextStatus(OrderStatus.Shipped);
                order.ProcessNextStatus(OrderStatus.Delivered);

                // Uncomment the line below to simulate an order cancellation.
                // order.ProcessNextStatus(OrderStatus.Cancelled);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
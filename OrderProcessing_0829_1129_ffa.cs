// 代码生成时间: 2025-08-29 11:29:35
using System;
using System.Collections.Generic;

// 订单状态枚举
public enum OrderStatus {
    Created,
    Confirmed,
    Shipped,
    Delivered,
    Cancelled
}

// 订单类
public class Order {
    public int OrderId { get; set; }
    public List<string> Products { get; set; } = new List<string>();
    public OrderStatus Status { get; set; } = OrderStatus.Created;

    public void AddProduct(string product) {
        Products.Add(product);
    }

    public void ConfirmOrder() {
        if (Status == OrderStatus.Created) {
            Status = OrderStatus.Confirmed;
        } else {
            throw new InvalidOperationException("Order must be in 'Created' status to be confirmed.");
        }
    }

    public void ShipOrder() {
        if (Status == OrderStatus.Confirmed) {
            Status = OrderStatus.Shipped;
        } else {
            throw new InvalidOperationException("Order must be in 'Confirmed' status to be shipped.");
        }
    }

    public void DeliverOrder() {
        if (Status == OrderStatus.Shipped) {
            Status = OrderStatus.Delivered;
        } else {
            throw new InvalidOperationException("Order must be in 'Shipped' status to be delivered.");
        }
    }

    public void CancelOrder() {
        if (Status != OrderStatus.Delivered) {
            Status = OrderStatus.Cancelled;
        } else {
            throw new InvalidOperationException("Order cannot be cancelled once delivered.");
        }
    }
}

class Program {
    static void Main(string[] args) {
        try {
            // 创建一个新的订单
            Order order = new Order { OrderId = 1 };
            order.AddProduct("Product 1");
            order.AddProduct("Product 2");

            // 确认订单
            order.ConfirmOrder();

            // 处理订单
            order.ShipOrder();
            order.DeliverOrder();

            // 输出订单状态
            Console.WriteLine($"Order {order.OrderId} status is {order.Status}");

        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
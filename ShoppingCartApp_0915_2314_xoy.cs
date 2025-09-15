// 代码生成时间: 2025-09-15 23:14:12
using System;
using System.Collections.Generic;
using System.Linq;

// 定义一个购物车项目
public class CartItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

// 购物车类，提供添加、移除商品和计算总金额等功能
public class ShoppingCart
{
    private readonly List<CartItem> _items = new List<CartItem>();

    // 添加商品到购物车
    public void AddItem(string productId, string productName, decimal price, int quantity)
    {
        // 检查商品是否已存在
        var existingItem = _items.FirstOrDefault(item => item.ProductId == productId);
        if (existingItem != null)
        {
            // 如果商品已存在，增加其数量
            existingItem.Quantity += quantity;
        }
        else
        {
            // 如果商品不存在，添加新商品到购物车
            _items.Add(new CartItem {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                Quantity = quantity
            });
        }
    }

    // 从购物车中移除商品
    public void RemoveItem(string productId)
    {
        var itemToRemove = _items.FirstOrDefault(item => item.ProductId == productId);
        if (itemToRemove != null)
        {
            _items.Remove(itemToRemove);
        }
        else
        {
            throw new InvalidOperationException($"No item with product ID {productId} found in the cart.");
        }
    }

    // 计算购物车中所有商品的总金额
    public decimal CalculateTotal()
    {
        return _items.Sum(item => item.Price * item.Quantity);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        try
        {
            // 添加商品到购物车
            cart.AddItem("001", "Apple", 0.99m, 2);
            cart.AddItem("002", "Banana", 0.49m, 3);
            cart.AddItem("001", "Apple", 0.99m, 1); // 增加Apple的数量

            // 计算总金额
            decimal total = cart.CalculateTotal();
            Console.WriteLine($"Total cost of cart: ${total:0.00}");

            // 移除商品
            cart.RemoveItem("002");

            // 再次计算总金额
            total = cart.CalculateTotal();
            Console.WriteLine($"Total cost of cart after removal: ${total:0.00}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
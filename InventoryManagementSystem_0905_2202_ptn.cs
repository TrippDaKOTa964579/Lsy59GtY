// 代码生成时间: 2025-09-05 22:02:46
using System;
using System.Collections.Generic;
using System.Linq;

// 定义库存项类，用于存储库存项目的详细信息
public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

// 库存管理系统类
public class InventoryManagementSystem
{
    private List<InventoryItem> items;

    // 构造函数，初始化库存列表
    public InventoryManagementSystem()
    {
        items = new List<InventoryItem>();
    }

    // 添加库存项
    public void AddItem(InventoryItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        items.Add(item);
    }

    // 删除库存项
    public void RemoveItem(int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
            items.Remove(item);
        else
            throw new KeyNotFoundException($"Item with id {id} not found.");
    }

    // 更新库存项数量
    public void UpdateQuantity(int id, int newQuantity)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            item.Quantity = newQuantity;
        }
        else
            throw new KeyNotFoundException($"Item with id {id} not found.");
    }

    // 获取库存项
    public InventoryItem GetItem(int id)
    {
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
            return item;
        else
            throw new KeyNotFoundException($"Item with id {id} not found.");
    }

    // 获取所有库存项
    public IEnumerable<InventoryItem> GetAllItems()
    {
        return items;
    }
}

// 程序入口点类
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inventory = new InventoryManagementSystem();
            inventory.AddItem(new InventoryItem { Id = 1, Name = "Apple", Quantity = 100 });
            inventory.AddItem(new InventoryItem { Id = 2, Name = "Banana", Quantity = 150 });

            Console.WriteLine("Initial inventory: ");
            foreach (var item in inventory.GetAllItems())
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");

            inventory.UpdateQuantity(1, 90);
            Console.WriteLine("
After update: ");
            foreach (var item in inventory.GetAllItems())
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
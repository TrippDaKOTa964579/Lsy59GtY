// 代码生成时间: 2025-08-22 01:30:09
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// A simple message notification system using C# and .NET.
/// </summary>
public class MessageNotificationSystem
{
    private List<INotificationService> notificationServices;

    /// <summary>
    /// Constructor for the MessageNotificationSystem class.
    /// </summary>
    public MessageNotificationSystem()
    {
        notificationServices = new List<INotificationService>();
    }

    /// <summary>
    /// Adds a notification service to the system.
    /// </summary>
    /// <param name="service">The notification service to be added.</param>
    public void AddNotificationService(INotificationService service)
    {
        if (service == null)
        {
            throw new ArgumentNullException(nameof(service), "Notification service cannot be null.");
        }

        notificationServices.Add(service);
    }

    /// <summary>
    /// Sends a message to all registered notification services.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    public async Task SendMessageAsync(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        foreach (var service in notificationServices)
        {
            try
            {
                await service.SendNotificationAsync(message);
            }
            catch (Exception ex)
            {
                // Handle exceptions related to individual notification services
                Console.WriteLine($"Error sending message via {service.GetType().Name}: {ex.Message}");
            }
        }
    }
}

/// <summary>
/// Interface for notification services.
/// </summary>
public interface INotificationService
{
    Task SendNotificationAsync(string message);
}

/// <summary>
/// A sample implementation of the INotificationService for email notifications.
/// </summary>
public class EmailNotificationService : INotificationService
{
    /// <summary>
    /// Sends an email notification.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    public async Task SendNotificationAsync(string message)
    {
        // Simulate sending an email
        Console.WriteLine($"Sending email: {message}");
        await Task.Delay(1000); // Simulate a delay
    }
}

/// <summary>
/// A sample implementation of the INotificationService for SMS notifications.
/// </summary>
public class SMSNotificationService : INotificationService
{
    /// <summary>
    /// Sends an SMS notification.
    /// </summary>
    /// <param name="message">The message to be sent.</param>
    public async Task SendNotificationAsync(string message)
    {
        // Simulate sending an SMS
        Console.WriteLine($"Sending SMS: {message}");
        await Task.Delay(1000); // Simulate a delay
    }
}
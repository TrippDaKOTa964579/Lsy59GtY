// 代码生成时间: 2025-08-24 18:36:11
using System;
using System.Collections.Generic;

namespace MessageNotificationSystem
{
    public class NotificationService
    {
        private readonly List<INotification> _subscribers;

        public NotificationService()
        {
            _subscribers = new List<INotification>();
        }

        // 注册通知接收者
        public void RegisterSubscriber(INotification subscriber)
        {
            if (subscriber == null)
            {
                throw new ArgumentNullException(nameof(subscriber), "Subscriber cannot be null.");
            }

            _subscribers.Add(subscriber);
        }

        // 发送通知消息
        public void Notify(string message)
        {
            foreach (var subscriber in _subscribers)
            {
                try
                {
                    subscriber.Receive(message);
                }
                catch (Exception ex)
                {
                    // 错误处理，记录异常信息
                    Console.WriteLine($"Error notifying subscriber: {ex.Message}");
                }
            }
        }
    }

    // 通知接口
    public interface INotification
    {
        void Receive(string message);
    }

    // 示例通知接收者
    public class EmailNotification : INotification
    {
        public void Receive(string message)
        {
            Console.WriteLine($"Email sent with message: {message}");
        }
    }

    // 主程序
    public class Program
    {
        public static void Main(string[] args)
        {
            var notificationService = new NotificationService();

            // 注册通知接收者
            notificationService.RegisterSubscriber(new EmailNotification());

            // 发送通知
            notificationService.Notify("Hello, this is a test notification!");
        }
    }
}
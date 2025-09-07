// 代码生成时间: 2025-09-07 14:14:43
using System;

namespace MessageNotificationSystem
{
    // 消息通知接口，定义消息发送的方法
    public interface IMessageSender
    {
        void SendMessage(string message);
    }

    // EmailSender 类实现 IMessageSender 接口，用于发送电子邮件通知
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            // 模拟发送电子邮件的过程
            Console.WriteLine($"Sending email with message: {message}");
            // 在实际应用中，这里将包含发送电子邮件的代码
        }
    }

    // SmsSender 类实现 IMessageSender 接口，用于发送短信通知
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            // 模拟发送短信的过程
            Console.WriteLine($"Sending SMS with message: {message}");
            // 在实际应用中，这里将包含发送短信的代码
        }
    }

    // NotificationService 类负责管理消息发送者，并向它们发送消息
    public class NotificationService
    {
        private IMessageSender _messageSender;

        public NotificationService(IMessageSender messageSender)
        {
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public void Notify(string message)
        {
            try
            {
                _messageSender.SendMessage(message);
            }
            catch (Exception ex)
            {
                // 处理消息发送中的错误
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建消息发送者实例
            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SmsSender();

            // 创建通知服务实例，并使用电子邮件发送者
            NotificationService emailNotificationService = new NotificationService(emailSender);
            // 创建通知服务实例，并使用短信发送者
            NotificationService smsNotificationService = new NotificationService(smsSender);

            // 发送通知
            emailNotificationService.Notify("Hello, this is an email notification!");
            smsNotificationService.Notify("Hello, this is an SMS notification!");
        }
    }
}
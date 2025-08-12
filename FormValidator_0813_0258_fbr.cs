// 代码生成时间: 2025-08-13 02:58:13
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 表单数据验证器类
public class FormValidator
{
    // 对象模型，用于存放表单数据
    public class FormData
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be 100 characters or less")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int Age { get; set; }
    }

    // 验证表单数据的方法
    public List<string> ValidateFormData(FormData formData)
    {
        // 创建验证上下文
        var context = new ValidationContext(formData);

        // 创建验证结果列表
        var validationResults = new List<ValidationResult>();

        // 尝试验证数据
        bool isValid = Validator.TryValidateObject(formData, context, validationResults, true);

        // 将验证结果转换成错误消息列表
        List<string> errorMessages = new List<string>();
        foreach (var validationResult in validationResults)
        {
            errorMessages.Add(validationResult.ErrorMessage);
        }

        // 返回错误消息列表
        return errorMessages;
    }
}

// 使用示例
public class Program
{
    public static void Main()
    {
        FormValidator validator = new FormValidator();
        FormValidator.FormData formData = new FormValidator.FormData
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Age = 25
        };

        List<string> errors = validator.ValidateFormData(formData);

        if (errors.Count == 0)
        {
            Console.WriteLine("Form data is valid.");
        }
        else
        {
            Console.WriteLine("Form data is invalid. Please see the errors below: 
");
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}
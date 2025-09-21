// 代码生成时间: 2025-09-22 03:38:41
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataValidation
{
    public class FormDataValidator
    {
        // 验证表单数据
        public bool ValidateForm(List<ValidationResult> validationResults)
        {
            bool isValid = true;
            foreach (var validationResult in validationResults)
            {
                if (!validationResult.IsValid)
                {
                    isValid = false;
                    // 可以在这里记录日志或执行其他错误处理操作
                    Console.WriteLine($"Validation error: {validationResult.ErrorMessage}");
                }
            }
            return isValid;
        }

        // 验证电子邮件地址
        private bool ValidateEmail(string email)
        {
            try
            {
                // 使用正则表达式验证电子邮件格式
                var emailRegex = "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                return System.Text.RegularExpressions.Regex.IsMatch(email, emailRegex);
            }
            catch (Exception ex)
            {
                // 记录异常信息
                Console.WriteLine($"Error validating email: {ex.Message}");
                return false;
            }
        }

        // 验证密码强度
        private bool ValidatePassword(string password)
        {
            // 密码至少8个字符，包含大写字母、小写字母和数字
            bool hasUpperCase = password.Length >= 8 && password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            return hasUpperCase && hasLowerCase && hasDigit;
        }

        // 示例：验证一个包含电子邮件和密码的表单
        public void ValidateSampleForm(string email, string password)
        {
            var validationResults = new List<ValidationResult>();

            // 验证电子邮件
            if (!ValidateEmail(email))
            {
                validationResults.Add(new ValidationResult("Invalid email format."));
            }

            // 验证密码强度
            if (!ValidatePassword(password))
            {
                validationResults.Add(new ValidationResult("Password must be at least 8 characters long and include uppercase, lowercase, and digits."));
            }

            // 执行表单验证
            if (!ValidateForm(validationResults))
            {
                throw new Exception("Form validation failed.");
            }
            else
            {
                Console.WriteLine("Form validation succeeded.");
            }
        }
    }
}

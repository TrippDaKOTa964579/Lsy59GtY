// 代码生成时间: 2025-08-02 03:42:32
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FormDataValidation
{
    public class FormDataValidator
    {
        /// <summary>
        /// Validates the given form data.
        /// </summary>
        /// <param name="formData">The form data to validate.</param>
        /// <returns>A list of validation errors, or an empty list if validation passes.</returns>
        public List<string> ValidateData(object formData)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(formData, serviceProvider: null, items: null);
            
            bool isValid = Validator.TryValidateObject(formData, context, results, true);
            
            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        results.Add($"Error in {memberName}: {validationResult.ErrorMessage}");
                    }
                }
            }
            
            return results.ConvertAll(r => r.ErrorMessage);
        }
    }

    public class FormData
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }
    }
}

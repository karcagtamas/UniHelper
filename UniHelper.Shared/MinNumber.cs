using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared
{
    /// <summary>
    /// Check number is not smaller than min number
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MinNumberAttribute : ValidationAttribute
    {
        private int MinValue { get; set; }

        private const string Message = "Number has to be bigger than: ";

        /// <summary>
        /// Init attribute
        /// </summary>
        /// <param name="minValue">Min value - inclusive</param>
        public MinNumberAttribute(int minValue)
        {
            MinValue = minValue;
        }

        /// <summary>
        /// Number attribute is valid
        /// </summary>
        /// <param name="value">Current value</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var val = (int?) value;

            if (val == null)
            {
                return ValidationResult.Success;
            }

            return val >= MinValue ? ValidationResult.Success : new ValidationResult($"{Message} {MinValue}");
        }
    }
}
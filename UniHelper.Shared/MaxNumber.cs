using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared
{
    /// <summary>
    /// Check number is not bigger than max number
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxNumberAttribute : ValidationAttribute
    {
        private int MaxValue { get; set; }

        private const string Message = "Number has to be smaller than: ";

        /// <summary>
        /// Init attribute
        /// </summary>
        /// <param name="maxValue">Max value - inclusive</param>
        public MaxNumberAttribute(int maxValue)
        {
            MaxValue = maxValue;
        }

        /// <summary>
        /// Number attribute is valid
        /// </summary>
        /// <param name="value">Current value</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var val = (long?) value;

            if (val == null)
            {
                return ValidationResult.Success;
            }

            return val <= MaxValue ? ValidationResult.Success : new ValidationResult($"{Message} {MaxValue}");
        }
    }
}
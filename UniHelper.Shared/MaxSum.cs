using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared
{
    /// <summary>
    /// Check number and other property summary is smaller than maximum
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxSumAttribute : ValidationAttribute
    {
        private int MaxSum { get; set; }
        private string OtherProperty { get; set; }

        private const string Message = "Summary has to be smaller than: ";

        /// <summary>
        /// Init attribute
        /// </summary>
        /// <param name="maxSum">Max summary - inclusive</param>
        /// <param name="otherProperty">Other property</param>
        public MaxSumAttribute(int maxSum, string otherProperty)
        {
            MaxSum = maxSum;
            OtherProperty = otherProperty;
        }

        /// <summary>
        /// Sum attribute is valid
        /// </summary>
        /// <param name="value">Current value</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var val = (long?) value;
            var other = (long?) validationContext.ObjectType.GetProperty(OtherProperty)
                ?.GetValue(validationContext.ObjectInstance, null);

            val ??= 0;
            other ??= 0;

            return val + other <= MaxSum ? ValidationResult.Success : new ValidationResult($"{Message} {MaxSum}");
        }
    }
}
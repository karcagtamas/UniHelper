using System;
using System.ComponentModel.DataAnnotations;

namespace UniHelper.Shared
{
    /// <summary>
    /// Check date is after an other property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DateAfterAttribute : ValidationAttribute
    {
        private string CompareFieldName { get; set; }

        private const string Message = "Date has to be greater than other field.";

        /// <summary>
        /// Init attribute
        /// </summary>
        /// <param name="compareFieldName">Other field's name</param>
        public DateAfterAttribute(string compareFieldName)
        {
            CompareFieldName = compareFieldName;
        }

        /// <summary>
        /// Date attribute is valid
        /// </summary>
        /// <param name="value">Current value</param>
        /// <param name="validationContext">Context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var current = (DateTime?) value;

            var before = (DateTime?) validationContext.ObjectType.GetProperty(CompareFieldName)
                ?.GetValue(validationContext.ObjectInstance, null);

            if (current == null && before == null)
            {
                return ValidationResult.Success;
            }

            if (current == null)
            {
                return new ValidationResult(Message);
            }

            if (before == null)
            {
                return ValidationResult.Success;
            }

            return current > before ? ValidationResult.Success : new ValidationResult(Message);
        }
    }
}
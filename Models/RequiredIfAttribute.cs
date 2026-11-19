using System.ComponentModel.DataAnnotations;

namespace VideoGameLibrary.Components.Models
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private string PropertyName { get; }
        private object IsValue { get; }

        public RequiredIfAttribute(string propertyName, object isValue)
        {
            PropertyName = propertyName;
            IsValue = isValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(PropertyName);
            if (property == null) 
                return new ValidationResult($"Unknown property: {PropertyName}");

            var propertyValue = property.GetValue(validationContext.ObjectInstance);

            if (Equals(propertyValue, IsValue))
            {
                if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}

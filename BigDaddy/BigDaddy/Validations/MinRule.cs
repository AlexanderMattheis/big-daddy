using BigDaddy.Core;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace BigDaddy
{
    public class MinRule : ValidationRule
    {
        public int Min { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool successful = int.TryParse(value.ToString(), out int numberValue);

            if (!successful)
            {
                return new ValidationResult(false, Strings.ValidationError_ValueNotNumerical);
            }

            if (numberValue < Min)
            {
                return new ValidationResult(false, Strings.ValidationError_ValueLowerMinimum + $" {Min}.");
            }

            return ValidationResult.ValidResult;
        }
    }
}

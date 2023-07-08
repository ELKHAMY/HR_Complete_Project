using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;

public class AtLeast20YearsAgoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Null values are considered valid
        }

        if (!(value is DateTime))
        {
            return new ValidationResult("Value must be a DateTime object");
        }

        DateTime date = (DateTime)value;
        DateTime today = DateTime.Today;
        int age = today.Year - date.Year;

        // Subtract a year if the birthday hasn't occurred yet this year
        if (date > today.AddYears(-age))
        {
            age--;
        }

        if (age < 20)
        {
            return new ValidationResult("Age must be at least 20 years");
        }

        return ValidationResult.Success;
    }
}
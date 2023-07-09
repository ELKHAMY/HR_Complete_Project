using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;

public class After2008Attribute : ValidationAttribute
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
        DateTime year2008 = new DateTime(2008, 1, 1);

        if (date < year2008)
        {
            return new ValidationResult("Date must be after 2008");
        }

        return ValidationResult.Success;
    }
}
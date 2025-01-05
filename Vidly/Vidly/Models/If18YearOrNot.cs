using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class If18YearOrNot : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unkown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;

            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");

            }
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old");
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Validator
{
    public class CreditCardValidator : ValidationAttribute
    {
        public CreditCardValidator()
           : base("{0} não é um cartão correto!")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            long valor = 0;

            if (long.TryParse(value.ToString(), out valor))
            {
                if (12 > valor.ToString().Length || valor.ToString().Length > 16)
                {
                    return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
             , new string[] { validationContext.MemberName });
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }
    }
}

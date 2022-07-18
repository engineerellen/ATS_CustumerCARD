using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Validator
{
    public class CVVValidator : ValidationAttribute
    {
        public CVVValidator()
           : base("{0} não é um CVV correto!")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int valor = 0;

            if (int.TryParse(value.ToString(), out valor))
            {
                if (1 > valor.ToString().Length || valor.ToString().Length > 5)
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

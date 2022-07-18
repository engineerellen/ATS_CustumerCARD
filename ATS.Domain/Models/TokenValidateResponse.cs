using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;

namespace ATS.Domain.Models
{
    public class TokenValidateResponse
    {

        public long CardNumber { get; set; }

        public bool Return { get; set; }
    }
}

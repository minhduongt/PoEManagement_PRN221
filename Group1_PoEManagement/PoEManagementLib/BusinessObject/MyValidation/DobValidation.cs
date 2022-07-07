using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.BusinessObject.MyValidation
{
    public class DobValidation : ValidationAttribute
    {
        public DobValidation()
        {
            ErrorMessage = "Valid age is between 20 and 65";
        }

        public override bool IsValid(object value)
        {
            int currentyear = DateTime.Now.Year;
            if (value == null) return false;
            DateTime dateinput = DateTime.Parse(value.ToString());
            if (dateinput.Year - currentyear < 20 || dateinput.Year - currentyear > 65) return false;
            return true;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.BusinessObject.MyValidation
{
    public class DayRequestValid : ValidationAttribute
    {
        public DayRequestValid()
        {
            ErrorMessage = "Day OT can not in the past";
        }

        public override bool IsValid(object value)
        {
            DateTime currentdate = DateTime.Now;
            if (value == null) return false;
            DateTime dateinput = DateTime.Parse(value.ToString());
            if (dateinput<currentdate) return false;
            return true;

        }
    }
}

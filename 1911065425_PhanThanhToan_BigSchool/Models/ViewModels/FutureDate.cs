using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace _1911065425_PhanThanhToan_BigSchool.Models.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValud = DateTime.TryParseExact(Convert.ToString(value),
                                                "M/dd/yyyy",
                                                CultureInfo.CurrentCulture,
                                                DateTimeStyles.None,
                                                out dateTime);

            return (isValud && dateTime > DateTime.Now);
        }
    }
}
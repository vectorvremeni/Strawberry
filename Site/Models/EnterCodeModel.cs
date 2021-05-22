using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class EnterCodeModel
    {
        public int? Code { get; set; }
        public String Message { get; set; }
        public bool? Status { get; set; }

        public static bool? StatusOK = true;
        public static bool? StatusError = false;
        public static bool? StatusUndefined = null;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Services
{
    public class CodeGenerator
    {
        Random r = new Random(DateTime.Now.Millisecond);
        public int Code { get; set; }
        public DateTime GenTime { get; set; }

        public int GenCode()
        {
            GenTime = DateTime.Now;
            Code = r.Next(10000, 100000);
            return Code;
        }
    }
}

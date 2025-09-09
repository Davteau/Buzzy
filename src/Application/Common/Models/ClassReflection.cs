using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ClassReflection
    {
        [MyAttribute]
        public string? Property { get; set; }

        [MyAttribute]
        public int AnotherProperty { get; set; }

        [My]
        public DateTime DateProperty { get; set; }

        [My]
        public string? ThirdProperty { get; set; }
        public int NoAttributeProperty { get; set; }
    }
}

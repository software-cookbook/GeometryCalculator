using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCalculator
{

    public class GeometryInfoConfig
    {
        public Shape[] shapes { get; set; }
    }

    public class Shape
    {
        public string name { get; set; }
        public string[] parameters { get; set; }
        public string areaFormula { get; set; }
    }
}

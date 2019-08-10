using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame_WPF
{
    class ValueRestricted
    {
        public double Min { set; get; }
        public double Max { get; set; }

        public ValueRestricted() : this(0, 0)
        {

        }

        public ValueRestricted(double min, double max)
        {
            Min = min;
            Max = max;
        }
    }
}

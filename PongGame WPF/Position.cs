using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame_WPF
{
    class Position
    {
        private double _X;
        private double _Y;

        public double X
        {
            set
            {
                _X = value;
                if (RestrictX != null)
                {
                    if (value < RestrictX.Min)
                        _X = RestrictX.Min;
                    else if (value > RestrictX.Max)
                        _X = RestrictX.Max;
                }
            }
            get
            {
                return _X;
            }
        }
        public double Y
        {
            set
            {
                _Y = value;
                if (RestrictY != null)
                {
                    if (value < RestrictY.Min)
                        _Y = RestrictY.Min;
                    else if (value > RestrictY.Max)
                        _Y = RestrictY.Max;
                }
            }
            get
            {
                return _Y;
            }
        }
        // RestrictX and RestrictY can be null, indicate that X and Y's values are not restricted
        public ValueRestricted RestrictX { get; set; }
        public ValueRestricted RestrictY { get; set; }

        public Position()
        {
            X = 0;
            Y = 0;
        }

        public Position(ValueRestricted restrictedX, ValueRestricted restrictedY) : this()
        {
            RestrictX = restrictedX;
            RestrictY = restrictedY;
        }

        public void AddYRestrict(ValueRestricted newRestricted)
        {
            RestrictY = newRestricted;
        }

        public void AddXRestrict(ValueRestricted newRestricted)
        {
            RestrictX = newRestricted;
        }

        public void AddYRestrict(double min, double max)
        {
            RestrictY = new ValueRestricted(min, max);
        }

        public void AddXRestrict(double min, double max)
        {
            RestrictX = new ValueRestricted(min, max);
        }

        internal bool AtXMin()
        {
            return (X == RestrictX.Min);
        }

        internal bool AtXMax()
        {
            return (X == RestrictX.Max);
        }

        internal bool AtYMin()
        {
            return (Y == RestrictY.Min);
        }

        internal bool AtYMax()
        {
            return (Y == RestrictY.Max);
        }

        internal bool AtTheEdge()
        {
            return (AtXMin() || AtXMax() || AtYMin() || AtYMax());
        }
    }
}

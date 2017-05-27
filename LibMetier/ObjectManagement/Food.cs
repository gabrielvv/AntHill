using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.ObjectManagement
{
    class Food : AHObject
    {
        public int FoodUnit { get; set; }

        // weight is proportional to FoodUnit
        public Food(int unit) : base(unit)
        {
            this.FoodUnit = unit;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.ObjectManagement
{
    class Food : AHObject
    {
        private static Random rdm = new Random();
        private static int FUMax = 100;

        public int FoodUnit { get; set; }

        // weight is proportional to FoodUnit
        public Food(int unit) : base(unit, "Food")
        {
            this.FoodUnit = unit;
        }

        public Food() : this(rdm.Next(FUMax)+1)
        {
            
        }
    }
}

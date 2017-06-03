using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.EnvironmentManagement;

namespace LibMetier.CharacterManagement
{
    
    class Male : Ant
    {
        private static int Counter = 0;
        public static int getCount()
        {
            return Counter;
        }

        public Male(int life, int carriedFood, string name = "Male", AbstractZone position = null) : base(life, carriedFood, name + Counter++, position)
        {
        }

        ~Male()
        {
            Counter--;
        }
    }
}

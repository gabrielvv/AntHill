using LibAbstract.EnvironmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.CharacterManagement
{
    class Fighter : Ant
    {
        private static int Counter = 0;
        public static int getCount()
        {
            return Counter;
        }

        public Fighter(int life, int carriedFood, string name = "Fighter", AbstractZone position = null) : base(life, carriedFood, name + Counter++, position)
        {
        }

        ~Fighter()
        {
            Counter--;
        }
    }
}

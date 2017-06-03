using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.EnvironmentManagement;

namespace LibMetier.CharacterManagement
{
    class Worker : Ant
    {
        private static int Counter = 0;
        public static new int getCount()
        {
            return Counter;
        }

        public Worker(int life, int carriedFood, string name = "Worker", AbstractZone position = null) : base(life, carriedFood, name + Counter++, position)
        {
        }

        ~Worker()
        {
            Counter--;
        }
    }
}

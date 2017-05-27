using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier.EnvironmentManagement;
using LibMetier.Factory;
using LibAbstract.EnvironmentManagement;

namespace SimulationFourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {

            AHFactory Factory = new AHFactory();
            AbstractEnvironment Env = Factory.CreateEnvironment();

            Env.LoadEnvironment(Factory);
            Env.LoadObjects(Factory);
            Env.LoadCharacters(Factory);
            Env.Simulate();

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.CharacterManagement;
using LibAbstract.EnvironmentManagement;
using LibAbstract.ObjectManagement;
using LibMetier.EnvironmentManagement;
using LibMetier.ObjectManagement;
using LibMetier.CharacterManagement;

namespace LibMetier.Factory
{
    public class AHFactory : LibAbstract.Factory.AbstractFactory
    {

        private static Random rdm = new Random();

        public AHFactory(string title="Ant Hill Factory") : base(title)
        {

        }

        public override AbstractAccess CreateAccess(AbstractZone zdebut, AbstractZone zfin)
        {
            return new Path(zdebut, zfin);
        }

        public override AbstractCharacter CreateCharacter(string name)
        {
            int life = rdm.Next(10, 100);
            switch (name)
            {
                case "Male":
                    return new Male(life, 0);
                    break;
                case "Mother":
                    return new Mother(life, 0);
                    break;
                case "Queen":
                    return new Queen(life, 0);
                    break;
                case "Worker":
                    return new Worker(life, 0);
                    break;
                case "Fighter":
                    return new Fighter(life, 0);
                    break;
                default:
                    return new Ant(life, 0);
                    break;
            }
        }

        public override AbstractEnvironment CreateEnvironment()
        {
            AHEnvironment Env = new AHEnvironment(5, 5); // 400 cases
            //Env.LoadEnvironment(this);
            return Env;
        }

        public override AbstractObject CreateObject(string name)
        {
            AHObject o = null;
            switch(rdm.Next(4)){
                case 0:
                    o = new Egg();
                    break;
                case 1:
                    o = new Food();
                    break;
                case 2:
                    o = new Pheromone();
                    break;
                case 3:
                    o = new AHObject(25, "foo");
                    break;
                default:
                    o = new AHObject(58, "bar");
                    break;
            }

            return o;
        }

        public override AbstractZone CreateZone(int x, int y, string name)
        {
            return new AHZone(x, y, name);
        }

        //public override AbstractZone CreateZone(string name)
        //{
        //    return new AHZone(-1, -1, name);
        //}
    }
}

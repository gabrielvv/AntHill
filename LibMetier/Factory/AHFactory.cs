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

        public AHFactory(string title="Ant Hill Factory") : base(title)
        {

        }

        public override AbstractAccess CreateAccess(AbstractZone zdebut, AbstractZone zfin)
        {
            return new Path(zdebut, zfin);
        }

        public override AbstractCharacter CreateCharacter(string name)
        {
            // TODO => randomize ant creation
            return new Ant(10, 0, name);
        }

        public override AbstractEnvironment CreateEnvironment()
        {
            AHEnvironment Env = new AHEnvironment(20, 20);
            //Env.LoadEnvironment(this);
            return Env;
        }

        public override AbstractObject CreateObject(string name)
        {
            // TODO => randomize object creation
            return new AHObject(10);
        }

        public override AbstractZone CreateZone(string name)
        {
            return new AHZone(name);
        }
    }
}

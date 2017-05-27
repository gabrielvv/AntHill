using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.CharacterManagement;
using LibAbstract.EnvironmentManagement;
using LibAbstract.ObjectManagement;

namespace LibMetier.Factory
{
    class XMLFactory : LibAbstract.Factory.AbstractFactory
    {
        public override AbstractAccess CreateAccess(AbstractZone zdebut, AbstractZone zfin)
        {
            throw new NotImplementedException();
        }

        public override AbstractCharacter CreateCharacter(string name)
        {
            throw new NotImplementedException();
        }

        public override AbstractEnvironment CreateEnvironment()
        {
            throw new NotImplementedException();
        }

        public override AbstractObject CreateObject(string name)
        {
            throw new NotImplementedException();
        }

        public override AbstractZone CreateZone(string name)
        {
            throw new NotImplementedException();
        }
    }
}

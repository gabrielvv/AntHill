using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.EnvironmentManagement;
using LibAbstract.ObjectManagement;
using LibAbstract.CharacterManagement;

namespace LibAbstract.Factory
{
    public abstract class AbstractFactory
    {
        string Title { get; }

        // virtual
        // L'implémentation d'un membre virtual peut être modifiée par un membre de substitution dans une classe dérivée.

        // abstract n'a pas de corps mais virtual en a un
        public AbstractFactory(string title)
        {
            Title = title;
        }

        public abstract AbstractAccess CreateAccess(AbstractZone zdebut, AbstractZone zfin);
        public abstract AbstractEnvironment CreateEnvironment();
        public abstract AbstractObject CreateObject(String name);
        public abstract AbstractZone CreateZone(String name);
        public abstract AbstractCharacter CreateCharacter(String name);
    }
}

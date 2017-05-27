using LibAbstract.CharacterManagement;
using LibMetier.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.CharacterManagement
{
    public class AntHillSpirit : AbstractSubject
    {
        public string State { get; set; }
        public readonly List<AntInfo> Info = new List<AntInfo>();
        public readonly List<AHObject> Objects = new List<AHObject>();

        public void Attach(Ant observer)
        {
            observer.Attach(this);
            base.Attach(observer);
        }

        public void Detach(Ant observer)
        {
            observer.Detach(this);
            base.Detach(observer);
        }
    }
}

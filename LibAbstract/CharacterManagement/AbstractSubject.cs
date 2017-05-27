using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstract.CharacterManagement
{
    public abstract class AbstractSubject
    {
        private readonly List<IGVObserver> observateurList = new List<IGVObserver>();

        public virtual void Attach(IGVObserver observer)
        {
            observateurList.Add(observer);
        }

        public virtual void Detach(IGVObserver observer)
        {
            observateurList.Remove(observer);
        }

        public void Notify()
        {
            foreach(IGVObserver o in observateurList)
            {
                o.Update();
            }
        }
    }
}

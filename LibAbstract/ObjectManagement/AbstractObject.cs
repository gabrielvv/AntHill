using LibAbstract.EnvironmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstract.ObjectManagement
{
    public abstract class AbstractObject
    {
        public String Name { get; set; }
        public AbstractZone Position { get; set; }


    }
}

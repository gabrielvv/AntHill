using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.ObjectManagement;

namespace LibMetier.ObjectManagement
{
    public class AHObject : AbstractObject
    {
        public enum ObjectType { Organic, Mineral }
        public int Weight { get; set; }

        public AHObject(int weight)
        {
            this.Weight = weight;
        }
    }
}

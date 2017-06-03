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
        private static Random rdm = new Random();
        private static int Counter = 0; // Object counter

        public enum ObjectType { Organic, Mineral }
        public int Weight { get; set; }

        public AHObject(int weight, string name)
        {
            this.Weight = weight;
            AHObject.Counter++;
        }

        ~AHObject()
        {
            AHObject.Counter--;
        }

        public override string ToString()
        {
            return "(Brouillon) " + this.Name;
        }
    }
}

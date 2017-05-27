using LibAbstract.EnvironmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstract.CharacterManagement
{
    public abstract class AbstractCharacter
    {
        static Random rdm = new Random();
        private Random _rdm;

        public AbstractZone Position { get; set; }
        
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public AbstractCharacter(string Name, AbstractZone position)
        {
            this.Name = Name;
            this.Position = position;
            this.CreationDate = new DateTime();
        }

        public abstract AbstractZone NextZoneChoice(List<AbstractAccess> accessList);

    }
}

using LibAbstract.CharacterManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.EnvironmentManagement;
using LibMetier.EnvironmentManagement;

namespace LibMetier.CharacterManagement
{
    public class Ant : AbstractCharacter, IGVObserver, IAntActions
    {

        // https://docs.microsoft.com/fr-fr/dotnet/articles/csharp/language-reference/keywords/enum
        // https://fr.wikipedia.org/wiki/Fourmi#Sp.C3.A9cialisations
        public enum EAntSpecialisations { SlaveMaking, Honeypots, Leafcutter, Carpenter, Weaver, Cropper };

        private static int DailyConsumption = 3; // Consommation journalière par défaut
        private static int AgeOfDeath = 30; // (days)
        private static int AdultAge = 10; // (days)

        private static int Counter = 0; // Ant counter

        private static string DefaulfName()
        {
            return "Ant " + Counter;
        }

        /***************************************************************************/

        public int Life { get; set; }
        public int CarriedFood { get; set; } = 0;
        public int Age { get; set; } = 10; // (days) Starting at Adult Stage
        public int Strength { get; set; } // ability to move heavy objects
        public int Agility { get; set; } // ability to strike first / avoid hits in battles
        public readonly List<AntInfo> Info = new List<AntInfo>();

        public readonly int FoodCapacity; // how much FoodUnit can a Ant carry
        public readonly EAntSpecialisations Specialisation;

        public Ant(int life, int carriedFood, string name = "Anonyme", AbstractZone position = null) : base(name, position)
        {
            this.Life = life;
            this.CarriedFood = carriedFood;

            Ant.Counter++;
        }

        public override AbstractZone NextZoneChoice(List<AbstractAccess> accessList)
        {
            throw new NotImplementedException();
        }

        // Observer Pattern

        public AntHillSpirit Subject { get; set; }
        public string ObservedState { get; set; }

        public void Detach(AntHillSpirit subject)
        {
            this.Subject = null;
        }

        public void Attach(AntHillSpirit subject)
        {
            this.Subject = subject;
        }

        public void Update()
        {
            this.ObservedState = Subject.State;
        }

        public override string ToString()
        {
            return "(Brouillon) " + this.Name;
        }
    }
}

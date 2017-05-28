using LibAbstract.EnvironmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.CharacterManagement;
using LibAbstract.Factory;
using LibMetier.CharacterManagement;
using LibMetier.ObjectManagement;

namespace LibMetier.EnvironmentManagement
{
    public class AHEnvironment : AbstractEnvironment

    {

        public int Y { get; set; }
        public int X { get; set; }
        public static TimeSpan StepDuration; // hours

        private readonly EventsManager AntHillEventsManager = new EventsManager(); // => DELEGATE ?
        private readonly TimeManager AntHillTimeManager = new TimeManager(); // => DELEGATE ?
        private readonly WeatherManager AntHillWeatherManager = new WeatherManager(); // => DELEGATE ?
        private readonly AntHillSpirit HillSpirit = new AntHillSpirit();

        public AHEnvironment(int x, int y) : base()
        {
            this.X = x;
            this.Y = y;
        }

        public override void LoadCharacters(AbstractFactory factory)
        {
            AddCharacter(factory.CreateCharacter(null));
        }

        public override void LoadEnvironment(AbstractFactory factory)
        {
            /// A B C
            /// _____
            /// 0 1 2 | 1 
            /// 3 4 5 | 2
            /// 6 7 8 | 3
            for (int i = 0; i < Y; i++)
            {
                char c = (char)(65+i);
                for (int j = 0; j < X; j++)
                {
                    AddZones( factory.CreateZone( j, i, String.Format("AHZone {0}{1}", c, j) ) );
                }
            }

            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    int index = i * Y + j;
                    //bool CORNER_UP_LEFT    = i == 0 && j == 0;
                    //bool CORNER_UP_RIGHT   = i == 0 && j == X-1;
                    //bool CORNER_BOT_LEFT   = i == Y-1 && j == 0;
                    //bool CORNER_BOT_RIGHT  = i == Y-1 && j == X-1;
                    //bool SIDE_LEFT         = j == 0 && i != 0 && i != Y-1;
                    //bool SIDE_UP           = i == 0 && j != 0 && j != X-1;
                    //bool SIDE_RIGHT        = j == X-1 && i != 0 && i != Y-1;
                    //bool SIDE_BOT          = i == Y-1 && j != 0 && j != X-1;

                    AbstractZone z = Zones.ElementAt(index);

                    //AbstractZone uz = Zones.ElementAt((i-1) * Y + j);
                    //AbstractZone lz = Zones.ElementAt(i * Y + (j-1));

                    int indexRight = i * Y + (j + 1);
                    int indexBottom = (i + 1) * Y + j;


                    //System.Diagnostics.Debug.WriteLine("Zone index : {0}", index);

                    //System.Diagnostics.Debug.WriteLine("Right Zone index : {0}", indexRight);
                    //System.Diagnostics.Debug.WriteLine("Bottom Zone index : {0}", indexBottom);

                    if (j != X - 1 && indexRight < Zones.Count)
                    {
                        AbstractZone rz = Zones.ElementAt(indexRight);
                        factory.CreateAccess(z, rz);
                    }

                    if (i != Y - 1 && indexBottom < Zones.Count)
                    {
                        AbstractZone bz = Zones.ElementAt(indexBottom);
                        factory.CreateAccess(z, bz);
                    }

                }
            }
                    
            // TODO initialiser une matrice
        }

        public override void PrintEnvironment()
        {
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    int index = i * Y + j;
                    System.Diagnostics.Debug.WriteLine("{0}", Zones.ElementAt(index));
                }
            }
        }

        public override void LoadObjects(AbstractFactory factory)
        {
            AddObject(factory.CreateObject("AHObject"));
        }

        public override void MoveCharacter(AbstractCharacter character, AbstractZone sourceZone, AbstractZone destZone)
        {
            
        }

        public override void Simulate()
        {
            // Propagation des informations générales (Horaire, Météo, Contraintes Simulations)
            // Propagation des ordres, propagation hiérarchique
            // Pour chaque perso, AnalyseSituation
            // Pour chaque Conflit : Médiation des conflits
            // Pour chaque personnage : Execution
            // Pour chaque objet : Update()
            // Récupérer informations + Stats
            
            // Affichage
            Statistics();
        }

        protected override void Statistics()
        {
            throw new NotImplementedException();
        }
    }
}

using LibAbstract.Factory;
using LibAbstract.ObjectManagement;
using LibAbstract.CharacterManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstract.EnvironmentManagement
{
    public abstract class AbstractEnvironment
    {
        // TODO audit cas d'usage => si peu fréquent on peut obtenir la liste via getter et itération dans Zones
        public List<AbstractObject> ObjectList { get; set; }

        // TODO audit cas d'usage => si peu fréquent on peut obtenir la liste via getter et itération dans Zones
        public List<AbstractAccess> Accesses { get; set; }
        public List<AbstractZone> Zones { get; set; }
        public List<AbstractCharacter> Characters { get; set; }

        public AbstractEnvironment()
        {
            // TODO
        }

        public abstract void Simulate();
        protected abstract void Statistics();

        public virtual void AddPath(AbstractFactory factory, params AbstractAccess[] accessArray)
        {
            // TODO
        }

        public virtual void AddObject(AbstractObject oneObject)
        {
            ObjectList.Add(oneObject);
        }

        public virtual void AddCharacter(AbstractCharacter character)
        {
            Characters.Add(character);
        }

        // En utilisant le mot clé params vous pouvez spécifier un paramètre de méthode qui prend un nombre variable d'arguments
        // https://msdn.microsoft.com/fr-fr/library/w5zay9db.aspx
        public virtual void AddZones(params AbstractZone[] abstractZoneArray)
        {
            Zones.AddRange(abstractZoneArray);
            foreach(AbstractZone z in abstractZoneArray)
            {
                Accesses.AddRange(z.Accesses);
            }
        }

        public abstract void LoadEnvironment(AbstractFactory factory);
        public abstract void LoadObjects(AbstractFactory factory);
        public abstract void LoadCharacters(AbstractFactory factory);
        public abstract void MoveCharacter(AbstractCharacter character, AbstractZone sourceZone, AbstractZone destZone);

        
    }
}

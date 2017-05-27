using LibAbstract.CharacterManagement;
using LibAbstract.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstract.EnvironmentManagement
{
    public abstract class AbstractZone
    {
        public string Name { get; set; }
        public List<AbstractObject> Objects { get; set; }
        public List<AbstractCharacter> Characters { get; set; }
        public List<AbstractAccess> Accesses { get; set; }

        public int Y { get; set; }
        public int X { get; set; }

        public AbstractZone(string Name)
        {
            this.Name = Name;
        }

        public virtual void AddAccess(AbstractAccess access)
        {
            Accesses.Add(access);
        }
        public virtual void RemoveAccess(AbstractAccess access)
        {
            Accesses.Remove(access);
        }
        public virtual void AddObject(AbstractObject obj)
        {
            Objects.Add(obj);
        }
        public virtual void RemoveObject(AbstractObject obj)
        {
            Objects.Remove(obj);
        }
        public virtual void AddCharacter(AbstractCharacter character)
        {
            Characters.Add(character);
        }
        public virtual void RemoveCharacter(AbstractCharacter character)
        {
            Characters.Remove(character);
        }
    }
}

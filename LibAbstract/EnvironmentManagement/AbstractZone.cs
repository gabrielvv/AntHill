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
        public readonly List<AbstractObject> Objects = new List<AbstractObject>();
        public readonly List<AbstractCharacter> Characters = new List<AbstractCharacter>();
        public readonly List<AbstractAccess> Accesses = new List<AbstractAccess>();

        public int Y { get; set; }
        public int X { get; set; }

        public AbstractZone(int x, int y, string Name)
        {
            X = x;
            Y = y;
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
            character.Position = this;
            Characters.Add(character);
        }
        public virtual void RemoveCharacter(AbstractCharacter character)
        {
            Characters.Remove(character);
        }

        public override string ToString()
        {
            string str = String.Format("[{0},{1}] {2} Characters & {3} Objects", X, Y, Characters.Count, Objects.Count);
            return str;
        }

        public string PrintAccess()
        {
            string str = String.Format("[{0},{1}] ->", X, Y);
            foreach(AbstractAccess access in Accesses)
            {
                str += String.Format("\t[{0},{1}][{2},{3}]", access.start.X, access.start.Y, access.end.X, access.end.Y);
            }
            return str;
        }
    }
}

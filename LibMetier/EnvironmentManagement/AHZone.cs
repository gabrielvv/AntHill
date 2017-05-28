using LibAbstract.EnvironmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstract.CharacterManagement;
using LibAbstract.ObjectManagement;

namespace LibMetier.EnvironmentManagement
{
    public class AHZone : AbstractZone
    {
        public int X { get; set; }
        public int Y { get; set; }

        public AHZone(int x, int y, string Name) : base(x, y, Name)
        {
        }

        public override void AddAccess(AbstractAccess access)
        {
            base.AddAccess(access);
        }

        public override void AddCharacter(AbstractCharacter character)
        {
            base.AddCharacter(character);
        }

        public override void AddObject(AbstractObject obj)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAccess(AbstractAccess access)
        {
            throw new NotImplementedException();
        }

        public override void RemoveCharacter(AbstractCharacter character)
        {
            throw new NotImplementedException();
        }

        public override void RemoveObject(AbstractObject obj)
        {
            throw new NotImplementedException();
        }
    }
}

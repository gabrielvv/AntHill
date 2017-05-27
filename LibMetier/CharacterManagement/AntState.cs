using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.CharacterManagement
{
    public abstract class AntState
    {
        public Ant ant { get; set; }
        public AntState(Ant ant)
        {

        }
    }
}

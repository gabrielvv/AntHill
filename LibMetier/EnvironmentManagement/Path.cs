using LibAbstract.EnvironmentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.EnvironmentManagement
{
    class Path : AbstractAccess
    {
        public Path(AbstractZone start, AbstractZone end) : base(start, end)
        {
        }
    }
}

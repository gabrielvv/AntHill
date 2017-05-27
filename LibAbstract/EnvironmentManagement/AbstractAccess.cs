using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstract.EnvironmentManagement
{
    public abstract class AbstractAccess
    {
        public AbstractZone start { get; set; }
        public AbstractZone end { get; set; }

        public AbstractAccess(AbstractZone start, AbstractZone end)
        {
            this.start = start;
            this.end = end;
            start.AddAccess(this);
            end.AddAccess(this);
        }

        ~AbstractAccess()
        {
            start.RemoveAccess(this);
            end.RemoveAccess(this);
        }
    }
}

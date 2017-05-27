using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.EnvironmentManagement
{
    class TimeManager
    {
        public TimeSpan SpannedTime { get; set; } // temps écoulé depuis le début de la simulation
        public int Days { get; set; } = 0;
        private bool Night { get; set; } = false;
    }
}

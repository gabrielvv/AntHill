using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.EnvironmentManagement
{
    class WeatherManager
    {
        private Random Hasard;
        private enum Season { Summer, Automn, Winter, Spring }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}

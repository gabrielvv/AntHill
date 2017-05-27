using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class AboutViewModel : ViewModelBase
    {
        public String Copyright { get { return "ESGI"; } }
        public String AppDate { get { return DateTime.Now.ToString(); } }
        public String Author { get; } = "VAUTRIN Gabriel";
    }
}

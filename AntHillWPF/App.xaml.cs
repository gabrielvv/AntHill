using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AntHillViewModel AntHillVM { get; set; }
        //public static AboutViewModel AboutVM { get; set; }

        public App()
        {
            AntHillVM = new AntHillViewModel();
            //AboutVM = new AboutViewModel();
        }
    }
}

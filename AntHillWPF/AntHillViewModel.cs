using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using System.Xml.Linq;

namespace WpfApplication1
{
    public class AntHillViewModel : ViewModelBase
    {
        /****** Property *******/


        public int DimX { get; set; }
        public int DimY { get; set; }

        private int _execSpeed;
        public int ExecutionSpeed {
            get
            {
                return _execSpeed;
            }
            set
            {
                _execSpeed = value;
                OnPropertyChanged("ExecutionSpeed");
            }
        } //ms
        public bool InProgress { get; set; }

        private string _appName;
        public string AppName
        {
            get
            {
                return _appName;
            }
            set
            {
                _appName = value;
                OnPropertyChanged("AppName");
            }
        }

        public ObservableCollection<Ant> AntList { get; private set; }

        private Ant _selectedAnt;
        public Ant SelectedAnt {
            get { return _selectedAnt;  }
            set
            {
                _selectedAnt = value;
                OnPropertyChanged("SelectedAnt");
            }
        }

        /******** Constructor *********/

        public AntHillViewModel()
        {
            AppName = "AntHill";
            AntList = new ObservableCollection<Ant>();
            //AntList.Add(new Ant());
            //AntList.Add(new Ant());

            var list = ReadXML("ants.xml");
            foreach(Ant a in list){
                AntList.Add(a);
            }
            DimX = 30;
            DimY = 20;
            ExecutionSpeed = 500; //ms
        }

        /********* Methods *********/

        public void AddAnt()
        {
            AntList.Add(new Ant("Ant " + AntList.Count));
        }

        public void DeleteAnt()
        {
            AntList.Remove(SelectedAnt);
        }

        internal void Stop()
        {
            InProgress = false;
        }

        internal void Forward()
        {
            InProgress = true;
            while (InProgress)
            {
                Thread.Sleep(ExecutionSpeed);
                NextStep();
            }
        }

        internal void NextStep()
        {
            foreach(Ant a in AntList)
            {
                a.MoveOneStep(DimX, DimY);
            }
        }

        public static IEnumerable<Ant> ReadXML(string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);
            XElement xdocroot = xdoc.Root;
            if (xdocroot != null) {

                XElement xAnts = xdocroot.Element("ants");
                IEnumerable<XElement> xAntList = xAnts.Elements();
                foreach (XElement xAnt in xAntList)
                {
                    string name = xAnt.Attribute("name").Value;
                    int x = int.Parse(xAnt.Element("X").Value);
                    int y = int.Parse(xAnt.Element("Y").Value);
                    //var ant = new Ant(name, x, y);
                    var ant = new Ant()
                    {
                        Name = name,
                        X = x,
                        Y = y
                    };

                    yield return ant;
                }

            }
        }
    }
}

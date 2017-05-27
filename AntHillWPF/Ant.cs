using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Ant
    {
        static Random rdm = new Random();
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ObservableCollection<Step> StepList { get; set; }

        public int Y { get; set; }
        public int X { get; set; }

        public Ant(string Name="Anonyme", int X=10, int Y=10)
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.CreationDate = new DateTime();
            this.StepList = new ObservableCollection<Step>();
            for(int i = 0; i < rdm.Next(10); i++)
            {
                StepList.Add(new WpfApplication1.Step { TourNumber = i });
            } 
        }

        public override string ToString()
        {
            return "(Brouillon) "+this.Name;
        }

        public void MoveOneStep(int dimX, int dimY)
        {
            HazardMove(dimX, dimY);
            StepList.Add(new Step());
        }

        public void HazardMove(int dimX, int dimY)
        {
            int newX = X + rdm.Next(3) - 1;
            int newY = Y + rdm.Next(3) - 1;
            if ((newX >= 0) && (newX < dimX)) X = newX;
            if ((newY >= 0) && (newY < dimY)) Y = newY;
        }
    }
}

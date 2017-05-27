using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        DispatcherTimer dt = new DispatcherTimer();
        Thread tt = new Thread(App.AntHillVM.Forward);

        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.AntHillVM;
            dt.Tick += Draw_Tick; // new EventHandler(Draw_Tick); 
            dt.Interval = new TimeSpan(0, 0, 0, 0, App.AntHillVM.ExecutionSpeed);
            Draw();
        }

        public void InitBoard()
        {
            Board.RowDefinitions.Clear();
            Board.ColumnDefinitions.Clear();
            Board.Children.Clear();
            for (int i = 0; i < App.AntHillVM.DimX; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            for (int i = 0; i < App.AntHillVM.DimY; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
            }
            //Board.Background = new SolidColorBrush(Colors.ForestGreen);
        }

        public void Draw()
        {
            InitBoard();
            DrawAntHill();
            DrawAnt();
        }

        private void Draw_Tick(object sender, EventArgs e)
        {
            if (dt.IsEnabled)
            {
                Draw();
            }
        }

        public void DrawAntHill()
        {
            Ellipse e = new Ellipse();
            e.Fill = new SolidColorBrush(Colors.Red);
            e.Margin = new Thickness(3);
            Board.Children.Add(e);
            Grid.SetColumn(e, 4);
            Grid.SetRow(e, 5);
        }

        public void DrawAnt()
        {
            foreach (Ant a in App.AntHillVM.AntList)
            {
                Ellipse e = new Ellipse();
                e.Fill = new SolidColorBrush(Colors.Maroon);
                e.Margin = new Thickness(3);
                //Trace.WriteLine(a.X); // CTRl + ALT + O pour Output Window
                //Trace.WriteLine(a.Y);
                Board.Children.Add(e);
                Grid.SetColumn(e, a.X);
                Grid.SetRow(e, a.Y);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.AntHillVM.AddAnt();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            App.AntHillVM.DeleteAnt();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.AntHillVM.AppName = "Toto";
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            var about = new About();
            about.Show();
            //this.Close();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (dt.IsEnabled)
            {
                dt.Stop();
                tt.Abort();
            }
            App.AntHillVM.NextStep();
            Draw();
        }

        private void BtnForward_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            tt = new Thread(App.AntHillVM.Forward);
            tt.Start();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            App.AntHillVM.Stop();
            if (dt.IsEnabled)
            {
                dt.Stop();
                tt.Abort();
            }
        }

        private void SliderSpeed_ValueChanged(object sender, RoutedEventArgs e)
        {
            var slider = sender as Slider;
            App.AntHillVM.ExecutionSpeed = (int)slider.Value;
        }
    }
}

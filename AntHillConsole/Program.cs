using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier.EnvironmentManagement;
using LibMetier.Factory;
using LibAbstract.EnvironmentManagement;
using System.Threading;

namespace SimulationFourmiliere
{
    class Program
    {
        static void Main(string[] args)
        {
            AntHillViewModel AntHillVM = null;
            Thread workerThread = null;

            AbstractEnvironment Env;
            // https://msdn.microsoft.com/fr-fr/library/471w8d85(v=vs.110).aspx Console.ReadKey Doc
            // https://msdn.microsoft.com/fr-fr/library/system.consolekeyinfo(v=vs.110).aspx ConsoleKeyInfo doc
            ConsoleKeyInfo cki;
            // Prevent example from ending if CTL+C is pressed.
            Console.TreatControlCAsInput = true;
            bool ALT, SHIFT, CTL = false;

            Console.WriteLine("============== ANT HILL SIMULATOR ===============");
            Console.WriteLine("Start a new session : Press 1");
            Console.WriteLine("Load a previous session : Press 2");
            Console.WriteLine("Quit : Press Escape");

            do
            {
                ALT = SHIFT = CTL = false;
                cki = Console.ReadKey(/* intercept */true);

                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) ALT = true; //ALT;
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) SHIFT = true; //SHIFT
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) CTL = true; //CTL
                //System.Diagnostics.Debug.WriteLine(cki.KeyChar);

                switch (cki.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Starting a new session");

                        AHFactory Factory = new AHFactory();
                        Env = Factory.CreateEnvironment();

                        Env.LoadEnvironment(Factory);

                        Env.LoadObjects(Factory);
                        Env.LoadCharacters(Factory);
                        //Console.Write(Env.PrintCharacters());
                        //Console.Write(Env.PrintEnvironment());

                        AntHillVM = new AntHillViewModel(Env);
                        break;
                    case '2':
                        Console.WriteLine("Loading a previous session");

                        // TODO

                        //XMLFactory XFactory = new XMLFactory();
                        //Env = XFactory.CreateEnvironment();

                        //Env.LoadEnvironment(XFactory);

                        //Env.LoadObjects(XFactory);
                        //Env.LoadCharacters(XFactory);
                        //Console.Write(Env.PrintCharacters());
                        //Console.Write(Env.PrintEnvironment());

                        //AntHill = new AntHillViewModel(Env);
                        break;
                }

            } while (cki.Key != ConsoleKey.Escape && AntHillVM == null);


            if (AntHillVM != null && workerThread == null)
            {
                workerThread = new Thread(AntHillVM.Forward);
                workerThread.Start();
                // Loop until worker thread activates.
                while (!workerThread.IsAlive) ;
            }

            do
            {
                ALT = SHIFT = CTL = false;
                cki = Console.ReadKey(/* intercept */true);

                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) ALT = true; //ALT;
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) SHIFT = true; //SHIFT
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) CTL = true; //CTL
                //System.Diagnostics.Debug.WriteLine(cki.KeyChar);

                switch (cki.KeyChar)
                {
                    
                }
                System.Diagnostics.Debug.WriteLine(cki.Key.ToString());
                switch (cki.Key.ToString())
                {
                    case "UpArrow":
                        Console.WriteLine("Execution Speed = {0} ms", AntHillVM.ExecutionSpeed += 100);
                        break;
                    case "DownArrow":
                        Console.WriteLine("Execution Speed = {0} ms", AntHillVM.ExecutionSpeed -= 100);
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);

            if (AntHillVM != null && workerThread != null)
            {
                // Request that the worker thread stop itself:
                AntHillVM.Stop();

                // Use the Join method to block the current thread 
                // until the object's thread terminates.
                workerThread.Join();
                Console.WriteLine("Main thread: Worker thread has terminated.");
            }

            Console.WriteLine("Bye Bye");
            System.Threading.Thread.Sleep(2000);
           

            //Console.ReadKey();
        }
    }
}

using System;


namespace Ex03.ConsoleUI
{
    public class Proggram
    {
        public static void Main()
        {
            RunGarage();
        }

        public static void RunGarage()
        {
            bool isProgramStillRunning;
            GarageInterface garageInterfaceInstance = new GarageInterface();

            UI.ProgramStart();
            do
            {
                garageInterfaceInstance.MenuRun(out isProgramStillRunning);
            }
            while(isProgramStillRunning);

        }
    }
}

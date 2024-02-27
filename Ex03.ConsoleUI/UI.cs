using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        private class Messages
        {
            internal const string k_Opening = "Hello! welcome to the garage!.\n\nbefore you is a menu." +
                "please choose an option by entering the number beside it. for exiting please press 0";
            internal const string k_MenuOptions = 
                "1. Enter a new vehicle to the garage\n" +
                "2. show garage's car's license plates with the option to filter by vehicle condition\n" +
                "3. change a car's state\n" +
                "4. inflate a car's wheels to maximum air pressure\n" +
                "5. fuel up a non electric car\n" +
                "6. charge an electric car\n" +
                "7. show a car's full details\n";
            internal const string k_IncorrectInput = "entered input in incorrect. please choose again: ";
            internal const string k_GetLicensePlate = "please enter vehicle's license plate: ";
        }

        internal static GarageInterface.eMenueOptions ChooseOptionFromMenu()
        {
            string userStrInput;
            int userInput;
            bool isInputOk;

            Console.WriteLine(Messages.k_Opening);
            Console.WriteLine(Messages.k_MenuOptions);
            userStrInput = Console.ReadLine();
            isInputOk = !int.TryParse(userStrInput, out userInput) &&
                (userInput < GarageInterface.k_NumOfFirstMenuOption || userInput > GarageInterface.k_NumOfLastMenuOption);
            while (!isInputOk)
            { 
                Console.WriteLine(Messages.k_IncorrectInput);
                Console.WriteLine(Messages.k_Opening);
                Console.WriteLine(Messages.k_MenuOptions);
                userStrInput = Console.ReadLine();
                isInputOk = !int.TryParse(userStrInput, out userInput) &&
                    (userInput < GarageInterface.k_NumOfFirstMenuOption || userInput > GarageInterface.k_NumOfLastMenuOption);
            }

            return (GarageInterface.eMenueOptions)userInput;
        }

        internal static string GetLicensePlate()
        {
            Console.WriteLine(Messages.k_GetLicensePlate);
            return Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        internal class Messages
        {
            internal const string k_Opening = "Hello! welcome to the garage!.";

            internal const string k_MenuOption0 = "0) Exit";
            internal const string k_MenuOption1 = "1) Enter a new vehicle to the garage";
            internal const string k_MenuOption2 = "2) Show garage's car's license plates with the option to filter by vehicle condition";
            internal const string k_MenuOption3 = "3) Change a car's state";
            internal const string k_MenuOption4 = "4) Inflate a car's wheels to maximum air pressure";
            internal const string k_MenuOption5 = "5) Fuel up a fuel electric car";
            internal const string k_MenuOption6 = "6) Charge an electric car";
            internal const string k_MenuOption7 = "7) Show a car's full details";

            internal const string k_IncorrectInput = "entered input in incorrect. please choose again: ";
            internal const string k_GetLicensePlate = "please enter vehicle's license plate: ";
            internal const string k_VehicleNotInGarage = "there is no matching vehicle in garage.";

            internal static string k_MenuOptions = string.Format(
@"{0}Menu{0}
|{1, -94}|
|{2, -94}|
|{3, -94}|
|{4, -94}|
|{5, -94}|
|{6, -94}|
|{7, -94}|
|{8, -94}|
|{9, -94}|
{10, -94}",
new String('-', 46), k_MenuOption1, k_MenuOption2, k_MenuOption3, k_MenuOption4,
k_MenuOption5, k_MenuOption6, k_MenuOption7, ' ', k_MenuOption0, new String('-', 96));
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

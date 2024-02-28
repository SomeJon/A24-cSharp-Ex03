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

            internal const string k_IncorrectInput = "Entered input in incorrect. please choose again: ";
            internal const string k_GetLicensePlate = "Please enter vehicle's license plate: ";
            internal const string k_VehicleNotInGarage = "There is no matching vehicle in garage.";
            internal const string k_AttributeListRequest = "Please enter the requsted info of {0]:";
            internal const string k_VehicleIsAlreadyInGarage = "Requsted Vehicle is in the garage, changing status to Repair...";


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

        internal static void ProgramStart()
        {
            Console.WriteLine(Messages.k_Opening);
        }


        internal static void Menu(out GarageInterface.eMenueOptions o_ChosenOption)
        {
            string userStrInput;
            bool isInputOk = false;
            GarageInterface.eMenueOptions userChoice;

            Console.WriteLine(Messages.k_MenuOptions);
            userStrInput = Console.ReadLine();

            isInputOk = GarageInterface.eMenueOptions.TryParse(userStrInput, out userChoice);
            while (!isInputOk || !Enum.IsDefined(typeof(GarageInterface.eMenueOptions), userChoice))
            {
                Console.WriteLine(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
                isInputOk = GarageInterface.eMenueOptions.TryParse(userStrInput, out userChoice);
            }

            o_ChosenOption = userChoice;
        }

        internal static string GetLicensePlate()
        {
            Console.WriteLine(Messages.k_GetLicensePlate);
            return Console.ReadLine();
        }

        internal static List<string> GetAttributes(List<string> i_Attributes, string i_NameOfRecivingObject)
        {
            List<string> recivedAttributes = new List<string>();
            string userInput;

            Console.WriteLine(Messages.k_AttributeListRequest, i_NameOfRecivingObject);
            foreach (string attribute in i_Attributes)
            {
                Console.Write(@"{0}: ", attribute);
                userInput = Console.ReadLine();
                recivedAttributes.Add(userInput);
            }

            return recivedAttributes;
        }

        internal static void CarInGarageMessage()
        {
            Console.WriteLine(Messages.k_VehicleIsAlreadyInGarage);
        }
    }
}

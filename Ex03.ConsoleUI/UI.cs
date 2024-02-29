using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            internal const string k_MenuOption3 = "3) Change a vehicle's state";
            internal const string k_MenuOption4 = "4) Inflate a vehicle's wheels to maximum air pressure";
            internal const string k_MenuOption5 = "5) Fuel up a fuel vehicke";
            internal const string k_MenuOption6 = "6) Charge an electric vehicle";
            internal const string k_MenuOption7 = "7) Show a vehicle's full details";
            internal const string k_MenuOption8 = "8) Change new vehicle load settings menu";

            internal const string k_IncorrectInput = "Entered input is incorrect. please choose again: ";
            internal const string k_GetLicensePlate = "Please enter vehicle's license plate: ";
            internal const string k_VehicleNotInGarage = "There is no matching vehicle in garage.";
            internal const string k_AttributeListRequest = @"Please enter the requsted info of {0}:";
            internal const string k_VehicleIsAlreadyInGarage = "Requsted Vehicle is in the garage, changing status to Repair...";
            internal const string k_VehicleChoiceStartDialog = "Please chose a car from list: ";
            
            internal const string k_CurrentWheelSetup = "Current setting for new vehicle wheels is - ";
            internal const string k_OneAtATime = "Enter wheels info one at a time";
            internal const string k_AllAtOnce = "Enter one wheel info for all";
            internal const string k_InputChangeYesOrNo = "Would you like to change it?(yes/no): ";
            internal const string k_Yes = "Yes";
            internal const string k_No = "No";
            internal const string k_Electric = "Electric ";
            internal const string k_LicensePlate = "License Plate";
            internal const string k_Status = "Status";
            internal const string k_GetStatus = "Please choose a number representing status of vehicle:";
            internal const string k_Found = "Found";
            internal const string k_AddingFuelType = "Please chose a fuel type from list to fill:";
            internal const string k_AddingActionFloat = "Please chose an amount to {0}:";
            internal const string k_Nun = "None were found.";

            internal const string k_ShowLicencesOfCarsMenu =
@"Please choose a number representing a choice:
1) All vehicles licences
2) Vehicles licences yet to be Repaired
3) Repaired vehicles licences
4) Paid vehicles licences cards

0) back";


            internal static string k_MenuOptions = string.Format(
@"{0}Menu{0}
|{1, -94}|
|{2, -94}|
|{3, -94}|
|{4, -94}|
|{5, -94}|
|{6, -94}|
|{7, -94}|
|{11, -94}|
|{8, -94}|
|{9, -94}|
{10, -94}",
new String('-', 46), k_MenuOption1, k_MenuOption2, k_MenuOption3, k_MenuOption4,
k_MenuOption5, k_MenuOption6, k_MenuOption7, ' ', k_MenuOption0, new String('-', 96), k_MenuOption8);
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
            while(!isInputOk || !Enum.IsDefined(typeof(GarageInterface.eMenueOptions), userChoice))
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
            foreach(string attribute in i_Attributes)
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

        internal static VehicleFactory.eVehicleOptions GetVehicleChoice()
        {
            int choiceToPrint = 1;
            string userStrInput;
            VehicleFactory.eVehicleOptions userChoice;
            bool isInputOk;

            Console.WriteLine(Messages.k_VehicleChoiceStartDialog);
            foreach(string vehicleName in VehicleFactory.s_VehicleOptions)
            {
                Console.WriteLine(@"{0}) {1}", choiceToPrint, vehicleName);
                choiceToPrint++;
            }
            userStrInput = Console.ReadLine();

            isInputOk = VehicleFactory.eVehicleOptions.TryParse(userStrInput, out userChoice);
            while(!isInputOk || !Enum.IsDefined(typeof(VehicleFactory.eVehicleOptions), userChoice))
            {
                Console.WriteLine(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
                isInputOk = VehicleFactory.eVehicleOptions.TryParse(userStrInput, out userChoice);
            }

            return userChoice;
        }

        internal static void ChangeWheelsSetupMenu()
        {
            string userStrInput;
            bool checkInput = false;

            Console.Write(Messages.k_CurrentWheelSetup);
            if(Vehicle.LoadAllWheelsAtOnce)
            {
                Console.WriteLine(Messages.k_AllAtOnce);
            }
            else
            {
                Console.WriteLine(Messages.k_OneAtATime);
            }

            Console.Write(Messages.k_InputChangeYesOrNo);
            userStrInput = Console.ReadLine();
            if(String.Equals(userStrInput, Messages.k_Yes, StringComparison.OrdinalIgnoreCase))
            {
                checkInput = true;
                Vehicle.SwitchLoadAllWheelsAtOnce();
            }
            else if(String.Equals(userStrInput, Messages.k_No, StringComparison.OrdinalIgnoreCase))
            {
                checkInput = true;
            }

            while(!checkInput)
            {
                Console.Write(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
                if (String.Equals(userStrInput, Messages.k_Yes, StringComparison.OrdinalIgnoreCase))
                {
                    checkInput = true;
                    Vehicle.SwitchLoadAllWheelsAtOnce();
                }
                else if(String.Equals(userStrInput, Messages.k_No, StringComparison.OrdinalIgnoreCase))
                {
                    checkInput = true;
                }
            }
        }

        internal static void PrintExceptions(Exception i_Exception)
        {
            Console.WriteLine(i_Exception.Message);
        }

        internal static void PrintAllInfoOfCard(GarageVehicleCard i_CardToPrintInfo)
        {
            List<string> attributeNames = i_CardToPrintInfo.GetAttributeNameList();
            List<string> attributeValues = i_CardToPrintInfo.GetAttributeValuesAsStringList();

            Console.WriteLine(@"{0}: {1}", Messages.k_Status, i_CardToPrintInfo.VehicleStatus);
            for(int i = 0; i < attributeNames.Count; i++)
            {
                Console.WriteLine(@"{0}: {1}", attributeNames.ElementAt(i), attributeValues.ElementAt(i));
            }

            PrintAllInfoOfVehicle(i_CardToPrintInfo.CardVehicle);
        }

        internal static void PrintAllInfoOfVehicle(Vehicle i_VehicleToPrintInfo)
        {
            List<string> attributeNames;
            List<string> attributeValues;

            if(i_VehicleToPrintInfo.IsElectric())
            {
                Console.Write(Messages.k_Electric);
            }

            Console.WriteLine(i_VehicleToPrintInfo.GetType().Name);
            if(Vehicle.LoadAllWheelsAtOnce == true)
            {
                Vehicle.SwitchLoadAllWheelsAtOnce();
                attributeNames = i_VehicleToPrintInfo.GetAttributeNameList();
                Vehicle.SwitchLoadAllWheelsAtOnce();
            }
            else
            {
                attributeNames = i_VehicleToPrintInfo.GetAttributeNameList();
            }

            attributeValues = i_VehicleToPrintInfo.GetAttributeValuesAsStringList();
            Console.WriteLine(@"{0}: {1}", Messages.k_LicensePlate, i_VehicleToPrintInfo.LicensePlate);
            for(int i = 0; i < attributeNames.Count; i++)
            {
                Console.WriteLine(@"{0}: {1}", attributeNames.ElementAt(i), attributeValues.ElementAt(i));
            }
        }

        internal static void GetVehicleStatus(out GarageVehicleCard.eVehicleStatus o_VehicleStatus)
        {
            int count = 1;
            string userStrInput;
            bool isInputOk;
            GarageVehicleCard.eVehicleStatus userChoice;

            Console.WriteLine(Messages.k_GetStatus);
            foreach(string enumName in Enum.GetNames(typeof(GarageVehicleCard.eVehicleStatus)))
            {
                Console.WriteLine(@"{0}) {1}", count, enumName);
                count++;
            }

            userStrInput = Console.ReadLine();
            isInputOk = GarageVehicleCard.eVehicleStatus.TryParse(userStrInput, out userChoice);
            while(!isInputOk || !Enum.IsDefined(typeof(GarageVehicleCard.eVehicleStatus), userChoice))
            {
                Console.WriteLine(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
                isInputOk = GarageVehicleCard.eVehicleStatus.TryParse(userStrInput, out userChoice);
            }

            o_VehicleStatus = userChoice;
        }

        internal static void VehicleLicencesInGarageMenu(out GarageInterface.eShowLicenceMenu o_ChosenOption)
        {
            string userStrInput;
            bool isInputOk = false;
            GarageInterface.eShowLicenceMenu userChoice;

            Console.WriteLine(Messages.k_ShowLicencesOfCarsMenu);
            userStrInput = Console.ReadLine();

            isInputOk = GarageInterface.eShowLicenceMenu.TryParse(userStrInput, out userChoice);
            while(!isInputOk || !Enum.IsDefined(typeof(GarageInterface.eShowLicenceMenu), userChoice))
            {
                Console.WriteLine(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
                isInputOk = GarageInterface.eShowLicenceMenu.TryParse(userStrInput, out userChoice);
            }

            o_ChosenOption = userChoice;
        }

        internal static void ShowVehicleLicences(List<string> i_VehicleLicences) 
        {
            Console.WriteLine(@"{0}: ", Messages.k_Found);
            if (i_VehicleLicences == null || i_VehicleLicences.Count == 0)
            {
                Console.WriteLine(@"{0}", Messages.k_Nun);
            }
            else
            {
                foreach (string licences in i_VehicleLicences)
                {
                    Console.WriteLine(licences);
                }
            }
        }

        internal static void GetFueFillType(out FuelEngine.eFuelType i_TypeOfFuel)
        {
            Console.WriteLine(Messages.k_AddingFuelType);
            string userStrInput;
            bool isInputOk = false;
            FuelEngine.eFuelType userChoice;

            Console.WriteLine(Messages.k_ShowLicencesOfCarsMenu);
            userStrInput = Console.ReadLine();

            isInputOk = FuelEngine.eFuelType.TryParse(userStrInput, out userChoice);
            while (!isInputOk || !Enum.IsDefined(typeof(FuelEngine.eFuelType), userChoice))
            {
                Console.WriteLine(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
                isInputOk = FuelEngine.eFuelType.TryParse(userStrInput, out userChoice);
            }

            i_TypeOfFuel = userChoice;
        }

        internal static void GetFloatForAnAction(string i_ActionName, out float i_AmountToFill)
        {
            string userStrInput;

            Console.WriteLine(Messages.k_AddingActionFloat, i_ActionName);
            userStrInput = Console.ReadLine();

            while(!float.TryParse(userStrInput, out i_AmountToFill))
            {
                Console.WriteLine(Messages.k_IncorrectInput);
                userStrInput = Console.ReadLine();
            }
        }
    }
}

using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.GarageVehicleCard;

namespace Ex03.ConsoleUI
{
    internal class GarageInterface
    {
        internal enum eMenueOptions
        {
            Exit,
            EnterNewCar,
            ShowLicensePlates,
            ChangeCarState,
            InflateCarWheels,
            FuelUpVehicle,
            ChargeUpVehicle,
            FullCardShow,
            ChangeCarLoadSetting
        }

        internal enum eShowLicenceMenu
        {
            Exit,
            All,
            Repair,
            Repaired,
            Paid
        }

        internal const int k_NumOfFirstMenuOption = 0;
        internal const int k_NumOfLastMenuOption = 7;
        private GarageData m_Garage;
        
        public GarageInterface()
        {
            m_Garage = new GarageData();
        }

        internal void MenuRun(out bool o_StillRunning)
        {
            eMenueOptions userChoice;
            
            o_StillRunning = true;
            UI.Menu(out userChoice);

            switch (userChoice) 
            {
                case eMenueOptions.EnterNewCar:
                    enterNewVehicle();
                    break;
                case eMenueOptions.ShowLicensePlates:
                    showVehicleLicences();
                    break;
                case eMenueOptions.ChangeCarState:
                    changeCardStatus();
                    break;
                case eMenueOptions.InflateCarWheels:
                    inflateCarWheels();
                    break;
                case eMenueOptions.FuelUpVehicle:
                    fillVehicleFuel();
                    break;
                case eMenueOptions.ChargeUpVehicle:
                    chargeElectricVehicle();
                    break;
                case eMenueOptions.FullCardShow:
                    fullCardShow();
                    break;
                case eMenueOptions.ChangeCarLoadSetting:
                    UI.ChangeWheelsSetupMenu();
                    break;
                default:
                    o_StillRunning = false;
                    break;

            }
        }

        private void fullCardShow()
        {
            string licensePlate = UI.GetLicensePlate();
            GarageVehicleCard foundCard = m_Garage.FindVehicle(licensePlate);

            if (foundCard != null)
            {
                UI.PrintAllInfoOfCard(foundCard);
            }
            else
            {
                UI.PrintExceptions(new Exception("Card Could not be found!"));
            }
        }

        private void showVehicleLicences()
        {
            eShowLicenceMenu userChoice;
            List<string> licences;

            UI.VehicleLicencesInGarageMenu(out userChoice);
            switch (userChoice)
            {
                case eShowLicenceMenu.All:
                    licences = GarageData.GetLicences(m_Garage.ListOfVehicles);
                    break;
                case eShowLicenceMenu.Repaired:
                    licences = m_Garage.FindAllMatchLicences(GarageVehicleCard.eVehicleStatus.Repaired);
                    break;
                case eShowLicenceMenu.Repair:
                    licences = m_Garage.FindAllMatchLicences(GarageVehicleCard.eVehicleStatus.Repair);
                    break;
                case eShowLicenceMenu.Paid:
                    licences = m_Garage.FindAllMatchLicences(GarageVehicleCard.eVehicleStatus.Paid);
                    break;
                default:
                    licences = null;
                    break;
            }

            if(licences != null)
            {
                UI.ShowVehicleLicences(licences);
            }
        }

        private void enterNewVehicle()
        {
            string recivedLicense = UI.GetLicensePlate();
            List<string> recivedAttributes;
            GarageVehicleCard newCard;
            VehicleFactory.eVehicleOptions vehicleChosen;
            Vehicle newVehicle;
            bool checkSuccess;

            if (m_Garage.isVehicleInGarage(recivedLicense))
            {
                UI.CarInGarageMessage();
            }
            else
            {
                newCard = new GarageVehicleCard();
                recivedAttributes = UI.GetAttributes(newCard.GetAttributeNameList(), "Card Entry");
                newCard.EnterAtributes(recivedAttributes);
                vehicleChosen = UI.GetVehicleChoice();
                newVehicle = VehicleFactory.CreateVehicle(vehicleChosen, recivedLicense);
                newCard.CardVehicle = newVehicle;
                checkSuccess = false;
                while (!checkSuccess)
                {
                    try
                    {
                        recivedAttributes = UI.GetAttributes(newVehicle.GetAttributeNameList(), newVehicle.GetType().Name);
                        newVehicle.EnterAtributes(recivedAttributes);
                        checkSuccess = true;
                    }
                    catch (Exception i_Exception) 
                    {
                        UI.PrintExceptions(i_Exception);
                    }
                }

                m_Garage.AddCardToList(newCard);
            }
        }

        private void changeCardStatus()
        {
            string recivedLicense = UI.GetLicensePlate();
            GarageVehicleCard foundCard = m_Garage.FindVehicle(recivedLicense);
            eVehicleStatus statusChosen;

            if (foundCard != null)
            {
                UI.GetVehicleStatus(out statusChosen);
                foundCard.VehicleStatus = statusChosen;
            }
            else
            {
                UI.PrintExceptions(new Exception("Card Could not be found!"));
            }
        }

        private void inflateCarWheels() 
        {
            string recivedLicense = UI.GetLicensePlate();
            
            try
            {
                m_Garage.FillVehicleWheelsToMax(recivedLicense);
            }
            catch(Exception i_Exception)
            {
                UI.PrintExceptions(i_Exception);
            }
        }

        private void fillVehicleFuel()
        {
            string recivedLicense = UI.GetLicensePlate();
            GarageVehicleCard foundCard = m_Garage.FindVehicle(recivedLicense);
            FuelEngine engine;
            FuelEngine.eFuelType fuelType;
            float amountToFill;

            if (foundCard != null)
            {
                try
                {
                    engine = foundCard.CardVehicle.Engine as FuelEngine;
                    if(engine != null)
                    {
                        UI.GetFueFillType(out fuelType);
                        UI.GetFloatForAnAction("fill a fuel engine", out amountToFill);
                        engine.FillFuelTank(amountToFill, fuelType);
                    }
                    else
                    {
                        UI.PrintExceptions(new ArgumentException("Chosen vehicle does not run on fuel!"));
                    }
                }
                catch (Exception i_Exception)
                {
                    UI.PrintExceptions(i_Exception);
                }
            }
            else
            {
                UI.PrintExceptions(new Exception("Card Could not be found!"));
            }
        }

        private void chargeElectricVehicle()
        {
            string recivedLicense = UI.GetLicensePlate();
            GarageVehicleCard foundCard = m_Garage.FindVehicle(recivedLicense);
            ElectricEngine engine;
            float amountToFill;

            if (foundCard != null)
            {
                try
                {
                    engine = foundCard.CardVehicle.Engine as ElectricEngine;
                    if (engine != null)
                    {
                        UI.GetFloatForAnAction("charge battery(value in minutes)", out amountToFill);
                        amountToFill = amountToFill / 60;
                        engine.ChargeBattery(amountToFill);
                    }
                    else
                    {
                        UI.PrintExceptions(new ArgumentException("Chosen vehicle is not electric!"));
                    }
                }
                catch (Exception i_Exception)
                {
                    UI.PrintExceptions(i_Exception);
                }
            }
            else
            {
                UI.PrintExceptions(new Exception("Card Could not be found!"));
            }
        }
    }
}

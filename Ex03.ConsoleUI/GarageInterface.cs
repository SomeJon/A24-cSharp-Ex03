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

        private GarageData m_Garage;
        internal const int k_NumOfFirstMenuOption = 0;
        internal const int k_NumOfLastMenuOption = 7;

        public GarageInterface()
        {
            m_Garage = new GarageData();
        }
        private void FullCardShow()
        {
            string licensePlate = UI.GetLicensePlate();
            GarageVehicleCard foundCard = m_Garage.FindVehicle(licensePlate);

            if(foundCard != null)
            {
                UI.PrintAllInfoOfCard(foundCard);
            }
            else
            {
                UI.PrintExceptions(new Exception("Card Could not be found!"));
            }
        }

        internal void MenuRun(out bool o_StillRunning)
        {
            eMenueOptions userChoice;
            
            o_StillRunning = true;
            UI.Menu(out userChoice);

            switch (userChoice) 
            {
                case eMenueOptions.EnterNewCar:
                    EnterNewVehicle();
                    break;
                case eMenueOptions.ShowLicensePlates:
                    ShowVehicleLicences();
                    break;
                case eMenueOptions.ChangeCarState:
                    ChangeCardStatus();
                    break;
                case eMenueOptions.InflateCarWheels:
                    InflateCarWheels();
                    break;
                case eMenueOptions.FuelUpVehicle:
                    FillVehicleFuel();
                    break;
                case eMenueOptions.ChargeUpVehicle:
                    ChargeElectricVehicle();
                    break;
                case eMenueOptions.FullShowCar:
                    FullCardShow();
                    break;
                case eMenueOptions.ChangeCarLoadSetting:
                    UI.ChangeWheelsSetupMenu();
                    break;
                default:
                    o_StillRunning = false;
                    break;

            }
        }

        internal void ShowVehicleLicences()
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

        internal void EnterNewVehicle()
        {
            string recivedLicense = UI.GetLicensePlate();
            List<string> recivedAttributes;
            GarageVehicleCard newCard;
            VehicleFactory.eVehicleOptions vehicleChosen;
            eVehicleStatus statusChosen;
            Vehicle newVehicle;
            bool checkSuccess;

            if (m_Garage.isVehicleInGarage(recivedLicense))
            {
                UI.CarInGarageMessage();
            }
            else
            {
                newCard = new GarageVehicleCard();
                recivedAttributes = UI.GetAttributes(newCard.GetAttributesList(), "Card Entry");
                newCard.EnterAtributes(recivedAttributes);
                vehicleChosen = UI.GetVehicleChoice();
                newVehicle = VehicleFactory.CreateVehicle(vehicleChosen, recivedLicense);
                newCard.CardVehicle = newVehicle;
                checkSuccess = false;
                while (!checkSuccess)
                {
                    try
                    {
                        recivedAttributes = UI.GetAttributes(newVehicle.GetAttributesList(), newVehicle.GetType().Name);
                        newVehicle.EnterAtributes(recivedAttributes);
                        checkSuccess = true;
                    }
                    catch (Exception i_Exception) 
                    {
                        UI.PrintExceptions(i_Exception);
                    }
                }

                UI.GetVehicleStatus(out statusChosen);
                newCard.VehicleStatus = statusChosen;
                m_Garage.AddCardToList(newCard);
            }
        }

        internal void ChangeCardStatus()
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

        internal void InflateCarWheels() 
        {
            string recivedLicense = UI.GetLicensePlate();
            GarageVehicleCard foundCard = m_Garage.FindVehicle(recivedLicense);

            if (foundCard != null)
            {
                try
                {
                    foundCard.CardVehicle.FillWheelsToMax();
                }
                catch(Exception i_Exception)
                {
                    UI.PrintExceptions(i_Exception);
                }
            }
            else
            {
                UI.PrintExceptions(new Exception("Card Could not be found!"));
            }
        }

        internal void FillVehicleFuel()
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

        internal void ChargeElectricVehicle()
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
    }
}

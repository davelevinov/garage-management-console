using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal static class UserInterface
    {
        private const string k_MainMenuText =
     @"Please choose from the following options (1-9):
        1. Add a new vehicle to garage.
        2. Display plate numbers for all vehicles in the garage.
        3. Display plate numbers for vehicles filtered by garage status.
        4. Modify a vehicle's status.
        5. Inflate a vehicle's wheels to maximum.
        6. Refuel a fuel-powered vehicle.
        7. Charge an electric vehicle.
        8. Display full details of a vehicle.
        9. Quit.
        ";

        private static Garage s_Garage = new Garage();
        private static bool s_ExitProgram = false;

        private enum eMenuOption
        {
            AddVehicle,
            DisplayPlateNumbers,
            DisplayFilteredPlateNumbers,
            ModifyVehicleStatus,
            InflateVehicleWheels,
            RefuelFuelVehicle,
            ChargeElectricVehicle,
            DisplayVehicleProperties,
            QuitProgram
        }

        public static void Runner()
        {
            eMenuOption menuOptionEnum;
            int userMenuSelection;
            string inputAsString;
            Console.WriteLine(
                              string.Format(
                              "Hello, welcome to Monster Garage!{0}If you are ready to make your vehicle monstered, please press Enter ;)",
                              Environment.NewLine));
            Console.ReadLine();

            while (!s_ExitProgram)
            {
                try
                {
                    Console.Clear();
                    showMainMenu();
                    inputAsString = Console.ReadLine();
                    userMenuSelection = parseUserSelection(inputAsString, Enum.GetNames(typeof(eMenuOption)).Length);
                    menuOptionEnum = (eMenuOption)Enum.GetValues(typeof(eMenuOption)).GetValue(userMenuSelection - 1);
                    executeMenuSelection(menuOptionEnum);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input format");
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: exiting program");
                    s_ExitProgram = true;
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }

        private static void executeMenuSelection(eMenuOption i_MenuOption)
        {
            switch (i_MenuOption)
            {
                case eMenuOption.AddVehicle:
                    addVehicleToGarage();
                    break;
                case eMenuOption.DisplayPlateNumbers:
                    displayAllPlateNumbers();
                    break;
                case eMenuOption.DisplayFilteredPlateNumbers:
                    DisplayFilteredPlateNumbers();
                    break;
                case eMenuOption.ModifyVehicleStatus:
                    modifyVehicleStatus();
                    break;
                case eMenuOption.InflateVehicleWheels:
                    inflateVehicleWheels();
                    break;
                case eMenuOption.RefuelFuelVehicle:
                    fillFuelInVehicle();
                    break;
                case eMenuOption.ChargeElectricVehicle:
                    chargeElectricVehicle();
                    break;
                case eMenuOption.DisplayVehicleProperties:
                    displayVehicleProperties();
                    break;
                case eMenuOption.QuitProgram:
                    exitProgram();
                    break;
                default:
                    break;
            }
        }

        private static void displayAllPlateNumbers()
        {
            List<string> plateNumbers = s_Garage.GetPlateNumbers();

            if (plateNumbers.Count > 0)
            {
                foreach (string currentPlate in plateNumbers)
                {
                    Console.WriteLine(currentPlate);
                }
            }
            else
            {
                Console.WriteLine("Garage is empty");
            }
        }

        private static void DisplayFilteredPlateNumbers()
        {
            eVehicleStatusInGarage filter = (eVehicleStatusInGarage)getUserChoiceFromEnumValues(typeof(eVehicleStatusInGarage));
            List<string> plateNumbers = s_Garage.GetPlateNumbers(filter);
            foreach (string currentPlate in plateNumbers)
            {
                Console.WriteLine(currentPlate);
            }
        }

        private static void modifyVehicleStatus()
        {
            Console.WriteLine("Please enter a plate number");
            string plateNumber = Console.ReadLine();
            eVehicleStatusInGarage newVehicleStatus = (eVehicleStatusInGarage)getUserChoiceFromEnumValues(typeof(eVehicleStatusInGarage));
            s_Garage.ChangeVehicleStatus(plateNumber, newVehicleStatus);
            Console.WriteLine("Vehicle status changed successfully");
        }

        private static void inflateVehicleWheels()
        {
            Console.WriteLine("Please enter a plate number");
            string plateNumber = Console.ReadLine();
            s_Garage.InflateVehicleWheelsToMax(plateNumber);
        }

        private static void fillFuelInVehicle()
        {
            float fuelToFill;
            Console.WriteLine("Please enter a plate number: ");
            string plateNumber = Console.ReadLine();
            FuelTank.eFuelType fuelType = (FuelTank.eFuelType)getUserChoiceFromEnumValues(typeof(FuelTank.eFuelType));
            Console.WriteLine("Please enter how many liters of fuel to add: ");
            string fuelAmountAsString = Console.ReadLine();
            if (!float.TryParse(fuelAmountAsString, out fuelToFill))
            {
                throw new FormatException();
            }

            s_Garage.FillFuelInVehicle(plateNumber, fuelType, fuelToFill);
            Console.WriteLine("Fuel was added successfully");
        }

        private static void chargeElectricVehicle()
        {
            float chargeAmount;
            Console.WriteLine("Please enter plate number: ");
            string plateNumber = Console.ReadLine();
            Console.WriteLine("Please enter how many minutes to charge: ");
            string chargeAmountAsString = Console.ReadLine();
            if (!float.TryParse(chargeAmountAsString, out chargeAmount))
            {
                throw new FormatException();
            }

            s_Garage.ChargeElectricVehicle(plateNumber, chargeAmount);
            Console.WriteLine("Charged successfully");
        }

        private static void displayVehicleProperties()
        {
            Console.WriteLine("Please enter plate number: ");
            string plateNumber = Console.ReadLine();
            Console.WriteLine(s_Garage.GetVehicleData(plateNumber));
        }

        private static void exitProgram()
        {
            Console.WriteLine("Goodbye");
            s_ExitProgram = true;
        }

        private static void addVehicleToGarage()
        {
            bool vehicleIsAlreadyInGarage;
            Vehicle vehicleToAdd;
            vehicleToAdd = getVehicleFromUser();
            vehicleIsAlreadyInGarage = s_Garage.AddVehicleToGarage(vehicleToAdd);
       
            if (vehicleIsAlreadyInGarage)
            {
                Console.WriteLine(string.Format("A vehicle with that plate number already exists, choose another option"));                    
            }
            else
            {
                Console.WriteLine("Vehicle was added succesfully");
            }
        }

        private static Vehicle getVehicleFromUser()
        {
            Vehicle createdVehicle = null;
            DetailsOfVehicle createdVehicleData = null;
            List<object> userEnteredProperties;
            Vehicle.eVehicleType typeOfVehicleToAdd = (Vehicle.eVehicleType)getUserChoiceFromEnumValues(typeof(Vehicle.eVehicleType));

            switch (typeOfVehicleToAdd)
            {
                case Vehicle.eVehicleType.FuelCar:
                    userEnteredProperties = getPropertiesFromUser(DetailsOfFuelCar.GetRequiredProperties());
                    createdVehicleData = new DetailsOfFuelCar(
                                                               (string)userEnteredProperties[0],
                                                               (string)userEnteredProperties[1],
                                                               (string)userEnteredProperties[2],
                                                               (string)userEnteredProperties[3],
                                                               (string)userEnteredProperties[4],
                                                               (Car.eCarColor)userEnteredProperties[5],
                                                               (Car.eNumberOfDoors)userEnteredProperties[6]);
                    break;
                case Vehicle.eVehicleType.ElectricCar:
                    userEnteredProperties = getPropertiesFromUser(DetailsOfElectricCar.GetRequiredProperties());
                    createdVehicleData = new DetailsOfElectricCar(
                                                                (string)userEnteredProperties[0],
                                                                (string)userEnteredProperties[1],
                                                                (string)userEnteredProperties[2],
                                                                (string)userEnteredProperties[3],
                                                                (string)userEnteredProperties[4],
                                                                (Car.eCarColor)userEnteredProperties[5],
                                                                (Car.eNumberOfDoors)userEnteredProperties[6]);
                    break;
                case Vehicle.eVehicleType.ElectricMotorcycle:
                    userEnteredProperties = getPropertiesFromUser(DetailsOfElectricMotorcycle.GetRequiredProperties());
                    createdVehicleData = new DetailsOfElectricMotorcycle(
                                                                (string)userEnteredProperties[0],
                                                                (string)userEnteredProperties[1],
                                                                (string)userEnteredProperties[2],
                                                                (string)userEnteredProperties[3],
                                                                (string)userEnteredProperties[4],
                                                                (Motorcycle.eMotorcycleLicenseType)userEnteredProperties[5],
                                                                (int)userEnteredProperties[6]);
                    break;
                case Vehicle.eVehicleType.FuelMotorcycle:
                    userEnteredProperties = getPropertiesFromUser(DetailsOfFuelMotorcycle.GetRequiredProperties());
                    createdVehicleData = new DetailsOfFuelMotorcycle(
                                                                (string)userEnteredProperties[0],
                                                                (string)userEnteredProperties[1],
                                                                (string)userEnteredProperties[2],
                                                                (string)userEnteredProperties[3],
                                                                (string)userEnteredProperties[4],
                                                                (Motorcycle.eMotorcycleLicenseType)userEnteredProperties[5],
                                                                (int)userEnteredProperties[6]);
                    break;
                case Vehicle.eVehicleType.Truck:
                    userEnteredProperties = getPropertiesFromUser(DetailsOfFuelTruck.GetRequiredProperties());
                    createdVehicleData = new DetailsOfFuelTruck(
                                                               (string)userEnteredProperties[0],
                                                               (string)userEnteredProperties[1],
                                                               (string)userEnteredProperties[2],
                                                               (string)userEnteredProperties[3],
                                                               (string)userEnteredProperties[4],
                                                               (float)userEnteredProperties[5],
                                                               (bool)userEnteredProperties[6]);
                    break;
                default:
                    break;
            }

            createdVehicle = VehicleCreator.MakeVehicle(typeOfVehicleToAdd, createdVehicleData);

            return createdVehicle;
        }

        private static List<object> getPropertiesFromUser(List<VehicleProperty> i_VehicleRequiredProperties)
        {
            List<object> userEnteredProperties = new List<object>();
            string message;
            string userInputAsString;

            foreach (VehicleProperty currentProperty in i_VehicleRequiredProperties)
            {
                // hazardous material check
                if (currentProperty.Type == typeof(bool))
                {
                    message = string.Format(
                                           "Please choose {1}:{0}Enter 1 for 'yes' or 2 for 'no'.",
                                            Environment.NewLine,
                                            currentProperty.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    while(userInputAsString != "1" && userInputAsString != "2")
                    {
                        Console.WriteLine(message);
                        userInputAsString = Console.ReadLine();
                    }

                    if (userInputAsString.Equals("1"))
                    {
                        userEnteredProperties.Add(true);
                    }
                    else if (userInputAsString.Equals("2"))
                    {
                        userEnteredProperties.Add(false);
                    }
                }
                else if (currentProperty.Type == typeof(int))
                {
                    int value;
                    message = string.Format("Please enter {0} (an integer number):", currentProperty.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    bool isNumber = int.TryParse(userInputAsString, out value);
                    if (isNumber)
                    {
                        userEnteredProperties.Add(value);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                else if (currentProperty.Type == typeof(float))
                {
                    float value;
                    message = string.Format("Please enter {0} (a number):", currentProperty.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    bool isFloat = float.TryParse(userInputAsString, out value);
                    if (isFloat)
                    {
                        userEnteredProperties.Add(value);
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }                
                else if (currentProperty.Type == typeof(string))
                {
                    message = string.Format("Please enter {0}: ", currentProperty.Description);
                    Console.WriteLine(message);
                    userInputAsString = Console.ReadLine();
                    userEnteredProperties.Add(userInputAsString);
                }
                else if (currentProperty.Type.IsEnum)
                {
                    Console.WriteLine(
                                    string.Format(
                                    "Please enter {0}.",
                                    currentProperty.Description));
                    userEnteredProperties.Add(getUserChoiceFromEnumValues(currentProperty.Type));
                }
            }

            return userEnteredProperties;
        }

        private static object getUserChoiceFromEnumValues(Type i_Enum)
        {
            object enumValueToReturn = null;
            if (!i_Enum.IsEnum)
            {
                throw new ArgumentException();
            }

            Console.WriteLine("choose one of the following: ");
            int currentValueIndex = 1;

            foreach (object enumValue in Enum.GetValues(i_Enum))
            {
                Console.WriteLine(string.Format("{0}- {1}", currentValueIndex, enumValue));
                currentValueIndex++;
            }

            string textualIndexOfEnumValue = Console.ReadLine();
            int userInputtedIndexOfEnumValue;
            bool isNumber = int.TryParse(textualIndexOfEnumValue, out userInputtedIndexOfEnumValue);

            if (!isNumber)
            {
                throw new FormatException();
            }

            if (userInputtedIndexOfEnumValue < 1 || userInputtedIndexOfEnumValue > currentValueIndex - 1)
            {
                throw new ValueOutOfRangeException(1, currentValueIndex - 1);
            }

            currentValueIndex = 1;
            foreach (object enumValue in Enum.GetValues(i_Enum))
            {
                if (userInputtedIndexOfEnumValue == currentValueIndex)
                {
                    enumValueToReturn = enumValue;
                    break;
                }

                currentValueIndex++;
            }

            return enumValueToReturn;
        }
        
        private static int parseUserSelection(string i_inputAsString, int i_RangeOfEnum)
        {
            int userSelection;

            if (!int.TryParse(i_inputAsString, out userSelection))
            {
                throw new FormatException("Invalid Input");
            }

            if (userSelection < 1 || userSelection > i_RangeOfEnum)
            {
                throw new ValueOutOfRangeException(1, i_RangeOfEnum);
            }

            return userSelection;
        }

        private static void showMainMenu()
        {
            Console.WriteLine(k_MainMenuText);
        }
    }
}
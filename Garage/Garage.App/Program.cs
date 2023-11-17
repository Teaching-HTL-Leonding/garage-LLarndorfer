
using System.Linq.Expressions;
using System.Security.Permissions;
using GarageLogic;

var garage = new Garage();

// var ihsgih = garage.ParkingSpots[7].licensePlate;
Console.OutputEncoding = System.Text.Encoding.Unicode;

string? input = null;
string? licenseplateinput = null;
DateTime userentertime;
DateTime userexittime;
int userparkingslot = 0;

do
{
    System.Console.WriteLine("What do you want to do?");
    System.Console.WriteLine("1) Enter a car entry");
    System.Console.WriteLine("2) Enter a car exit");
    System.Console.WriteLine("3) Generate a report");
    System.Console.Write("4) Exit \nYour selection: ");
    input = Console.ReadLine()!;

    switch (input)
    {
        case "1":
            System.Console.Write("Enter parking spot number: ");
            userparkingslot = int.Parse(Console.ReadLine()!) - 1;
            if (!garage.IsOccupied(userparkingslot))
            {
                System.Console.Write("Enter license plate: ");
                licenseplateinput = Console.ReadLine()!;
                System.Console.Write("Enter entry/date time:");
                userentertime = DateTime.Parse(Console.ReadLine()!);
                garage.ParkingSpots[userparkingslot] = new()
                {
                    entryDate = userentertime,
                    licensePlate = licenseplateinput
                };
            }
            else
            {
                System.Console.WriteLine("Parking spot is occupied");
            }
            break;

        case "2":
            System.Console.Write("Enter parking spot number: ");
            userparkingslot = int.Parse(Console.ReadLine()!) - 1;
            System.Console.Write("Enter exit date/time: ");
            userexittime = DateTime.Parse(Console.ReadLine()!);
            if (garage.TryExit(userparkingslot, userexittime, out var costs))
            {
                System.Console.WriteLine($"Costs are {costs}€");
            }
            else
            {
                System.Console.WriteLine("Parking spot is not occupied!");
            }
            break;

        case "3":
            var text = garage.GenerateReport();
            
            foreach (var t in text)
            {
                System.Console.WriteLine(t);
            }
            break;

        case "4":
            System.Console.WriteLine("Goodbye!");
            break;
        default:
            throw new ArgumentException("Invalid type of Input.");
    }
} while (input != "4");


namespace GarageLogic;

public class ParkingSpot
{
    public string? licensePlate { get; set; }

    public DateTime entryDate { get; set; }
}

public class Garage
{
    public ParkingSpot[] ParkingSpots { get; } = new ParkingSpot[50];

    public bool IsOccupied(int parkingSpotNumber)
    {
        if (ParkingSpots[parkingSpotNumber] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryOccupy(int parkingSpotNumber, string licensePlate, DateTime entryTime)
    {
        if (ParkingSpots[parkingSpotNumber] == null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool TryExit(int parkingSpotNumber, DateTime exitTime, out decimal costs)
    {
        if (IsOccupied(parkingSpotNumber))
        {
            if ((exitTime.Subtract(ParkingSpots[parkingSpotNumber].entryDate).TotalMinutes) > 15)
            {
                costs = (decimal)Math.Ceiling((exitTime.Subtract(ParkingSpots[parkingSpotNumber].entryDate).TotalMinutes) / 15) * 3;
            }
            else
            {
                costs = 0;
            }
            ParkingSpots[parkingSpotNumber] = null;
            return true;

        }
        else
        {
            costs = 0;
            return false;
        }

    }

    public string[] GenerateReport()
    {
        string[] text = new string[52];
        text[0] = "| Spot | License Plate |";
        text[1] = "| ---- | ------------- |";
        for (int i = 0; i < ParkingSpots.Length; i++)
        {
            if (ParkingSpots[i] != null)
            {
                if (i < 9)
                {
                    text[i + 2] = $"|  {i + 1}   | {ParkingSpots[i].licensePlate}";
                }
                else
                {
                    text[i + 2] = $"|  {i + 1}  | {ParkingSpots[i].licensePlate}";
                }
            }

            else
            {
                if (i < 9)
                {
                    text[i + 2] = $"|  {i + 1}   | - |";
                }
                else
                {
                    text[i + 2] = $"|  {i + 1}  | - |";
                }
            }
        }

        return text;
    }
}

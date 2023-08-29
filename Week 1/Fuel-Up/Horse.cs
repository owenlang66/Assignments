public class Horse : Vehicle, INeedFuel
{
    public string FuelType{get;set;}
    public int FuelTotal{get;set;}
    public Horse() : base ("Horse", 1, "black", false, 45000)
    {
        FuelType = "Apples";
        FuelTotal = 10;
    }

    public void GiveFuel(int amt)
    {
        FuelTotal += amt;
    }
}
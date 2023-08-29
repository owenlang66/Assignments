public class Car : Vehicle, INeedFuel
{
    public string FuelType{get;set;}
    public int FuelTotal{get;set;}
    public Car() : base ("Car", 5, "neon", true, 400000)
    {
        FuelType = "Gas";
        FuelTotal = 10;
    }

    public void GiveFuel(int amt)
    {
        FuelTotal += amt;
    }
}
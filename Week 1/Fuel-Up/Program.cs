
Car car = new Car();
Horse horse = new Horse();
Bicycle bicycle = new Bicycle();

// NOT HAPPY WITH THAT BECAUSE IT'S ABSTRACT
// Vehicle vehicle = new Vehicle();

List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(car);
AllVehicles.Add(horse);
AllVehicles.Add(bicycle);

List<INeedFuel> AllFuels = new List<INeedFuel>();

foreach (Vehicle vehicle in AllVehicles)
{
    if (vehicle is INeedFuel fuelVehicle)
    {
        AllFuels.Add(fuelVehicle);
    }
}

foreach (var fuelVehicle in AllFuels)
{
    fuelVehicle.GiveFuel(10);
}

foreach (var fuelVehicle in AllFuels)
{
    Console.WriteLine(fuelVehicle.GetType().Name);
    Console.WriteLine(fuelVehicle.FuelTotal);
}
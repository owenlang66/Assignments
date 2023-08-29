Vehicle Car1 = new Vehicle("Crap Car", 1, "Brown", false, 500000);
Vehicle Car2 = new Vehicle("Sabrina", "pink");
Vehicle Car3 = new Vehicle("Jim", "purple");
Vehicle Car4 = new Vehicle("Mop", "green");

List<Vehicle> vehicles = new List<Vehicle>();

vehicles.Add(Car1);
vehicles.Add(Car2);
vehicles.Add(Car3);
vehicles.Add(Car4);

foreach (Vehicle vehicle in vehicles)
{
    vehicle.ShowInfo();
}

vehicles[2].Travel(100);

vehicles[2].ShowInfo();

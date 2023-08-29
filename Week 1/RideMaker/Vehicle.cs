

public class Vehicle
{
    public string Name;
    public int Passengers;
    public string Color;
    public bool HasEngine;
    public int Miles;

    public Vehicle(string name, int passengers, string color, bool hasEngine, int miles)
    {
        Name = name;
        Passengers = passengers;
        Color = color;
        HasEngine = hasEngine;
        Miles = miles;
    }
    public Vehicle(string name, string color)
    {
        Name = name;
        Color = color;
        Passengers = 1;
        HasEngine = true;
        Miles = 40;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Here's some info! Name: {Name}, # of Passengers: {Passengers}, Color: {Color}, Does it have an engine: {HasEngine}, Miles driven: {Miles}");
    }
    public void Travel(int distance)
    {
        Miles += distance;
        Console.WriteLine($"This vehicle has gone {Miles} miles! That's nutso!");
    }
}

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

Eruption firstChile = eruptions.FirstOrDefault(c => c.Location == "Chile");
Console.WriteLine(firstChile);


Eruption firstHaw = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
if (firstHaw != null)
{
    Console.WriteLine(firstHaw.ToString());
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found");
}


Eruption firstGreen = eruptions.FirstOrDefault(c => c.Location == "Greenland");
if (firstGreen != null)
{
    Console.WriteLine(firstGreen.ToString());
}
else
{
    Console.WriteLine("No Greenland Eruption found");
}

Eruption newZ = eruptions.FirstOrDefault(c => c.Location == "New Zealand" && c.Year > 1900);
Console.WriteLine(newZ);


IEnumerable<Eruption> twoK = eruptions.Where(c => c.ElevationInMeters > 2000);
PrintEach(twoK);


IEnumerable<Eruption> leruptions = eruptions.Where(c => c.Volcano.StartsWith("L"));
int leruptionsCount = leruptions.Count();
PrintEach(leruptions);
Console.WriteLine(leruptionsCount);


int top = eruptions.Max(c => c.ElevationInMeters);
Console.WriteLine(top);


Eruption topName = eruptions.FirstOrDefault(c => c.ElevationInMeters == top);
Console.WriteLine(topName);


IEnumerable<Eruption> alpha = eruptions.Where(c => c.ElevationInMeters > 0).OrderBy(c => c.Volcano);
PrintEach(alpha);


int sum = eruptions.Sum(c => c.ElevationInMeters);
Console.WriteLine(sum);


bool any = eruptions.Any(c => c.Year == 2000);
Console.WriteLine(any);


IEnumerable<Eruption> strat = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(strat);


IEnumerable<Eruption> pre = eruptions.Where(c => c.Year < 1000);
PrintEach(pre);


IEnumerable<string> prepre = eruptions.Where(c => c.Year < 1000).Select(c => c.Volcano);
foreach(string name in prepre)
{
    Console.WriteLine(name);
}



// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
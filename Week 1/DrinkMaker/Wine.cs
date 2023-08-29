public class Wine : Drink
{
    public string Region;
    public int Year;
    public Wine(string region, int year) : base("Wine", "White", 40, false, 102)
    {
        Region = region;
        Year = year;
    }

        public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region?? {Region}. Gimme the year please {Year}");
    }
}
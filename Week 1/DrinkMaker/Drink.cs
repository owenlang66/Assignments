public class Drink
{
    public string Name;
    public string Color;
    public double Temperature;
    public bool IsCarbonated;
    public int Calories;
    
    // We need a basic constructor that takes all these features in
    public Drink(string name, string color, double temp, bool isCarb, int calories)
    {
    	Name = name;
    	Color = color;
    	Temperature = temp;
    	IsCarbonated = isCarb;
    	Calories = calories;
    }

    // virtual is specifying that this is only going to be called in the child
    public virtual void ShowDrink()
    {
        Console.WriteLine($"Here's some hot drink info for ya! {Name}, {Color}, Temp: {Temperature}, Is it carbonated?? {IsCarbonated}, Calories: {Calories}");
    }
}
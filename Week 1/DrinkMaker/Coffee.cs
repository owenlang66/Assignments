public class Coffee : Drink
{
    public string Roast;
    public string BeanType;
    public Coffee(string roast, string beanType) : base("Coffee", "Brown", 99, false, 50)
    {
        Roast = roast;
        BeanType = beanType;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast?? {Roast}. What's that wacky Bean type?? {BeanType}");
    }
}
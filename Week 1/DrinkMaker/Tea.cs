public class Tea : Drink
{
    public bool IsIced;
    public string Type;
    public Tea(bool isIced, string type) : base("Tea", "Brown", 101.1, false, 22)
    {
        IsIced = isIced;
        Type = type;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Is it iced?? {IsIced}. What's that wacky type?? {Type}");
    }
}
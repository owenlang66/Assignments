// 1. Coin Flip
static string CoinFlip()
{
    Random rand = new Random();
    if (rand.NextDouble() > 0.5)
    {
        return "Heads";
    }
    return "Tails";

}
Console.WriteLine(CoinFlip());

// 2. Dice Roll
static int DiceRoll()
{
    Random rand = new Random();
    int roll = rand.Next(1, 7);
    return roll;
}
Console.WriteLine(DiceRoll());

// 3. Stat Roll
static List<int> StatRoll()
{
    List<int> stats = new List<int>();
    for (int i = 0; i < 4; i++)
    {
        stats.Add(DiceRoll());
        // Console.WriteLine(stats[i]);
    }
    return stats;
}
StatRoll().ForEach(Console.WriteLine);


// 4. Roll Until
static string RollUntil(int Result)
{
    int count = 0;
    while (true)
    {
        int roll = DiceRoll();
        count++;
        if (roll == Result)
        {
            return ($"Rolled a {Result} after {count} tries!");
        }
    }
}
Console.WriteLine(RollUntil(3));

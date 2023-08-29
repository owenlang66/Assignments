public class RangedFighter : Enemy
{
    public int Distance;
    public RangedFighter() : base("Ranged Fighter", 70)
    {
        Distance = 5;
        AttackList.Add(new Attack("Arrow Shot", 20));
        AttackList.Add(new Attack("Knife Throw", 15));
    }

    public void Dash()
    {
        Distance = 20;
    }

    public override void PerformAttack (Enemy Target, Attack chosenAttack)
    {
        if (Distance <= 10)
        {
            Console.WriteLine("TOO CLOSE");
        }
        else
        {
            base.PerformAttack(Target, chosenAttack);
        }
    }
}
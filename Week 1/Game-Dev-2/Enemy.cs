public class Enemy
{
    public string Name;
    public int Health = 100;
    public List<Attack> AttackList;

    public Enemy (string name, int health)
    {
        Name = name;
        Health = health;
        AttackList = new List<Attack>();
    }

    public Attack RandomAttack()
    {
        Random rand = new Random();
        return AttackList[rand.Next(AttackList.Count)];
    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.Health -= ChosenAttack.DamageAmt;

        Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmt} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    }
}
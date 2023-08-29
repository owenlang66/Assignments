public class MagicCaster : Enemy
{
    public MagicCaster() : base("Magic Caster", 80)
    {
        AttackList.Add(new Attack("Fireball", 25));
        AttackList.Add(new Attack("Lightning Bolt", 20));
        AttackList.Add(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy Target)
    {
        Target.Health += 40;
        Console.WriteLine(Target.Health);
    } 
}
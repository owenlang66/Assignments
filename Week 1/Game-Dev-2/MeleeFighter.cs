public class MeleeFighter : Enemy
{


    public MeleeFighter() : base("Melee Fighter", 120)
    {
        AttackList.Add(new Attack("Punch", 20));
        AttackList.Add(new Attack("Kick", 15));
        AttackList.Add(new Attack("Tackle", 25));
    }

    public void Rage(Enemy Target)
    {
        Target.Health -= base.RandomAttack().DamageAmt+10;
    } 


}
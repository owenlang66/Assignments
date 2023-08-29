// Enemy Steve = new Enemy("Steve", 100);

// Attack Wink = new Attack("Wink", 25);
// Attack IcePunch = new Attack("Ice Punch", 5);
// Attack WhisperSecrets = new Attack("Whisper Secrets", 23);

// Steve.AttackList.Add(Wink);
// Steve.AttackList.Add(IcePunch);
// Steve.AttackList.Add(WhisperSecrets);

// Console.WriteLine(Steve.RandomAttack().Name);
// Steve.RandomAttack().Name;

MeleeFighter sam = new MeleeFighter();
RangedFighter rangedFighter = new RangedFighter();
MagicCaster magicCaster = new MagicCaster();

sam.PerformAttack(rangedFighter, sam.AttackList[1]);
sam.Rage(magicCaster);
rangedFighter.PerformAttack(sam, rangedFighter.AttackList[0]);
rangedFighter.Dash();
rangedFighter.PerformAttack(sam, rangedFighter.AttackList[0]);
magicCaster.PerformAttack(sam, magicCaster.AttackList[0]);
magicCaster.Heal(rangedFighter);
magicCaster.Heal(magicCaster);

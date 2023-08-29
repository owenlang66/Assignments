Enemy Steve = new Enemy("Steve");

Attack Wink = new Attack("Wink", 25);
Attack IcePunch = new Attack("Ice Punch", 5);
Attack WhisperSecrets = new Attack("Whisper Secrets", 23);

Steve.AttackList.Add(Wink);
Steve.AttackList.Add(IcePunch);
Steve.AttackList.Add(WhisperSecrets);

Console.WriteLine(Steve.RandomAttack().Name);
// Steve.RandomAttack().Name;
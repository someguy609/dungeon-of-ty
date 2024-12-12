namespace dungeon_of_ty;

public abstract class Move
{
	protected static Random _random = new();

	protected static readonly List<string> Words = new() { "punch", "kick", "talk", "walk", "should", "would", "could", "slap", "trap", "nap", "sap" };

	public readonly string Name;
	public readonly string Description;

	public abstract void Execute(Character source, Character target);
	public static string GetWord() { return Words[_random.Next(0, Words.Count)]; }

	public Move(string name, string description)
	{
		Name = name;
		Description = description;
	}
}

public class Punch : Move
{
	public Punch() : base("Punch", "Move your fist at an abnormal speed towards the target") { }

	public override void Execute(Character source, Character target)
	{
		target.Health -= source.Attack;
	}
}

public class Kick : Move
{
	public Kick() : base("Kick", "Perform a flailing kick like in Blue Lock") { }

	public override void Execute(Character source, Character target)
	{
		target.Health -= source.Attack * 2;
	}
}

public class Roll20 : Move
{
	public Roll20() : base("Roll 20", "Gain more luck or lose twice as much") { }

	public override void Execute(Character source, Character target)
	{
		source.Luck += _random.Next(1, 21) == 20 ? 0.1 : -0.2;
	}
}

public class Regenerate : Move
{
	public Regenerate() : base("Regenerate", "Heal over time over time") { }

	public override void Execute(Character source, Character target)
	{
		source.Buffs.Add(new Regenerating());
	}
}
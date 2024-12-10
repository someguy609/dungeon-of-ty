namespace dungeon_of_ty;

// public static class Moveset
// {
// 	public static Action<Character, Character> Punch = (source, target) => {
// 		target.Health -= ((int)Math.Floor(new Random().NextDouble() * source.Luck) + 1) * source.Attack;
// 	};

// 	public static Action<Character, Character> Kick = (source, target) => {
// 		target.Health -= source.Attack * 2;
// 	};

// 	public static Action<Character, Character> Kamikaze = (source, target) => {
// 		source.Health = 0;
// 		target.Health = 0;
// 	};
// }

public abstract class Move
{
	public string Name { get; set; }
	public string Description { get; set; }
	// public string MoveKey { get; set; }

	public abstract void Execute(Character source, Character target);

	public Move(string name, string description)
	{
		Name = name;
		Description = description;
		// MoveKey = key;
	}
}

public class Punch : Move 
{
	public Punch() : base("Punch", "Move your fist at an abnormal speed towards the target") {}

    public override void Execute(Character source, Character target)
    {
		target.Health -= source.Attack;
    }
}

public class Kick : Move 
{
	public Kick() : base("Kick", "Perform a flailing kick like in Blue Lock") {}

    public override void Execute(Character source, Character target)
    {
		target.Health -= source.Attack * 2;
    }
}
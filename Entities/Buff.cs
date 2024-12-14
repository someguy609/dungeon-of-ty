namespace dungeon_of_ty;

public abstract class Buff
{
	public readonly string Name;
	public readonly string Description;
	public readonly PictureBox Sprite;

	public abstract void Trigger(Character target);

	public Buff(string name, string description)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		if (string.IsNullOrEmpty(description))
			throw new EmptyDescriptionException();

		Name = name;
		Description = description;
	}
}

public abstract class TemporaryBuff : Buff
{
	private int _duration;
	private readonly int _maxDuration = int.MaxValue;

	public int Duration
	{
		get { return _duration; }
		set { _duration = Math.Min(value, _maxDuration); }
	}

	public TemporaryBuff(string name, string description, int duration) : base(name, description)
	{
		_maxDuration = duration;
		Duration = duration;
	}
}

public class Burning : TemporaryBuff
{
	public Burning(int duration = 3) : base("Burn", "It burns", duration) { }

	public override void Trigger(Character target)
	{
		target.Health -= 10;
	}
}

public class Regenerating : TemporaryBuff
{
	public Regenerating(int duration = 3) : base("Regen", "Heal over time", duration) { }

	public override void Trigger(Character target)
	{
		target.Health += 10;
	}
}
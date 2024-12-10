namespace dungeon_of_ty;

public abstract class Buff
{
	public string Name { get; set; }
	public string Description { get; set; }

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

public class Burn : Buff 
{
    public override void Trigger(Character target) {
		target.Health -= 10;
	}

    public Burn() : base("Burn", "It burns") {}
}
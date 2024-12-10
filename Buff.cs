namespace dungeon_of_ty;

public abstract class Buff
{
	private string _name;
	private string _description;
	public string Name { get { return _name; } }
	public string Description { get { return _description; } }

	public abstract void Trigger();

	public Buff(string name, string description)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		if (string.IsNullOrEmpty(description))
			throw new EmptyDescriptionException();

		_name = name;
		_description = description;
	}
}
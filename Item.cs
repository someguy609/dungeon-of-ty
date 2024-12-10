namespace dungeon_of_ty;

public abstract class Item
{
	private string _name;
	public string Name { get { return _name; }}

	public abstract void Use();

	public Item(string name)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();

		_name = name;
	}
}
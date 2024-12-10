namespace dungeon_of_ty;

public abstract class Item
{
	public string Name { get; set; }

	public abstract void Use();

	public Item(string name)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		
		Name = name;
	}
}
namespace dungeon_of_ty;

public abstract class Item
{
	public string Name { get; set; }
	public string Description { get; set; }

	public abstract void Use(Character target);

	public Item(string name, string description)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();

		Name = name;
		Description = description;
	}
}

public class Inventory
{
	public int Capacity { get; set; } = 10;
	public List<Item> Items = new();

	public void Add(Item item)
	{
		if (Items.Count + 1 > Capacity)
			throw new Exception("Inventory capacity exceeded");
		
		Items.Add(item);
	}

	public void Add(Item item, int amount)
	{
		if (Items.Count + amount > Capacity)
			throw new Exception("Inventory capacity exceeded");
		
		while (amount-- > 0)
			Items.Add(item);
	}

	public void UseItem(Item item)
	{
		Items.Remove(item); // for now
	}

	public Inventory(int capacity = 10)
	{
		Capacity = capacity;
	}
}

public class RedSauce : Item
{
	public RedSauce() : base("Red Sauce", "This bland sauce somehow heals people") {}

    public override void Use(Character target)
    {
		target.Health += 10; // might need to change this
	}
}
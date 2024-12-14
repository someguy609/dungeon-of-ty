namespace dungeon_of_ty;

public abstract class Item
{
	public readonly string Name;
	public readonly string Description;
	public readonly PictureBox Sprite;

	public abstract void Use(Character target);

	public Item(string name, string description)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		if (string.IsNullOrEmpty(description))
			throw new EmptyDescriptionException();

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
			throw new InventoryCapacityExceededException();
		
		Items.Add(item);
	}

	public void Add(Item item, int amount)
	{
		if (Items.Count + amount > Capacity)
			throw new InventoryCapacityExceededException();
		
		while (amount-- > 0)
			Items.Add(item);
	}

	public void UseItem(Character target, Item item)
	{
		item.Use(target);
		Items.Remove(item);
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
		target.Health += 100; // might need to change this
	}
}
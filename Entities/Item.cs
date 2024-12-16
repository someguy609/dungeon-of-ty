namespace dungeon_of_ty;

public abstract class Item
{
	public readonly string Name;
	public readonly string Description;
	public readonly PictureBox? Sprite;

	public abstract void Use(Character target, int wordCount);

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

	public void UseItem(Character target, Item item, int wordCount)
	{
		item.Use(target, wordCount);
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

    public override void Use(Character target, int wordCount)
    {
		target.Health += 10 + (int)Math.Floor(wordCount * (target.Luck + 1));
	}
}

public class KarateManual : Item
{
	public KarateManual() : base("Karate Manual", "Yeah apparently someone made a manual about this") {}

    public override void Use(Character target, int wordCount)
    {
		target.Attack += 10 + (int)Math.Floor(wordCount * (target.Luck + 1));
    }
}

public class MildMender : Item
{
	public MildMender() : base("Mild Mender", "Mends your physique mildly") {}

    public override void Use(Character target, int wordCount)
    {
		target.Buffs.Add(new Regenerating((int)Math.Max(
			1, 
			Math.Ceiling(wordCount * (target.Luck + 1))
		)));
    }
}
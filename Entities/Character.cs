namespace dungeon_of_ty;

public abstract class Character
{
	protected static Random _random = new();
	public PictureBox? Sprite;

	private int _health = 100;

	public readonly string Name;
	public int Health
	{
		get { return _health; }
		set { _health = Math.Min(value, MaxHealth); }
	}
	public int MaxHealth { get; set; } = 100;
	public int Attack { get; set; } = 100;
	public double Luck { get; set; } = 0.1;
	public Inventory Inventory = new();
	public List<Buff> Buffs = new();

	public Character(string name, int health, int attack, double luck)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		if (health < 0)
			throw new NegativeHealthException();
		if (attack < 0)
			throw new NegativeAttackException();

		Name = name;
		Health = health;
		Attack = attack;
		Luck = luck;
	}

	public void OnStartTurn()
	{
		foreach (Buff buff in Buffs)
		{
			buff.Trigger(this);

			if (buff is TemporaryBuff tempBuff)
			{
				tempBuff.Duration -= 1;

				if (tempBuff.Duration == 0)
					Buffs.Remove(buff);
			}
		}
	}

	public abstract void Fight(Character target);

	public void UseItem(Item item, int wordCount)
	{
		Inventory.UseItem(this, item, wordCount);
	}

	public bool Flee()
	{
		return Luck > _random.NextDouble();
	}
}
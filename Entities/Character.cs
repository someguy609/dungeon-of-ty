namespace dungeon_of_ty;

public abstract class Character
{
	protected Random _random = new();

	private int _health = 100;

	public readonly string Name;
	public int Health
	{
		get { return _health; }
		set { _health = Math.Min(value, MaxHealth); }
	}
	public int MaxHealth { get; set; } = 100;
	public int Attack { get; set; } = 100;
	public int Defense { get; set; } = 100;
	public double Luck { get; set; } = 0.1;
	public Inventory Inventory = new();
	public Dictionary<string, Move> Moves = new();
	public List<Buff> Buffs = new();

	public Character(string name, int health, int attack, int defense, double luck)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		if (health < 0)
			throw new NegativeHealthException();
		if (attack < 0)
			throw new NegativeAttackException();
		if (defense < 0)
			throw new NegativeDefenseException();

		Name = name;
		Health = health;
		Attack = attack;
		Defense = defense;
		Luck = luck;
	}

	public abstract Control GetRenderedItems();

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

	public virtual void OnEndTurn() { }

	public void Fight(Character target, string? move = null)
	{
		if (string.IsNullOrEmpty(move))
		{
			Moves.ElementAt(_random.Next(0, Moves.Count)).Value.Execute(this, target);
			return;
		}

		Moves[move].Execute(this, target);
	}

	public bool Flee()
	{
		return Luck > _random.NextDouble();
	}
}
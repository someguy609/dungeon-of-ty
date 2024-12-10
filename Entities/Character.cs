namespace dungeon_of_ty;

public abstract class Character 
{
	public string Name { get; set; }
	public int Health { get; set; } = 100;
	public int MaxHealth { get; set; } = 100;
	public int Attack { get; set; } = 100;
	public int Defense { get; set; } = 100;
	public double Luck { get; set; } = 0.1;
	public Inventory Inventory = new();
	public Dictionary<string, Move> Moves = new();
	public List<Buff> Buffs = new();

	public abstract Control GetRenderedItems();

	public void OnStartTurn()
	{
		foreach (Buff buff in Buffs)
		{
			buff.Trigger(this);
			// add counter to remove buff upon 0
		}
	}

	public virtual void OnEndTurn() {}
	
	public Character(string name, int health, int attack, int defense, float luck)
	{
		Name = name;
		Health = health;
		Attack = attack;
		Defense = defense;
		Luck = luck;
	}
}
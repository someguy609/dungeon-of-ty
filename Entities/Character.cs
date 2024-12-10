namespace dungeon_of_ty;

public abstract class Character 
{
	private string _name;
	private int _health;
	private int _maxHealth;
	private int _attack;
	private int _defense;
	public string Name { get { return _name; } }
	public int Health { get { return _health; } }
	public int MaxHealth { get { return _maxHealth; } }
	public int Attack { get { return _attack; } }
	public int Defense { get { return _defense; } }
	public List<Buff> Buffs = new List<Buff>();

	public abstract Control GetRenderedItems();
	public abstract void StartTurn();
	public abstract void EndTurn();

	public void OnStartTurn()
	{
		foreach (Buff buff in Buffs)
			buff.Trigger();
		
		StartTurn();
	}

	public void OnEndTurn()
	{
		// do something idk
		
		EndTurn();
	}
	
	public Character(string name, int health, int attack, int defense)
	{
		if (string.IsNullOrEmpty(name))
			throw new EmptyNameException();
		if (health < 0)
			throw new NegativeHealthException();
		if (attack < 0)
			throw new NegativeAttackException();
		if (_defense < 0)
			throw new NegativeDefenseException();

		_name = name;
		_health = health;
		_maxHealth = health;
		_attack = attack;
		_defense = defense;
	}
}
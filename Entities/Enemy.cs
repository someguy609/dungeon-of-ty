namespace dungeon_of_ty;

public enum EnemyState
{
	AGGRESSIVE,
	DEFENSIVE
}

public class Enemy : Character
{
	private EnemyState _state;
	
	public Enemy(string name, int health, int attack, double luck) : base(name, health, attack, luck)
	{
		Sprite = new PictureBox
		{
			Size = new Size(100, 100),
			BackColor = Color.Gray,
		};

		_state = EnemyState.AGGRESSIVE;
	}

    public override void Fight(Character target)
    {
		target.Health -= Attack + (int)Math.Ceiling(_random.Next(Vocabulary.Words.Count) * (1 + Luck));
    }

    public void Update()
	{
		_state = Health <= MaxHealth / 3 ? EnemyState.DEFENSIVE : EnemyState.AGGRESSIVE;
	}

	public void TakeTurn(Character player)
	{
		Update();

		switch (_state)
		{
			case EnemyState.AGGRESSIVE:
				Fight(player);
				break;
			case EnemyState.DEFENSIVE:
				if (Flee()) Health = 0; // for now
				break;
		}
	}

	public Item? DropItem()
	{
		if (Inventory.Items.Count == 0)
			return null;
		return Inventory.Items[_random.Next(Inventory.Items.Count)];
	}
}
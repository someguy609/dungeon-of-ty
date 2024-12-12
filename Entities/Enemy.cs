namespace dungeon_of_ty;

public enum EnemyState
{
	AGGRESSIVE,
	DEFENSIVE
}

public class Enemy : Character
{
	private EnemyState _state;
	
	public Enemy(string name, int health, int attack, int defense, double luck) : base(name, health, attack, defense, luck)
	{
		Moves.Add(new Kick());
		_state = EnemyState.AGGRESSIVE;
	}

    public override void Fight(Character target)
    {
		Moves.ElementAt(_random.Next(0, Moves.Count)).Execute(this, target);
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

	public override Control GetRenderedItems()
	{
		return null; // TODO
	}
}
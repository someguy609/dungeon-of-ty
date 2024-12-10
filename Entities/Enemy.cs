namespace dungeon_of_ty;

// public class Enemy : Character
// {
// 	private PictureBox _sprite;

// 	public Enemy(Size screenSize) : base("enemy", 100, 100, 100)
// 	{
//         _sprite = new PictureBox
// 		{
// 			Size = new Size(100, 100),
// 			SizeMode = PictureBoxSizeMode.StretchImage,
// 			// Location = new Point(screenSize.Width / 2 - 25, 70),
// 			Anchor = AnchorStyles.None,
// 		};

// 		try
// 		{
// 			// _sprite.Image = Resource.hands;
// 			throw new Exception();
// 		}
// 		catch (Exception ex)
// 		{
// 			_sprite.BackColor = Color.Black;
// 		}
//     }

//     public override Control GetRenderedItems()
//     {
//         return _sprite;
//     }
// }

public enum EnemyState
{
	AGGRESSIVE,
	DEFENSIVE
}

public class Enemy : Character
{
	private EnemyState _state;
	public Enemy(string name, int health, int attack, int defense, float luck) : base(name, health, attack, defense, luck)
	{
		Moves.Add("kick", new Kick());
		_state = EnemyState.AGGRESSIVE;
	}

	public void Update()
	{
		_state = Health <= MaxHealth / 3? EnemyState.DEFENSIVE : EnemyState.AGGRESSIVE;
	}

	public void ExecuteAction(Character player)
	{
		switch (_state)
		{
			case EnemyState.AGGRESSIVE:
				Moves["kick"].Execute(this, player);
				break;
			case EnemyState.DEFENSIVE:
				// flee logic here
				break;
		}
	}

	public override Control GetRenderedItems()
	{
		return new Control();
	}
}
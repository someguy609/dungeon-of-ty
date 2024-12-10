namespace dungeon_of_ty;

// public class Player : Character
// {
// 	// private PictureBox _hands;

//     public Player(Size screenSize) : base("player", 100, 100, 100)
// 	{
// 		// Moves.Add("punch", Moveset.Punch);
// 		Moves.Add("kick", new Kick());
// 		Buffs.Add(new Burn());

// 		// _hands = new PictureBox
// 		// {
// 		// 	Dock = DockStyle.Bottom,
// 		// 	Size = new Size(screenSize.Width, 200),
// 		// 	SizeMode = PictureBoxSizeMode.StretchImage,
// 		// };

// 		// try
// 		// {
// 		// 	// _hands.Image = Resource.hands;
// 		// 	throw new Exception();
// 		// }
// 		// catch (Exception ex)
// 		// {
// 		// 	_hands.BackColor = Color.Black;
// 		// }
// 	}

//     public override Control GetRenderedItems()
//     {
//         return new Control();
//     }
// }

public class Player : Character
{
	public Player(string name, int health, int attack, int defense, float luck) : base(name, health, attack, defense, luck) {}

    public override Control GetRenderedItems()
    {
        return new Control();
    }
}
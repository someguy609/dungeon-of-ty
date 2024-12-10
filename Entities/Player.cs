namespace dungeon_of_ty;

public class Player : Character
{
	private PictureBox _hands;

    public Player(Size screenSize) : base("player", 100, 100, 100)
	{
		_hands = new PictureBox
		{
			Dock = DockStyle.Bottom,
			Size = new Size(screenSize.Width, 200),
			SizeMode = PictureBoxSizeMode.StretchImage,
		};

		try
		{
			// _hands.Image = Resource.hands;
			throw new Exception();
		}
		catch (Exception ex)
		{
			_hands.BackColor = Color.Black;
		}
	}

	public override void StartTurn()
	{
        throw new NotImplementedException();
	}

    public override void EndTurn()
    {
        throw new NotImplementedException();
    }

    public override Control GetRenderedItems()
    {
        return _hands;
    }
}
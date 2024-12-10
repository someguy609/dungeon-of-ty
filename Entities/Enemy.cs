namespace dungeon_of_ty;

public class Enemy : Character
{
	private PictureBox _sprite;

	public Enemy(Size screenSize) : base("enemy", 100, 100, 100)
	{
        _sprite = new PictureBox
		{
			Size = new Size(100, 100),
			SizeMode = PictureBoxSizeMode.StretchImage,
			// Location = new Point(screenSize.Width / 2 - 25, 70),
			Anchor = AnchorStyles.None,
		};

		try
		{
			// _sprite.Image = Resource.hands;
			throw new Exception();
		}
		catch (Exception ex)
		{
			_sprite.BackColor = Color.Black;
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
        return _sprite;
    }
}
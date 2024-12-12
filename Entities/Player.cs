namespace dungeon_of_ty;

public class Player : Character
{
    private Move _currentMove;
    public string MoveKey { get; private set; }

	public Player(string name, int health, int attack, int defense, double luck) : base(name, health, attack, defense, luck) 
    {
        Moves.Add(new Punch());
        Moves.Add(new Kick());

        _sprite = new PictureBox
        {
            Dock = DockStyle.Bottom,
            Anchor = AnchorStyles.Bottom,
            Size = new Size(800, 100),
            BackColor = Color.Gray,
        };
    }

    public void GetNewMove() 
    {
        _currentMove = Moves[_random.Next(0, Moves.Count)];
        MoveKey = Move.GetWord();
    }

    public override void Fight(Character target)
    {
        _currentMove.Execute(this, target);
        GetNewMove();
    }

    public void Learn()
	{
	}

    public override Control GetRenderedItems()
    {
        return _sprite; // TODO
    }
}
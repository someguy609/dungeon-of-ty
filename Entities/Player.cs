namespace dungeon_of_ty;

public class Player : Character
{
    public Move CurrentMove { get; private set; }

	public Player(string name, int health, int attack, int defense, double luck) : base(name, health, attack, defense, luck) 
    {
        Moves.Add(new Punch());
        Moves.Add(new Kick());

        _sprite = new PictureBox
        {
            Size = new Size(800, 100),
            BackColor = new Color(),
        };
    }

    public void GetNewMove() 
    {
        CurrentMove = Moves[_random.Next(0, Moves.Count)];
    }

    public override void Fight(Character target)
    {
        CurrentMove.Execute(this, target);
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
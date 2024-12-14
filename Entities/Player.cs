namespace dungeon_of_ty;

public class Player : Character
{
    private Move? _currentMove;
    private int _wordCount = 0;
    public string? MoveKey { get; private set; }
    public int WordCount
    {
        get { return _wordCount; }
        set { _wordCount = value; }
    }

	public Player(string name, int health, int attack, int defense, double luck) : base(name, health, attack, defense, luck) 
    {
        Moves.Add(new Punch());
        Moves.Add(new Kick());
        Inventory.Add(new RedSauce());
        Inventory.Add(new RedSauce());
        Inventory.Add(new RedSauce());
        Inventory.Add(new RedSauce());

        Sprite = new PictureBox
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
        _currentMove?.Execute(this, target); // null forgiving di sini itu emg bisa kek gmn dah?
        GetNewMove();
    }
}
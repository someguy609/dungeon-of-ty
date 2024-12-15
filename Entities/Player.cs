namespace dungeon_of_ty;

public enum PlayerState
{
    ATTACKING,
    USING_ITEM,
    FLEEING,
};

public class Player : Character
{
    private int _wordCount = 0;
    public string MoveKey { get; private set; } = "";
    public int WordCount
    {
        get { return _wordCount; }
        set { _wordCount = value; }
    }
    public Item? SelectedItem;
    public PlayerState? State;

	public Player(string name, int health, int attack, double luck) : base(name, health, attack, luck) 
    {
        Inventory.Add(new RedSauce(), 4);
        
        // player sebenarnya gk perlu sprite gk sih
        // kan jg kita gk bakal liat :sob:
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
        string? prevMove = MoveKey;
        while (MoveKey == prevMove)
            MoveKey = Vocabulary.GetWord();
    }

    public override void Fight(Character target)
    {
        target.Health -= Attack + (int)Math.Floor(WordCount * (1 + Luck));
        WordCount = 0;
    }
}
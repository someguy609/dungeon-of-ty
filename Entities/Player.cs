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
        Inventory.Add(new RedSauce());
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
namespace dungeon_of_ty;

public class Player : Character
{
	public Player(string name, int health, int attack, int defense, double luck) : base(name, health, attack, defense, luck) {}

    public void Learn()
	{
	}

    public override Control GetRenderedItems()
    {
        return null; // TODO
    }
}
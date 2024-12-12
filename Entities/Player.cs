namespace dungeon_of_ty;

public class Player : Character
{
	public Player(string name, int health, int attack, int defense, double luck) : base(name, health, attack, defense, luck) 
    {
        Moves.Add("punch", new Punch());
        Moves.Add("kick", new Kick());
    }

    public override void Fight(Character target, string? move = null)
    {
        if (string.IsNullOrEmpty(move) || !Moves.ContainsKey(move))
            throw new MoveNotFoundException();

        Moves[move].Execute(this, target);
    }

    public void Learn()
	{
	}

    public override Control GetRenderedItems()
    {
        return null; // TODO
    }
}
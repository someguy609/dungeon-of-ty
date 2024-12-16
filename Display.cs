namespace dungeon_of_ty;

public class Display : TableLayoutPanel
{
	public Display()
	{
		RowCount = 1;
		ColumnCount = 1;
	}

	public void ChangeEnemy(Control enemySprite)
	{
		Controls.Clear();
		Controls.Add(enemySprite);
	}
}
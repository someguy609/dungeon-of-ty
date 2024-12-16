namespace dungeon_of_ty;

public class Display : Panel // untuk kasi liat sprites
{
	private Control _playerSprite, _enemySprite;
	private System.Windows.Forms.Timer _timer;

	public Display(Control playerSprite, Control enemySprite)
	{
		_playerSprite = playerSprite;
		_enemySprite = enemySprite;

		_timer = new System.Windows.Forms.Timer
		{
			Interval = 20
		};
		_timer.Tick += (s, args) => 
		{
			if (_enemySprite.Top + 2 >= ClientSize.Height)
			{
				Controls.Remove(_enemySprite);
				_timer.Stop();
				return;
			}

			_enemySprite.Top += 2;
		};

		Controls.Add(_playerSprite);
		Controls.Add(_enemySprite);
	}

	public void RemoveEnemy()
	{

	}
}
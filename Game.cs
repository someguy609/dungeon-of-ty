namespace dungeon_of_ty;

public partial class Game : Form
{
	private Display _display;
	private Menu _menu; // mending di satuin di game kah?
	private Player _player;
	private Enemy _enemy;
	private System.Windows.Forms.Timer _timer;
	private string _move;

	public Game()
	{
		Text = "Dungeon Of Ty";
		MinimumSize = new Size(800, 600);
		StartPosition = FormStartPosition.CenterScreen;

		_player = new Player(Size);
		_enemy = new Enemy(Size);

		_menu = new Menu
		{
			Dock = DockStyle.Bottom,
			Height = 150,
			Padding = new Padding(5),
			BackColor = Color.AliceBlue,
			Font = new Font("Arial", 14),
		};
		Controls.Add(_menu);
		// set buttons to public
		// and connect them to custom handlers

		_display = new Display(_player.GetRenderedItems(), _enemy.GetRenderedItems())
		{
			Dock = DockStyle.Top,
			Height = 450
		};
		Controls.Add(_display); // fix the resizing

		InitializeGame();
	}

    public void InitializeGame()
	{
		KeyDown += new KeyEventHandler(OnKeyDown);
		KeyUp += new KeyEventHandler(OnKeyUp);

		_timer = new System.Windows.Forms.Timer
		{
			Interval = 3000
		};
		_timer.Tick += new EventHandler(OnTick);

		GameLoop();
	}

	public void GameLoop()
	{
		// while (_player.Health > 0)
		// {
		// 	while (_enemy.Health > 0)
		// 	{
				
		// 	}
		// }
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
			case Keys.W: case Keys.Up:
				_move += "U";
				break;
			case Keys.A: case Keys.Left:
				_move += "L";
				break;
			case Keys.S: case Keys.Down:
				_move += "D";
				break;
			case Keys.D: case Keys.Right:
				_move += "R";
				break;
		}

		_menu.ShowInfo(_move);
	}

	private void OnKeyUp(object sender, KeyEventArgs e)
	{
		switch (e.KeyCode)
		{}
	}

	private void OnTick(object sender, EventArgs e)
	{
		_menu.HideInfo();
		_move = "";
		_timer.Stop();
	}
}

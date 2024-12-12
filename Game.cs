namespace dungeon_of_ty;

public partial class Game : Panel
{
	private Display _display;
	private Menu _menu; // mending di satuin di game kah?
	private Player _player;
	private Enemy _enemy;
	private System.Windows.Forms.Timer _timer;
	private string _move = "";

	public Game()
	{
		Text = "Dungeon Of Ty";
		MinimumSize = new Size(800, 600);
		Dock = DockStyle.Fill;

		_player = new Player("Player", 100, 20, 100, 0.1);
		_enemy = new Enemy("Enemy", 100, 20, 30, 0.1);

		_timer = new System.Windows.Forms.Timer
		{
			Interval = 3000
		};
		_timer.Tick += new EventHandler(OnTick);

		_menu = new Menu
		{
			Dock = DockStyle.Bottom,
			Height = 150,
			Padding = new Padding(5),
			BackColor = Color.AliceBlue,
			Font = new Font("Arial", 14),
		};

		_menu.FightButton.Click += (s, e) =>
		{
			Focus();
			_menu.HideButtons();
			_menu.ShowInfo(_player.MoveKey, Color.DarkGray);
			_menu.ShowInput("", Color.GreenYellow);
			_timer.Start();
		};

		_menu.FleeButton.Click += (s, e) =>
		{
			if (_player.Flee())
			{
				MessageBox.Show("fled");
				Application.Exit();
			}
			else
				MessageBox.Show("failed to flee");
		};

		Controls.Add(_menu);

		_display = new Display(_player.GetRenderedItems(), _enemy.GetRenderedItems())
		{
			Dock = DockStyle.Top,
			Height = 450,
			TabStop = false,
		};
		Controls.Add(_display); // fix the resizing

		KeyDown += new KeyEventHandler(OnKeyDown);

		PlayerTurn();
	}

	private void PlayerTurn()
	{
		_player.OnStartTurn(); // apply buffs
		_player.GetNewMove(); // get word
		_menu.HideInfo(); // show buttons only
		_menu.HideInput();
		_menu.ShowButtons(); 
	}

	private void EnemyTurn()
	{
		_enemy.OnStartTurn();
		_enemy.TakeTurn(_player);

		if (_player.Health <= 0)
		{
			MessageBox.Show("lost");
			Application.Exit();
		}

		MessageBox.Show($"Player Turn\nPlayer health: {_player.Health}\nEnemy health: {_enemy.Health}");

		_enemy.OnEndTurn();

		PlayerTurn();
	}

	private void OnKeyDown(object? sender, KeyEventArgs e)
	{
		if (!_timer.Enabled) // if not player turn
			return;

		char c = (char)e.KeyValue; // get input

		if (c == (char)Keys.Back && _move.Length > 0) // backspace
			_move = _move[..^1];
		else if (char.IsLetterOrDigit(c)) // input
			_move += char.ToLower(c);
		_menu.HideInfo();
		_menu.ShowInput(_move, Color.GreenYellow); // show current input

		if (_move == _player.MoveKey) // if word match
		{ 
			_player.Fight(_enemy); // attack
			_move = "";
			// PlayerTurn(); // simulate click
		}
	}

	private void OnTick(object? sender, EventArgs e)
	{
		_timer.Stop(); // enemy turn

		if (_enemy.Health <= 0)
		{
			MessageBox.Show("win");
			Application.Exit();
		}

		MessageBox.Show($"Enemy Turn\nPlayer health: {_player.Health}\nEnemy health: {_enemy.Health}");

		_move = "";
		_menu.HideInfo();
		_menu.HideInput();
		_menu.ShowButtons();

		_player.OnEndTurn();

		EnemyTurn();
	}
}

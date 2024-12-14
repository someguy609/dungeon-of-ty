namespace dungeon_of_ty;

public partial class Game : Panel
{
	private Display _display;
	private Menu _menu; // mending di satuin di game kah?
	private Player _player;
	private Enemy _enemy;
	private List<Enemy> _enemies = new()
	{
	};
	private System.Windows.Forms.Timer _timer;
	private string _move = "";
	private bool typing = false;

	public Game()
	{
		Text = "Dungeon Of Ty";
		MinimumSize = new Size(800, 600);
		Dock = DockStyle.Fill;

		_player = new Player("Player", 100, 5, 0.1);
		_enemy = new Enemy("Enemy", 100, 5, 0.1);

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
		{ //  mending kita modularize typing to get integer of performance
			_player.State = PlayerState.ATTACKING;
			_menu.HideButtons();
			Focus();
			Type();
			_timer.Start();
		};

		_menu.InitializeInventory(_player);

		foreach (Button itemButton in _menu.InventoryPanel.Controls)
		{
			itemButton.Click += (s, e) =>
			{
				_player.State = PlayerState.USING_ITEM;
				_menu.HideInventory();
				Focus();
				Type();
				_timer.Start();
			};
		}

		_menu.InventoryButton.Click += (s, e) =>
		{
			_menu.HideButtons();
			_menu.ShowInventory();
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

		_display = new Display(_player.Sprite, _enemy.Sprite)
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

		PlayerTurn();
	}

	private void Type()
	{
		/*
		 * 1. fetch new word
		 * 2. display word to infoLabel
		 * 3. Focus and listen to keydown event
		 * 4. if word match, fetch new word and repeat
		 * 5. if time runs out, return word count with some calculation
		*/
		_menu.ShowInfo(_player.MoveKey, Color.DarkGray);
		_menu.ShowInput("", Color.GreenYellow);
		typing = true;
	}

	private void OnKeyDown(object? sender, KeyEventArgs e)
	{
		if (!typing) // if not player turn
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
			// _player.Fight(_enemy); // attack
			_move = "";
			_player.WordCount++;

			// need to modularize this
			// perlu coyote time jg buat setelah ketik input, -
			// itu reset new word nya ada delay
			_player.GetNewMove();
			// _menu.HideInfo();
			// _menu.ShowInfo(_player.MoveKey, Color.DarkGray);
			// _menu.ShowInput("", Color.GreenYellow);
			Type(); // typing again
					// PlayerTurn(); // simulate click
		}
	}

	private void OnTick(object? sender, EventArgs e)
	{
		_timer.Stop(); // enemy turn
		typing = false;

		switch (_player.State)
		{
			case PlayerState.ATTACKING:
				_player.Fight(_enemy);
				break;
			case PlayerState.USING_ITEM:
				_player.UseItem(_player.SelectedItem, _player.WordCount);
				break;
		}

		if (_enemy.Health <= 0)
		{
			Item? dropped_item = _enemy.DropItem();

			if (dropped_item != null)
				_player.Inventory.Add(dropped_item);
			
			MessageBox.Show("win");
			Application.Exit();
		}

		MessageBox.Show($"Enemy Turn\nPlayer health: {_player.Health}\nEnemy health: {_enemy.Health}");

		_move = "";
		_player.WordCount = 0;
		_menu.HideInfo();
		_menu.HideInput();
		_menu.ShowButtons();

		EnemyTurn();
	}
}

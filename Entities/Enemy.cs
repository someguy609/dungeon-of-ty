using System.Diagnostics;

namespace dungeon_of_ty;

public enum EnemyState
{
	AGGRESSIVE,
	DEFENSIVE
}

public class Enemy : Character
{
	private EnemyState _state;

	protected ProgressBar _healthBar;

	public Control? Render;
	
	public Enemy(string name, int health, int attack, double luck, string spritePath, int spriteX, int spriteY, int spriteW, int spriteH, int spriteScale) : base(name, health, attack, luck)
	{
		Image _spriteSheet = Image.FromFile(spritePath);
		Rectangle srcRect = new Rectangle(spriteX, spriteY, spriteW, spriteH);
		Bitmap frame = new Bitmap(spriteW, spriteH);

		using (Graphics g = Graphics.FromImage(frame))
			g.DrawImage(_spriteSheet, new Rectangle(0, 0, spriteW, spriteH), srcRect, GraphicsUnit.Pixel);
		
		Label nameLabel = new Label
		{
			Dock = DockStyle.Fill,
			Text = Name,
			Font = new Font("Arial", 16),
			TextAlign = ContentAlignment.MiddleCenter,
			AutoSize = true,
		};

		_healthBar = new ProgressBar()
		{
			Dock = DockStyle.Fill,
			Value = Health,
			Maximum = MaxHealth,
			ForeColor = Color.FromArgb(0, 230, 19),
		};

		PictureBox sprite = new PictureBox
		{
			Size = new Size(spriteW * spriteScale, spriteH * spriteScale),
			Image = frame,
			SizeMode = PictureBoxSizeMode.Zoom,
		};

		Render = new FlowLayoutPanel()
		{
			FlowDirection = FlowDirection.TopDown,
			Anchor = AnchorStyles.None,
			WrapContents = false,
			AutoSize = true,
		};

		Render.Controls.Add(nameLabel);
		Render.Controls.Add(_healthBar);
		Render.Controls.Add(sprite);

		_state = EnemyState.AGGRESSIVE;
	}

    public override void Fight(Character target)
    { // logika nya apa dah
		target.Health -= Attack + (int)Math.Ceiling(_random.Next(Vocabulary.Words.Count) * (1 + Luck));
    }

    public void Update()
	{
		_healthBar.Value = Health;
		_state = Health <= MaxHealth / 3 ? EnemyState.DEFENSIVE : EnemyState.AGGRESSIVE;
	}

	public void TakeTurn(Character player)
	{
		Update();

		switch (_state)
		{
			case EnemyState.AGGRESSIVE:
				Fight(player);
				break;
			case EnemyState.DEFENSIVE:
				if (Flee(_random.Next(Vocabulary.Words.Count))) Health = 0; // for now
				break;
		}
	}

	public Item? DropItem()
	{
		if (Inventory.Items.Count == 0)
			return null;
		return Inventory.Items[_random.Next(Inventory.Items.Count)];
	}
}

public class Napstablook : Enemy
{
	private const int _spriteX = 3;
	private const int _spriteY = 21;
	private const int _spriteW = 52;
	private const int _spriteH = 76;
	private const int _spriteScale = 5;

	public Napstablook() : base("Napsta", 100, 1, 0.1, "assets/spritesheets/enemy1-napstablook.png", _spriteX, _spriteY, _spriteW, _spriteH, _spriteScale)
	{
	}
}

public class Papyrus : Enemy
{
	private const int _spriteX = 340;
	private const int _spriteY = 301;
	private const int _spriteW = 142;
	private const int _spriteH = 211;
	private const int _spriteScale = 2;
	
	public Papyrus() : base("Papi", 200, 5, 0.2, "assets/spritesheets/spritesheet.png", _spriteX, _spriteY, _spriteW, _spriteH, _spriteScale)
	{
	}
}
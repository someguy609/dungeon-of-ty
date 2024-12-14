namespace dungeon_of_ty;

public class Menu : Panel
{
	private FlowLayoutPanel _buttonsPanel;
	private Label _infoLabel;
	private Label _inputLabel;
	public Button FightButton, InventoryButton, FleeButton;
	public TableLayoutPanel InventoryPanel;

	public Menu()
	{
		Padding = new Padding(5);

		_buttonsPanel = new FlowLayoutPanel
		{
			FlowDirection = FlowDirection.LeftToRight,
			AutoSize = true,
			Anchor = AnchorStyles.None,
			TabStop = false,
		};

		FightButton = new Button
		{
			Text = "Fight",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		_buttonsPanel.Controls.Add(FightButton);

		InventoryButton = new Button
		{
			Text = "Inventory",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		_buttonsPanel.Controls.Add(InventoryButton);

		FleeButton = new Button
		{
			Text = "Flee",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		_buttonsPanel.Controls.Add(FleeButton);

		InventoryPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 2,
			Visible = false,
		};
		InventoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		InventoryPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		// butuh back button kah?

		_infoLabel = new Label
		{
			Dock = DockStyle.Fill,
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
			TextAlign = ContentAlignment.MiddleCenter,
			AutoSize = false,
			Visible = false,
			BackColor = Color.Transparent,
		};

		_inputLabel = new Label
		{
			Dock = DockStyle.Fill,
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
			TextAlign = ContentAlignment.MiddleCenter,
			AutoSize = false,
			Visible = false,
			BackColor = Color.Transparent,
		};

		_inputLabel.BringToFront();

		Controls.Add(_buttonsPanel);
		Controls.Add(InventoryPanel);
		Controls.Add(_infoLabel);
		Controls.Add(_inputLabel);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);

		_buttonsPanel.Location = new Point(
			(Width - _buttonsPanel.Width) / 2,
			Height / 2 - 25
		);

		_infoLabel.Location = new Point(
			(Width - _infoLabel.Width) / 2,
			(Height - _infoLabel.Height) / 2
		);

		_inputLabel.Location = new Point(
			(Width - _inputLabel.Width) / 2,
			(Height - _inputLabel.Height) / 2
		);
	}

	public void ShowButtons()
	{
		_buttonsPanel.Show();
	}

	public void ShowInfo(string? info = "", Color? textColor = null) // attacking, fleeing
	{
		_infoLabel.Text = info ?? "";
		_infoLabel.ForeColor = textColor ?? Color.Black;
		_infoLabel.Show();
	}

	public void ShowInput(string input = "", Color? textColor = null) // input
	{
		_inputLabel.Text = input;
		_inputLabel.Show();
	}

	public void HideButtons()
	{
		_buttonsPanel.Hide();
	}

	public void HideInfo()
	{
		_infoLabel.Hide();
	}

	public void HideInput()
	{
		_inputLabel.Hide();
	}

	public void InitializeInventory(Player player)
	{
		foreach (Item item in player.Inventory.Items)
		{
			Button itemButton = new Button
			{
				Text = item.Name,
				Dock = DockStyle.Fill,
				Height = 50,
			};

			itemButton.Click += (s, e) =>
			{
				player.Inventory.UseItem(player, item);
				HideInventory();
				ShowButtons();
				InventoryPanel.Controls.Remove(itemButton);
			};

			InventoryPanel.Controls.Add(itemButton);
		}
	}

	public void HideInventory()
	{
		InventoryPanel.Hide();
	}

	public void ShowInventory()
	{
		InventoryPanel.Show();
	}
}
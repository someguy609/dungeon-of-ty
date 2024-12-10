namespace dungeon_of_ty;

public class Menu : Panel
{
	private FlowLayoutPanel _buttonsPanel;
	private Button _fightButton, _inventoryButton, _fleeButton;
	private Label _infoLabel;

	public Menu()
	{
		_buttonsPanel = new FlowLayoutPanel
		{
			FlowDirection = FlowDirection.LeftToRight,
			AutoSize = true,
			Anchor = AnchorStyles.None,
		};

		_fightButton = new Button
		{
			Text = "Fight",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		_fightButton.Click += new EventHandler(FightButton_Click);
		_buttonsPanel.Controls.Add(_fightButton);

		_inventoryButton = new Button
		{
			Text = "Inventory",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		_inventoryButton.Click += new EventHandler(InventoryButton_Click);
		_buttonsPanel.Controls.Add(_inventoryButton);

		_fleeButton = new Button
		{
			Text = "Flee",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		_fleeButton.Click += new EventHandler(FleeButton_Click);
		_buttonsPanel.Controls.Add(_fleeButton);

		_infoLabel = new Label
		{
			TextAlign = ContentAlignment.MiddleCenter,
			AutoSize = true,
			Anchor = AnchorStyles.None,
			Visible = false,
		};

		Controls.Add(_buttonsPanel);
		Controls.Add(_infoLabel);
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
    }

	public void ShowInfo(string info = "")
	{
		_fightButton.TabStop = false;
		_inventoryButton.TabStop = false;
		_fleeButton.TabStop = false;
		_buttonsPanel.Hide();

		_infoLabel.Text = info;
		_infoLabel.Show();
	}

	public void HideInfo()
	{
		_infoLabel.Hide();

		_fightButton.TabStop = false;
		_inventoryButton.TabStop = false;
		_fleeButton.TabStop = false;
		_buttonsPanel.Show();
	}

    private void FightButton_Click(object sender, EventArgs e)
	{ 
		ShowInfo();
	}

	private void InventoryButton_Click(object sender, EventArgs e)
	{ 
		// ShowInfo("inventory");
	}

	private void FleeButton_Click(object sender, EventArgs e)
	{ 
		// ShowInfo("flee");
	}
}
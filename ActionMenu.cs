namespace dungeon_of_ty;

public class Menu : Panel
{
	private FlowLayoutPanel _buttonsPanel;
	private Label _infoLabel;
	public Button FightButton, InventoryButton, FleeButton;

	public Menu()
	{
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
		FightButton.Click += new EventHandler(FightButton_Click);
		_buttonsPanel.Controls.Add(FightButton);

		InventoryButton = new Button
		{
			Text = "Inventory",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		InventoryButton.Click += new EventHandler(InventoryButton_Click);
		_buttonsPanel.Controls.Add(InventoryButton);

		FleeButton = new Button
		{
			Text = "Flee",
			Size = new Size(150, 50),
			BackColor = Color.White,
			TabStop = false,
		};
		FleeButton.Click += new EventHandler(FleeButton_Click);
		_buttonsPanel.Controls.Add(FleeButton);

		_infoLabel = new Label
		{
			TextAlign = ContentAlignment.MiddleCenter,
			AutoSize = false,
			Anchor = AnchorStyles.None,
			Visible = false,
			Width = 750,
			Height = 125,
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
		_buttonsPanel.Hide();

		_infoLabel.Text = info;
		_infoLabel.Show();
	}

	public void HideInfo()
	{
		_infoLabel.Hide();
		_buttonsPanel.Show();
	}

    private void FightButton_Click(object ?sender, EventArgs e)
	{ 
		ShowInfo();
	}

	private void InventoryButton_Click(object ?sender, EventArgs e)
	{ 
		// show inventory list
		// ShowInfo("inventory");
	}

	private void FleeButton_Click(object ?sender, EventArgs e)
	{ 
		// show flee screen idk
		// ShowInfo("flee");
	}
}
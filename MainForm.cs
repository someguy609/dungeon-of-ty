namespace dungeon_of_ty;

public class MainForm : Form {
    private Panel _contentPanel;
    private Panel _mainMenuPanel;
    private Panel _gamePanel;

    public MainForm() {
        Text = "Dungeon of Ty";
        Size = new Size(1600, 1200);
        _contentPanel = new Panel {
            Dock = DockStyle.Fill
        };
        Controls.Add(_contentPanel);

        _mainMenuPanel = new MainMenu(this);
        _gamePanel = new Game(this);

        SwitchToMenu();
    }

    public void SwitchView(Control newView) {
        _contentPanel.Controls.Clear();
        newView.Dock = DockStyle.Fill;
        _contentPanel.Controls.Add(newView);
    }

    public void SwitchToMenu() {
        SwitchView(_mainMenuPanel);
    }

    public void SwitchToGame() {
        SwitchView(_gamePanel);
    }
}


namespace dungeon_of_ty;
public class MainMenu : Panel , IButtonColor {
    private readonly PictureBox _logo = new PictureBox {
        Size = new Size(800, 200), // cuma kepake buat adjust x position
        Location = new Point(164, 150),
        SizeMode = PictureBoxSizeMode.AutoSize,
    };
    private Button? _newGameButton, _loadGameButton, _exitButton;
    private Color _hoverButtonColor = Color.Gray;
    private MainForm _mainForm;

    public Color DefaultButtonColor { get; } = Color.Gray;
    public Color HoverButtonColor { get; } = Color.DimGray;

    public MainMenu(MainForm mainForm) {
        _mainForm = mainForm;
        InitGame();
        MenuButtons();
    }

    private void ButtonFormat(Button button) {
        button.MouseEnter += (sender, e) => {
            button.BackColor = HoverButtonColor;
        };
        button.MouseLeave += (sender, e) => {
            button.BackColor = DefaultButtonColor;
        };
    }

    private void InitGame() {
        // READ PLAYER DATA .TXT IN HERE

        ///////////////////
        
    }

    public void MenuButtons() {
        Controls.Clear();
        try {
            _logo.Image = Image.FromFile("assets/Logo.png");
        } catch (FileNotFoundException) {
            _logo.Image = null;
            _logo.BackColor = Color.Black;
        }
        _newGameButton = new Button {
            Text = "New Game",
            ForeColor = Color.White,
            Size = new Size(450, 150), // half 225
            Location = new Point(575, 400), // ends in 550
            BackColor = DefaultButtonColor,
            TabStop = true,
        };
        ButtonFormat(_newGameButton);
        _newGameButton.Click += StartNewGame;

        // _loadGameButton = new Button {
        //     Text = "Load Game",
        //     ForeColor = Color.White,
        //     Size = new Size(450, 150),
        //     Location = new Point(575, 600), // ends in 750
        //     BackColor = DefaultButtonColor,
        //     TabStop = true,
        // };
        // ButtonFormat(_loadGameButton);
        // _loadGameButton.Click += LoadGame;

        _exitButton = new Button {
            Text = "Exit",
            ForeColor = Color.White,
            Size = new Size(450, 150),
            Location = new Point(575, 800), // ends in 950
            BackColor = DefaultButtonColor,
            TabStop = true,
        };
        ButtonFormat(_exitButton);
        _exitButton.Click += (s, e) => {
            Application.Exit();
        };

        Controls.Add(_logo);
        Controls.Add(_newGameButton);
        Controls.Add(_loadGameButton);
        Controls.Add(_exitButton);
    }

    // TODO: IMPLEMENT TO NEW GAME IN GAME CLASS
    private void StartNewGame(object? sender, EventArgs e) {
        _mainForm.SwitchToGame();
    }

    public void LoadGame(object? sender, EventArgs e) {
        // NGame ngame = new NGame(_mainForm, false);
        // _mainForm.SwitchView(ngame);
    }
}
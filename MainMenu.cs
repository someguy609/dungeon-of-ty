
namespace dungeon_of_ty;
public class MainMenu : Panel , IButtonColor {
    private PictureBox _logo;
    private Button? _newGameButton, _loadGameButton, _exitButton;
    private Color _hoverButtonColor = Color.Gray;
    private MainForm _mainForm;

    public Color DefaultButtonColor { get; } = Color.Gray;
    public Color HoverButtonColor { get; } = Color.DimGray;

    public MainMenu(MainForm mainForm) {
        _logo = new PictureBox {
            SizeMode = PictureBoxSizeMode.StretchImage,
            // original resolution = 1273 x 130
            MinimumSize = new Size(900, 92),
        };
        _mainForm = mainForm;
        MenuButtons();
        Resize += MenuResize;
    }

    private void MenuResize(object? sender, EventArgs e) {
        if (_logo.Image != null) {
            float ratio = (float)_logo.Image.Width / _logo.Image.Height;
            _logo.Size = new Size(
                Width/2 - Width/16,
                (int)((Width/2 - Width/16) / ratio)
            
            );
            _logo.Location = new Point(
                (Width - _logo.Width) / 2,
                (Height / 6) - (_logo.Height / 2)
            );
        } 
        if (_newGameButton != null) {
            _newGameButton.Location = new Point(
                (Width - _newGameButton.Width) / 2,
                Height / 2
            );
            _newGameButton.Font = new Font("Arial", _newGameButton.Height / 10);
            _newGameButton.Size = new Size(
                Width*3/16, 
                Width/16
            );
            _newGameButton.Location = new Point(
                (Width - _newGameButton.Width) / 2,
                _newGameButton.Location.Y - _newGameButton.Height
            );
        }
        if (_exitButton != null) {
            _exitButton.Location = new Point(
                (Width - _exitButton.Width) / 2,
                Height / 2
            );
            _exitButton.Font = new Font("Arial", _exitButton.Height / 10);
            _exitButton.Size = new Size(
                Width*3/16,
                Width/16
            );
            _exitButton.Location = new Point(
                (Width - _exitButton.Width) / 2,
                _exitButton.Location.Y + 50
            );
        }
    }

    private void ButtonFormat(Button button) {
        button.MouseEnter += (sender, e) => {
            button.BackColor = HoverButtonColor;
        };
        button.MouseLeave += (sender, e) => {
            button.BackColor = DefaultButtonColor;
        };
        button.MinimumSize = new Size(450, 150);
        button.Font = new Font("Arial", button.Height / 10);
        button.ForeColor = Color.White;
        button.BackColor = DefaultButtonColor;
        button.TabStop = true;
        button.Size = new Size(450, 150);
        button.Location = new Point((Width - button.Width) / 2, button.Location.Y);
    }

    private void ButtonResize(object? sender, EventArgs e) {
        Button button = (Button)sender!;
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
            // Size = new Size(450, 150), // half 225
            // Location = new Point(575, 400), // ends in 550
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
            // Size = new Size(450, 150),
            // Location = new Point(575, 800), // ends in 950
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
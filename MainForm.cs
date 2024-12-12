namespace dungeon_of_ty;

public class MainForm : Form {
    private Panel _contentPanel;

    public MainForm() {
        this.Text = "Dungeon of Ty";
        this.Size = new Size(1600, 1200);
        _contentPanel = new Panel {
            Dock = DockStyle.Fill
        };
        Controls.Add(_contentPanel);
        SwitchView(new MainMenu(this));
    }

    public void SwitchView(Control newView) {
        _contentPanel.Controls.Clear();
        newView.Dock = DockStyle.Fill;
        _contentPanel.Controls.Add(newView);
    }
}

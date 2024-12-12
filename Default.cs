public interface IButtonColor {
    Color DefaultButtonColor { get; }
    Color HoverButtonColor { get; }

    private void ButtonFormat(Button button) {
        button.MouseEnter += (sender, e) => {
            button.BackColor = HoverButtonColor;
        };
        button.MouseLeave += (sender, e) => {
            button.BackColor = DefaultButtonColor;
        };
    }
}
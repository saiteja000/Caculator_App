using System.Diagnostics;

namespace Calculator;

public partial class AppShell : Shell
{
	public AppShell()
	{
        InitializeComponent();


        // Create instances of MenuItemModel with associated commands
        var lightSchemeMenuItem = new MenuItemModel
        {
            Text = "Light Color Scheme",
            Command = new Command(LightSchemeCommand)
        };

        var darkSchemeMenuItem = new MenuItemModel
        {
            Text = "Dark Color Scheme",
            Command = new Command(DarkSchemeCommand)
        };

        var redSchemeMenuItem = new MenuItemModel
        {
            Text = "Red Color Scheme",
            Command = new Command(RedSchemeCommand)
        };

        var pinkSchemeMenuItem = new MenuItemModel
        {
            Text = "Pink Color Scheme",
            Command = new Command(PinkSchemeCommand)
        };


        // Set the FlyoutItem's menu items
       


    }


    private void OnLightSchemeClicked(object sender, EventArgs e)
    {
        // Set the application's color scheme to the Light scheme
        SetColorScheme(ColorScheme.Light);
    }

    private void OnDarkSchemeClicked(object sender, EventArgs e)
    {
        // Set the application's color scheme to the Dark scheme
        SetColorScheme(ColorScheme.Dark);
    }

    private void OnRedSchemeClicked(object sender, EventArgs e)
    {
        // Set the application's color scheme to the Red scheme
        SetColorScheme(ColorScheme.Red);
    }

    private void OnPinkSchemeClicked(object sender, EventArgs e)
    {
        // Set the application's color scheme to the Pink scheme
        SetColorScheme(ColorScheme.Pink);
    }


    private void LightSchemeCommand()
    {
        OnLightSchemeClicked(this, EventArgs.Empty);
    }

    private void DarkSchemeCommand()
    {
        OnDarkSchemeClicked(this, EventArgs.Empty);
    }

    private void RedSchemeCommand()
    {
        OnRedSchemeClicked(this, EventArgs.Empty);
    }

    private void PinkSchemeCommand()
    {
        OnPinkSchemeClicked(this, EventArgs.Empty);
    }


    private void SetColorScheme(ColorScheme colorScheme)
    {
        // Define color resources
        Color backgroundColor = Color.FromHex("#FFFFFF"); // White
        Color buttonColor = Color.FromHex("#000000");      // Black

        switch (colorScheme)
        {
            case ColorScheme.Light:
                backgroundColor = Color.FromHex("#D3D3D3"); // LightGray
                buttonColor = Color.FromHex("#008000");      // Green
                                                             // Update other color resources as needed
                break;
            case ColorScheme.Dark:
                backgroundColor = Color.FromHex("#A9A9A9"); // DarkGray
                buttonColor = Color.FromHex("#FF0000");      // Red
                                                             // Update other color resources as needed
                break;
            case ColorScheme.Red:
                backgroundColor = Color.FromHex("#FF0000"); // Red
                buttonColor = Color.FromHex("#FFFFFF");      // White
                                                             // Update other color resources as needed
                break;
            case ColorScheme.Pink:
                backgroundColor = Color.FromHex("#FFC0CB"); // Pink
                buttonColor = Color.FromHex("#000000");      // Black
                                                             // Update other color resources as needed
                break;
        }

        // Update the application's color resources
        App.Current.Resources["BackgroundColor"] = backgroundColor;
        App.Current.Resources["ButtonColor"] = buttonColor;
        // Update other color resources as needed
    }



    public enum ColorScheme
    {
        Light,
        Dark,
        Red,
        Pink
    }

}


namespace Calculator;

public partial class About : ContentPage
{
    public About()
    {
        InitializeComponent();

        var titleLabel = new Label
        {
            Text = "Sai Teja Donthi",
            FontAttributes = FontAttributes.Bold,
            FontSize = 24,
            HorizontalOptions = LayoutOptions.Center
        };

        var descriptionLabel = new Label
        {
            Text = "H848P727",
            FontSize = 18,
            HorizontalOptions = LayoutOptions.Center
        };

        // Add UI elements to the page's content
        Content = new StackLayout
        {
            Padding = new Thickness(20),
            Spacing = 10,
            Children = { titleLabel, descriptionLabel }
        };
    }
}

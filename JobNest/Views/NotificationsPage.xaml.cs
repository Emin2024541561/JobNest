namespace JobNest.Views;

public partial class NotificationsPage : ContentPage
{
    public NotificationsPage()
    {
        InitializeComponent();
        LoadNotifications();
    }

    private void LoadNotifications()
    {
        var messages = new List<string>
        {
            "✅ Uspješna registracija.",
            "✅ Uspješna prijava.",
            "📢 Dodan je novi posao.",
            "📢 Dodan je novi posao.",
            "📢 Dodan je novi posao."
        };

        NotificationsCollectionView.ItemsSource = messages;
    }
}

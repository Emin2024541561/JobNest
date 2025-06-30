using JobNest.Models;
using JobNest.Services;
using JobNest.Helpers;

namespace JobNest.Views;

public partial class ProfilePage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly CurrentUserService _currentUserService;

    public ProfilePage()
    {
        InitializeComponent();
        _databaseService = ServiceHelper.GetService<DatabaseService>();
        _currentUserService = ServiceHelper.GetService<CurrentUserService>();
        LoadProfile();
    }

    private async void LoadProfile()
    {
        try
        {
            var currentUser = _currentUserService.CurrentUser;
            if (currentUser != null)
            {
                UserNameLabel.Text = currentUser.Name ?? "Korisnik";
                EmailLabel.Text = currentUser.Email ?? "Email nije naveden";
                PhoneLabel.Text = "+387 61 123 456";
            }
            else
            {
                UserNameLabel.Text = "Korisnik";
                EmailLabel.Text = "Email nije naveden";
                PhoneLabel.Text = "+387 61 123 456";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Greška", $"Greška: {ex.Message}", "OK");
        }
    }

    private async void OnSaveCvLinkClicked(object sender, EventArgs e)
    {
        string link = CvEntry.Text;
        if (!string.IsNullOrWhiteSpace(link))
        {
            await DisplayAlert("Uspjeh", $"Link je sačuvan:\n{link}", "OK");
        }
        else
        {
            await DisplayAlert("Greška", "Molimo unesite link.", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CandidateDashboard");
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SearchPage());
    }

    private async void OnNotificationsClicked(object sender, EventArgs e)
    {
        // Otvara NotificationsPage
        await Navigation.PushAsync(new NotificationsPage());
    }
}

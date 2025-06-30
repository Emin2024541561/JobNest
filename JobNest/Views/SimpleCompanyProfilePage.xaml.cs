using JobNest.Models;
using JobNest.Services;
using JobNest.Helpers;

namespace JobNest.Views;

public partial class SimpleCompanyProfilePage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly CurrentUserService _currentUserService;

    public SimpleCompanyProfilePage()
    {
        InitializeComponent();
        _databaseService = ServiceHelper.GetService<DatabaseService>();
        _currentUserService = ServiceHelper.GetService<CurrentUserService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadCompanyProfileAsync();
    }

    private async Task LoadCompanyProfileAsync()
    {
        try
        {
            var currentUser = _currentUserService.CurrentUser;
            if (currentUser == null)
            {
                await DisplayAlert("Greška", "Niste prijavljeni.", "OK");
                return;
            }

            var profile = await _databaseService.GetCompanyProfileByUserIdAsync(currentUser.Id);

            CompanyNameLabel.Text = profile?.CompanyName ?? currentUser.Name ?? "Naziv kompanije";
            EmailLabel.Text = profile?.ContactEmail ?? currentUser.Email;
            PhoneLabel.Text = profile?.ContactPhone ?? currentUser.Phone;
            LocationLabel.Text = profile?.Location;

            // Prikaz/skrivanje sekcija
            EmailSection.IsVisible = !string.IsNullOrWhiteSpace(EmailLabel.Text);
            PhoneSection.IsVisible = !string.IsNullOrWhiteSpace(PhoneLabel.Text);
            LocationLabel.IsVisible = !string.IsNullOrWhiteSpace(LocationLabel.Text);
            WebsiteSection.IsVisible = !string.IsNullOrWhiteSpace(profile?.Website);
            DescriptionSection.IsVisible = !string.IsNullOrWhiteSpace(profile?.Description);

            if (!string.IsNullOrWhiteSpace(profile?.Website))
                WebsiteLabel.Text = profile.Website;

            if (!string.IsNullOrWhiteSpace(profile?.Description))
                DescriptionLabel.Text = profile.Description;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Greška", $"Problem sa učitavanjem profila: {ex.Message}", "OK");
        }
    }

    private async void OnEditProfileClicked(object sender, EventArgs e)
    {
        var currentUser = _currentUserService.CurrentUser;
        if (currentUser == null)
        {
            await DisplayAlert("Greška", "Niste prijavljeni.", "OK");
            return;
        }

        var profile = await _databaseService.GetCompanyProfileByUserIdAsync(currentUser.Id);
        await Navigation.PushAsync(new CompanyProfileEditPage(profile));
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnCandidatesClicked(object sender, EventArgs e)
    {
        var currentUser = _currentUserService.CurrentUser;
        if (currentUser != null)
        {
            var applications = await _databaseService.GetApplicationsByCompanyAsync(currentUser.Id);
            if (applications != null && applications.Any())
            {
                var candidateNames = string.Join("\n", applications.Select(a => $"• {a.CandidateName}"));
                await DisplayAlert("Kandidati", $"Aplikacije:\n\n{candidateNames}", "OK");
            }
            else
            {
                await DisplayAlert("Kandidati", "Nema aplikacija.", "OK");
            }
        }
    }

    private async void OnProfileClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Već ste na profilu.", "OK");
    }

    private void OnLogoClicked(object sender, EventArgs e)
    {
        DisplayAlert("Logo", "Ovdje možete dodati izmjenu loga.", "OK");
    }
}

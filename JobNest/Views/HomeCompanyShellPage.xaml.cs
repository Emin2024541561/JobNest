using JobNest.Services;
using JobNest.Helpers;

namespace JobNest.Views;

public partial class HomeCompanyShellPage : ContentPage
{
    private readonly CurrentUserService _currentUserService;

    public HomeCompanyShellPage()
    {
        InitializeComponent();
        _currentUserService = ServiceHelper.GetService<CurrentUserService>();
    }

    private async void OnCreateJobClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new JobCreationPage());
    }

    private async void OnHomeTapped(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void OnSearchTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SearchPage());
    }

    private async void OnProfileTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SimpleCompanyProfilePage());
    }
}

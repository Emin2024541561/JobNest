using JobNest.Models;
using JobNest.Services;
using JobNest.Helpers;
using System.Collections.ObjectModel;

namespace JobNest.Views;

public partial class CompanyDashboardPage : ContentPage
{
    private readonly DatabaseService _databaseService;
    private readonly CurrentUserService _currentUserService;
    private ObservableCollection<JobPost> _myJobs;

    public CompanyDashboardPage()
    {
        InitializeComponent();
        _databaseService = ServiceHelper.GetService<DatabaseService>();
        _currentUserService = ServiceHelper.GetService<CurrentUserService>();
        _myJobs = new ObservableCollection<JobPost>();

        LoadCompanyData();
        SetGreeting();
        _ = LoadMyJobsAsync();
    }

    private async void LoadCompanyData()
    {
        var currentUser = _currentUserService.CurrentUser;
        if (currentUser != null)
        {
            var profile = await _databaseService.GetCompanyProfileByUserIdAsync(currentUser.Id);
            if (profile != null && !string.IsNullOrEmpty(profile.CompanyName))
                CompanyNameLabel.Text = profile.CompanyName;
            else
                CompanyNameLabel.Text = currentUser.Name ?? "Kompanija";
        }
        else
        {
            CompanyNameLabel.Text = "Kompanija";
        }
    }

    private void SetGreeting()
    {
        GreetingLabel.Text = _currentUserService.GetGreeting();
    }

    private async Task LoadMyJobsAsync()
    {
        try
        {
            var currentUser = _currentUserService.CurrentUser;
            if (currentUser != null)
            {
                var companyJobs = await _databaseService.GetJobPostsByCompanyAsync(currentUser.Id);
                var activeJobs = companyJobs
                    .Where(j => j.IsActive && !j.Title.StartsWith("[OBRISAN]"))
                    .ToList();

                _myJobs.Clear();
                foreach (var job in activeJobs)
                {
                    // Broj prijava po oglasu
                    job.ApplicationCount = await _databaseService.GetApplicationCountForJobAsync(job.Id);
                    _myJobs.Add(job);
                }

                MyJobsCollectionView.ItemsSource = _myJobs;

                // BROJ AKTIVNIH OGLASA
                ActiveJobsLabel.Text = activeJobs.Count.ToString();

                // UKUPAN BROJ PRIJAVA
                var totalApplications = await _databaseService.GetApplicationsByCompanyAsync(currentUser.Id);
                ApplicationsLabel.Text = totalApplications.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Greška", $"Problem sa učitavanjem oglasa: {ex.Message}", "OK");
        }
    }

    private async void OnAddJobClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new JobCreationPage());
    }

    private async void OnEditJobClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is JobPost jobPost)
        {
            await Navigation.PushAsync(new JobCreationPage(jobPost));
        }
    }

    private async void OnDeleteJobClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is JobPost jobPost)
        {
            var confirm = await DisplayAlert("Potvrda",
                $"Da li ste sigurni da želite obrisati posao '{jobPost.Title}'?",
                "Obriši", "Otkaži");

            if (confirm)
            {
                await DeleteJobAsync(jobPost.Id);
                await LoadMyJobsAsync();
            }
        }
    }

    private async Task DeleteJobAsync(int jobId)
    {
        var job = await _databaseService.GetJobPostByIdAsync(jobId);
        if (job != null)
        {
            job.IsActive = false;
            job.Title = "[OBRISAN] " + job.Title;
            await _databaseService.UpdateJobPostAsync(job);
        }
    }

    private async void OnProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SimpleCompanyProfilePage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await LoadMyJobsAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMyJobsAsync();
    }
}

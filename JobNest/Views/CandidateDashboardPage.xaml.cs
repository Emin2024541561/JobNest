using JobNest.Models;
using JobNest.Services;
using JobNest.Helpers;
using JobNest.Views; // zbog SimpleJobDetailPage
using System.Linq;

namespace JobNest.Views
{
    public partial class CandidateDashboardPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private readonly CurrentUserService _currentUserService;

        public CandidateDashboardPage()
        {
            InitializeComponent();
            _databaseService = ServiceHelper.GetService<DatabaseService>();
            _currentUserService = ServiceHelper.GetService<CurrentUserService>();

            LoadDashboard();
            LoadLatestJobs();
        }

        private async void LoadDashboard()
        {
            try
            {
                var currentUser = _currentUserService.CurrentUser;
                if (currentUser != null)
                {
                    NameLabel.Text = currentUser.Name ?? "Korisnik";
                    GreetingLabel.Text = _currentUserService.GetGreeting();
                }
                else
                {
                    NameLabel.Text = "Korisnik";
                    GreetingLabel.Text = "Dobrodošli";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Greška", $"Problem sa učitavanjem: {ex.Message}", "OK");
            }
        }

        private async void LoadLatestJobs()
        {
            try
            {
                var latestJobs = await _databaseService.GetJobPostsAsync();

                var jobViewModels = latestJobs
                    .Where(j => j.IsActive)
                    .OrderByDescending(j => j.PostedDate)
                    .Take(10)
                    .Select(j => new JobPostViewModel
                    {
                        Id = j.Id,
                        Title = j.Title,
                        CompanyName = j.Company ?? "Kompanija",
                        Description = j.Description,
                        Location = j.Location ?? "Lokacija nije navedena",
                        // logika za prikaz plate
                        Salary = !string.IsNullOrWhiteSpace(j.Salary)
                            ? j.Salary
                            : (j.SalaryMin.HasValue && j.SalaryMax.HasValue
                                ? $"{j.SalaryMin.Value} KM - {j.SalaryMax.Value} KM"
                                : "Plata po dogovoru"),
                        PostedDate = j.PostedDate
                    })
                    .ToList();

                LatestJobsCollectionView.ItemsSource = jobViewModels;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Greška", $"Problem sa učitavanjem najnovijih poslova: {ex.Message}", "OK");
            }
        }

        private async void OnSearchBarTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        private async void OnProfileTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnLatestJobSelected(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.CurrentSelection?.FirstOrDefault() is JobPostViewModel selectedJob)
                {
                    ((CollectionView)sender).SelectedItem = null;

                    await Navigation.PushAsync(new SimpleJobDetailPage(selectedJob));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Greška", $"Problem sa otvaranjem detalja posla: {ex.Message}", "OK");
            }
        }
    }
}

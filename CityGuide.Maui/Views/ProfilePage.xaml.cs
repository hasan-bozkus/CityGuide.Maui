using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class ProfilePage : ContentPage
{
    private readonly AppDatabase _appDatabase = new AppDatabase();
    public ProfilePage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        NameLabel.Text = CurrentSession.FullName;
        EmailLabel.Text = CurrentSession.Email;

        var favoritePlaces = await _appDatabase.GetFavoritePlacesAsync(CurrentSession.UserId);
        FavoriteCountLabel.Text = favoritePlaces.Count.ToString();

        var allRoutes = await _appDatabase.GetRoutesAsync();
        RouteCountLabel.Text = allRoutes.Count.ToString();
    }

    private async void OnMenuItemTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Yakında", "Bu özellik yakında eklenecek.", "Tamam");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlertAsync("Çıkış Yap", "Çıkış yapmak istediğinizden emin misiniz?", "Evet", "Hayır");

        if (confirm)
        {
            CurrentSession.Clear();
            await Shell.Current.GoToAsync("//login");
        }
    }

    private async void OnProfileTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }

    private async void OnHomeTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }

    private async void OnDiscoverTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("routes");
    }

    private async void OnEventsTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//events");
    }
}
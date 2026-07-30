using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class HomePage : ContentPage
{
    private readonly AppDatabase _appDatabase = new AppDatabase();

	public HomePage()
	{
		InitializeComponent();
	}

    private async void OnExploreClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Keşfet", "Detay sayfası yakında eklenecek.", "Tamam");
    }

    private async void OnEventsClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SpecialEventPage());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Popüler yerleri yükle (ilk birkaç mekan)
        var places = await _appDatabase.GetPlacesAsync();
        PopularPlacesCollection.ItemsSource = places.Take(10).ToList();
    }

    private async void OnDiscoverTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//discover");
    }

    private async void OnEventsTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//events");
    }
}
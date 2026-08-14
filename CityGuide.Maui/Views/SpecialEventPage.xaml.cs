using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class SpecialEventPage : ContentPage
{

	private readonly AppDatabase _appDatabase = new AppDatabase();
    public SpecialEventPage()
	{
		InitializeComponent();
	}

    public SpecialEventPage(EventApiService eventApiService)
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            var events = await _appDatabase.GetSpecialEventsAsync();
            EventsCollection.ItemsSource = events;
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Hata", $"Etkinlikler yüklenemedi: {ex.Message}", "Tamam");
        }
    }

}
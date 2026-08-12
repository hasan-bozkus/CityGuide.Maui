using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

[QueryProperty(nameof(EventId), "id")]
public partial class CultureDetailPage : ContentPage
{
    private readonly AppDatabase _appDatabase = new AppDatabase();
	public string EventId { get; set; } = string.Empty;

	public CultureDetailPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (int.TryParse(EventId, out int eventId))
        {
            await LoadCultureDetailAsync(eventId);
        }
    }

    private async Task LoadCultureDetailAsync(int eventId)
    {
        var allEvents = await _appDatabase.GetEventsAsync();
        var getEvent = allEvents.FirstOrDefault(e => e.EventId == eventId);

        EventImage.Source = getEvent?.ImageName;
        TitleLabel.Text = getEvent?.Title;
        DateLabel.Text = getEvent?.DateText;
        DateDetailLabel.Text = getEvent?.DateText;
        LocationLabel.Text = getEvent?.Location;
        LocationDetailLabel.Text = getEvent?.Location;
        CategoryLabel.Text = getEvent?.CategoryName;
        CategoryDetailLabel.Text = getEvent?.CategoryName;
        RatingLabel.Text = getEvent?.Rating > 0 ? $"{getEvent.Rating:0.0} / 5" : "-";

        CategoryBadge.BackgroundColor = getEvent?.BadgeColor;
        CategoryLabel.TextColor = getEvent?.BadgeTextColor;
    }


    private async void OnActionButtonClicked(object sender, EventArgs e)
	{
        //öylesine koydum bir espirisi yok
	}
}
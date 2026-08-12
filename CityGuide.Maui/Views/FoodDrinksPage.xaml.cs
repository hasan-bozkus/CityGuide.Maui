using CityGuide.Maui.Models;
using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class FoodDrinksPage : ContentPage
{
	private readonly AppDatabase _appDatabase = new AppDatabase();
    private List<FoodPlace> _allPlaces = new List<FoodPlace>();
    private List<FoodFilterItem> _filterItems = new List<FoodFilterItem>();
    private string _selectedFilter = "Tümü";

    public FoodDrinksPage()
	{
		InitializeComponent();
        _filterItems = new List<FoodFilterItem>
        {
            new FoodFilterItem { Name = "Tümü", IsSelected = true },
            new FoodFilterItem { Name = "Pasta" },
            new FoodFilterItem { Name = "Pizza" },
            new FoodFilterItem { Name = "Fine Dining" },
            new FoodFilterItem { Name = "Aperitivo" },
            new FoodFilterItem { Name = "Gelato" }
        };

        FilterCollection.ItemsSource = _filterItems;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadFoodPlacesAsync();
        FilterCollection.SelectedItem = _filterItems.First(i => i.Name == "Tümü");
    }

    private async Task LoadFoodPlacesAsync()
    {
        _allPlaces = await _appDatabase.GetFoodPlacesAsync();
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        if (_selectedFilter == "Tümü")
        {
            FoodPlacesCollection.ItemsSource = _allPlaces;
        }
        else
        {
            FoodPlacesCollection.ItemsSource = _allPlaces
                .Where(p => p.CuisineType == _selectedFilter)
                .ToList();
        }
    }

    private void OnFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not FoodFilterItem selected)
            return;

        foreach (var item in _filterItems)
        {
            item.IsSelected = (item == selected);
        }

        FilterCollection.ItemsSource = null;
        FilterCollection.ItemsSource = _filterItems;
        FilterCollection.SelectedItem = selected;

        _selectedFilter = selected.Name;
        ApplyFilter();
    }

    private async void OnViewDetailsClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Detaylar", "Detay sayfası yakında eklenecek.", "Tamam");
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnHomeTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }

    private async void OnDiscoverTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//discover");
    }

    private async void OnEventsTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//events");
    }

    private async void OnProfileTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("profile");
    }
}
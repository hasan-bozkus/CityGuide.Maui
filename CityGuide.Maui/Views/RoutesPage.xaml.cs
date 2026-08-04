using CityGuide.Maui.Models;
using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class RoutesPage : ContentPage
{
    private List<Route> _allRoutes = new List<Route>();
    private string _selectedCategory = "Tümü";
    private List<RouteFilterItem> _filterItems = new List<RouteFilterItem>();

    private readonly AppDatabase _appDatabase = new AppDatabase();

    public RoutesPage()
    {
        InitializeComponent();
        _filterItems = new List<RouteFilterItem>
    {
        new RouteFilterItem { Name = "Tümü", Icon = "\ue55b", IsSelected = true },
        new RouteFilterItem { Name = "Aile Dostu", Icon = "\uf00c" },
        new RouteFilterItem { Name = "Lüks Alışveriş", Icon = "\ue8cc" },
        new RouteFilterItem { Name = "Sanat & Kültür", Icon = "\ue8f8" }
    };

        FilterCollection.ItemsSource = _filterItems;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadRoutesAsync();
        FilterCollection.SelectedItem = _filterItems.First(i => i.Name == "Tümü");
    }

    private void OnFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not RouteFilterItem selected)
            return;

        // Tüm öğelerin seçim durumunu güncelle
        foreach (var item in _filterItems)
        {
            item.IsSelected = (item == selected);
        }

        // Listeyi yeniden ata ki renkler tazelensin
        FilterCollection.ItemsSource = null;
        FilterCollection.ItemsSource = _filterItems;
        FilterCollection.SelectedItem = selected;

        _selectedCategory = selected.Name;
        ApplyFilter();
    }


    private async Task LoadRoutesAsync()
    {
        _allRoutes = await _appDatabase.GetRoutesAsync();
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        if (_selectedCategory == "Tümü")
        {
            RoutesCollection.ItemsSource = _allRoutes;
        }
        else
        {
            RoutesCollection.ItemsSource = _allRoutes
                .Where(r => r.Category == _selectedCategory)
                .ToList();
        }
    }

    private async void OnRouteTapped(object sender, TappedEventArgs e)
    {
        if (sender is not Border border) return;
        if (border.BindingContext is not Route route) return;

        await Shell.Current.GoToAsync($"routedetail?id={route.RouteId}");
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
}
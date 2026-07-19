using CityGuide.Maui.Models;
using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class CulturePage : ContentPage
{
    private readonly AppDatabase _appDatabase = new AppDatabase();
    private List<Event> _allEvents = new List<Event>();

    public CulturePage()
    {
        InitializeComponent();
    }

    // sayfa ekrana geldiğinde çalışır.
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var categories = await _appDatabase.GetCategoriesAsync();

        // Listenin başına "Tümü" ekle (veritabanında yok, sadece arayüz için)
        categories.Insert(0, new Category { CategoryId = 0, CategoryName = "Tümü" });

        CategoriesCollection.ItemsSource = categories;

        // --- Etkinlikler ---
        _allEvents = await _appDatabase.GetEventsWithCategoryAsync();
        EventsCollection.ItemsSource = _allEvents;

        CategoriesCollection.SelectedItem = categories[0];

        //StatusLabel.Text = $"{categories.Count} kategori, {events.Count} etkinlik bulundu.";
    }

    // Bir kategori seçilince çalışır
    private void OnCategorySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Seçili öğeyi al
        if (e.CurrentSelection.FirstOrDefault() is not Category category)
            return;

        if (category.CategoryId == 0)
        {
            // "Tümü" -> hepsini göster
            EventsCollection.ItemsSource = _allEvents;
        }
        else
        {
            // Seçilen kategoriye ait etkinlikleri süz
            var filtered = _allEvents
                .Where(ev => ev.CategoryId == category.CategoryId)
                .ToList();

            EventsCollection.ItemsSource = filtered;
        }
    }
}
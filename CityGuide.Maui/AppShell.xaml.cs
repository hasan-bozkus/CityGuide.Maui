using CityGuide.Maui.Views;

namespace CityGuide.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("specialevent", typeof(SpecialEventPage));
            Routing.RegisterRoute("routedetail", typeof(RouteDetailPage));
            Routing.RegisterRoute("routes", typeof(RoutesPage));
            Routing.RegisterRoute("profile", typeof(ProfilePage));
            Routing.RegisterRoute("fooddrinks", typeof(FoodDrinksPage));
            Routing.RegisterRoute("cultures", typeof(CulturePage));
            Routing.RegisterRoute("culturedetail", typeof(CultureDetailPage));
            Routing.RegisterRoute("favorites", typeof(FavoritesPage));
            Routing.RegisterRoute("placedetail", typeof(PlaceDetailPage));
            Routing.RegisterRoute("dashboard", typeof(DashboardPage));
        }
    }
}

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
        }
    }
}

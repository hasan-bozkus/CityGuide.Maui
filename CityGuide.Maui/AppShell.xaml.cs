using CityGuide.Maui.Views;

namespace CityGuide.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("specialevent", typeof(SpecialEventPage));
        }
    }
}

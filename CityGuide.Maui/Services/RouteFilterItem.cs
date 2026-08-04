using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Services
{
    public class RouteFilterItem
    {
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        public Color BackgroundColor => IsSelected ? Color.FromArgb("#0D47A1") : Color.FromArgb("#FFFFFF");
        public Color BorderColor => IsSelected ? Color.FromArgb("#0D47A1") : Color.FromArgb("#C3C6D4");
        public Color TextColor => IsSelected ? Color.FromArgb("#FFFFFF") : Color.FromArgb("#191C1D");

        public override string ToString() => Name;
    }
}

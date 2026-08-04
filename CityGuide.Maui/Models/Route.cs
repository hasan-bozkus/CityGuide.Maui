using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("Routes")]
    public class Route
    {
        [PrimaryKey, AutoIncrement]
        public int RouteId { get; set; }

        [NotNull]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CostRange { get; set; } = string.Empty;
    }
}

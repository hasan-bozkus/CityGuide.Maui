using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("RouteStops")]
    public class RouteStop
    {
        [PrimaryKey, AutoIncrement]
        public int RouteStopId { get; set; }

        [NotNull]
        public int RouteId { get; set; }

        [NotNull]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconGlyph { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }
}

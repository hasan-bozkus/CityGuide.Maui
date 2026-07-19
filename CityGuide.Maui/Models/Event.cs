using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int EventId { get; set; }

        [NotNull]
        public string Title { get; set; } = string.Empty;

        [NotNull]
        public int CategoryId { get; set; }

        public string DateText { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public double Rating { get; set; }

        [Ignore]
        public string? CategoryName { get; set; }
    }
}

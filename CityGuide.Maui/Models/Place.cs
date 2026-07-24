using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("Places")]
    public class Place
    {
        [PrimaryKey, AutoIncrement]
        public int PlaceId { get; set; }

        [NotNull]
        public string Title { get; set; }

        [NotNull]
        public string CategoryName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public double Score { get; set; }
        public string Location { get; set; } = string.Empty;

        [Ignore]
        public bool IsFavorite { get; set; }

        // Kalbin ikonu: favoriyse dolu kalp, değilse boş kalp
        [Ignore]
        public string HeartIcon => IsFavorite ? "\ue87d" : "\ue87e";

        // Kalbin rengi: favoriyse kırmızı, değilse gri
        [Ignore]
        public string HeartColor => IsFavorite ? "#BA1A1A" : "#737783";
    }
}

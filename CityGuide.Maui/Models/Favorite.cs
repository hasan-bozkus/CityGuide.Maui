using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("Favorites")]
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public int FavoriteId { get; set; }

        [NotNull]
        public int UserId { get; set; }

        [NotNull]
        public int PlaceId { get; set; }

    }
}

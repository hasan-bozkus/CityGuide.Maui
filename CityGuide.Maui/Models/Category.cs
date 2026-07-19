using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryId { get; set; }

        [NotNull]
        public string CategoryName { get; set; }
    }
}

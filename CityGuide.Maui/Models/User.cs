using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [NotNull]
        public string FullName { get; set; } = string.Empty;

        [NotNull, Unique] //aynı e-posta ile ikinci kez kayıt engellenir
        public string Email { get; set; } = string.Empty;

        [NotNull]
        public string Password { get; set; } = string.Empty;

    }
}

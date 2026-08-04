using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Models
{
    [Table("TransportationLines")]
    public class TransportationLine
    {
        [PrimaryKey, AutoIncrement]
        public int TransportationLineId { get; set; }

        [NotNull]
        public string Type { get; set; } = string.Empty;

        [NotNull]
        public string LineCode { get; set; } = string.Empty;

        [NotNull]
        public string LineName { get; set; } = string.Empty;

        [NotNull]
        public string Route { get; set; } = string.Empty;

        [NotNull]
        public string Status { get; set; } = string.Empty;

        [NotNull]
        public string ColorHex { get; set; } = string.Empty;
    }
}

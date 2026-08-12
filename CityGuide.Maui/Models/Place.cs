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
        public string Title { get; set; } = string.Empty;

        [NotNull]
        public string CategoryName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public double Score { get; set; }

        public string Location { get; set; } = string.Empty;

        // --- Yeni alanlar (Detay sayfası için) ---

        public string Description { get; set; } = string.Empty;     // uzun açıklama (2 paragraf birleşik olabilir)

        public string Duration { get; set; } = string.Empty;        // "2 - 3 Saat"

        public string PriceInfo { get; set; } = string.Empty;       // "€10,00'dan başlayan fiyatlarla"

        public string ReviewCount { get; set; } = string.Empty;     // "12b Değerlendirme" (serbest metin)

        public string Address { get; set; } = string.Empty;         // "Piazza del Duomo, 20122 Milano MI"

        public string MapImageUrl { get; set; } = string.Empty;     // mini harita görseli

        public string TicketUrl { get; set; } = string.Empty;       // gerçek bilet sitesi linki

        [Ignore]
        public bool IsFavorite { get; set; }

        [Ignore]
        public string HeartIcon => IsFavorite ? "\ue87d" : "\ue87e";

        [Ignore]
        public string HeartColor => IsFavorite ? "#BA1A1A" : "#737783";
    }
}

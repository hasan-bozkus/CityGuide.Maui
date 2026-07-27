using CityGuide.WebApi.Models;
using SQLite;

namespace CityGuide.WebApi.Services
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection? _database;

        private async Task InitAsync()
        {
            if (_database is not null)
                return;

            // API'nin kendi veritabanı dosyası
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "events.db");

            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<SpecialEvent>();

            // Tablo boşsa örnek verileri ekle (seed)
            var count = await _database.Table<SpecialEvent>().CountAsync();
            if (count == 0)
            {
                await SeedAsync();
            }
        }

        private async Task SeedAsync()
        {
            var events = new List<SpecialEvent>
            {
                new SpecialEvent
                {
                    Title = "Salone del Mobile",
                    Description = "Dünyanın önde gelen tasarım fuarı; yaşam ve tasarım yeniliklerinin geleceğini sergiliyor.",
                    DateText = "16 - 21 Nisan",
                    Category = "Öne Çıkan",
                    Rating = 4.9,
                    ImageUrl = "event_salone.jpg"
                },
                new SpecialEvent
                {
                    Title = "Milano Moda Haftası",
                    Description = "İtalyan zarafetinin ve küresel moda trendlerinin zirvesini deneyimleyin.",
                    DateText = "Şubat & Eylül",
                    Category = "Canlı",
                    Rating = 4.8,
                    ImageUrl = "event_fashion.jpg"
                },
                new SpecialEvent
                {
                    Title = "Noel Pazarları",
                    Description = "Duomo'nun gölgesinde otantik el sanatları ve festival lezzetleri.",
                    DateText = "1 Aralık - 6 Ocak",
                    Category = "Kış",
                    Rating = 4.9,
                    ImageUrl = "event_christmas.jpg"
                },
                new SpecialEvent
                {
                    Title = "JazzMi Festivali",
                    Description = "Tarihi mekanlarda ve gizli barlarda şehir çapında caz etkinlikleri.",
                    DateText = "Ekim - Kasım",
                    Category = "Sonbahar",
                    Rating = 4.7,
                    ImageUrl = "event_jazz.jpg"
                },
                new SpecialEvent
                {
                    Title = "La Scala Açılış Gecesi",
                    Description = "Milano kültür takviminin en prestijli akşamı.",
                    DateText = "7 Aralık",
                    Category = "Öne Çıkan",
                    Rating = 5.0,
                    ImageUrl = "event_scala.jpg"
                },
                new SpecialEvent
                {
                    Title = "Taste of Milano",
                    Description = "Milano'nun en iyi şeflerinin sunduğu seçkin lezzetlerde bir yolculuk.",
                    DateText = "8 - 12 Mayıs",
                    Category = "Yaz",
                    Rating = 4.6,
                    ImageUrl = "event_taste.jpg"
                }
            };

            await _database!.InsertAllAsync(events);
        }

        // Tüm etkinlikleri getir
        public async Task<List<SpecialEvent>> GetSpecialEventsAsync()
        {
            await InitAsync();
            return await _database!.Table<SpecialEvent>().ToListAsync();
        }

        public async Task CreateSpecialEventAsync(SpecialEvent specialEvent)
        {
            await InitAsync();
            await _database!.InsertAsync(specialEvent);
        }
    }
}

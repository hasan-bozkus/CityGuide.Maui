using SQLite;
using CityGuide.Maui.Models;

namespace CityGuide.Maui.Services
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection _connection;

        private async Task InitAsync()
        {
            if (_connection is not null)
                return;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cityguide.db");

            // Dosyanın tam yolunu görelim (SQLite Browser'da açmak için)
            System.Diagnostics.Debug.WriteLine($"[DB PATH] {dbPath}");

            _connection = new SQLiteAsyncConnection(dbPath);

            // Code-first: modellere bakıp tabloları oluştur (yoksa)
            await _connection.CreateTableAsync<Category>();
            await _connection.CreateTableAsync<Event>();
            await _connection.CreateTableAsync<User>();
            await _connection.CreateTableAsync<Favorite>();
            await _connection.CreateTableAsync<Place>();
        }

        // --- Okuma metotları ---

        public async Task<List<Category>> GetCategoriesAsync()
        {
            await InitAsync();
            return await _connection.Table<Category>().ToListAsync();
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            await InitAsync();
            return await _connection.Table<Event>().ToListAsync();
        }

        public async Task<List<Event>> GetEventsWithCategoryAsync()
        {
            await InitAsync();
            var events = await _connection.Table<Event>().ToListAsync();
            var categories = await _connection.Table<Category>().ToListAsync();

            foreach(var item in events)
            {
                var matchingCategory = categories.FirstOrDefault(c => c.CategoryId == item.CategoryId);
                if(matchingCategory is not null)
                {
                    item.CategoryName = matchingCategory.CategoryName;
                }
                else
                {
                    item.CategoryName = "Bilinmiyor";
                }
            }

            return events;
        }

        // --- Yazma metotları (uygulama içinden eklemek istersen) ---

        public async Task<int> AddCategoryAsync(Category category)
        {
            await InitAsync();
            return await _connection.InsertAsync(category);
        }

        public async Task<int> AddEventAsync(Event newEvent)
        {
            await InitAsync();
            return await _connection.InsertAsync(newEvent);
        }

        // --- Kullanıcı metotları ---

        // Yeni kullanıcı ekler. E-posta zaten varsa [Unique] yüzünden hata fırlatır.
        public async Task<int> AddUserAsync(User user)
        {
            await InitAsync();
            return await _connection.InsertAsync(user);
        }

        // E-postaya göre kullanıcı arar. Bulamazsa null döner.
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            await InitAsync();
            return await _connection.Table<User>()
                                  .Where(u => u.Email == email)
                                  .FirstOrDefaultAsync();
        }

        // --- Mekan (Place) metotları ---

        public async Task<List<Place>> GetPlacesAsync()
        {
            await InitAsync();
            return await _connection.Table<Place>().ToListAsync();
        }

        // --- Favori metotları ---

        // Bir mekanı favorilere ekler (insert)
        public async Task<int> AddFavoriteAsync(int userId, int placeId)
        {
            await InitAsync();
            var favorite = new Favorite { UserId = userId, PlaceId = placeId };
            return await _connection.InsertAsync(favorite);
        }

        // Bir mekanı favorilerden çıkarır (delete)
        public async Task<int> RemoveFavoriteAsync(int userId, int placeId)
        {
            await InitAsync();
            var existing = await _connection.Table<Favorite>()
                .Where(f => f.UserId == userId && f.PlaceId == placeId)
                .FirstOrDefaultAsync();

            if (existing is null)
                return 0;

            return await _connection.DeleteAsync(existing);
        }

        // Bir mekan favori mi? (true/false)
        public async Task<bool> IsFavoriteAsync(int userId, int placeId)
        {
            await InitAsync();
            var existing = await _connection.Table<Favorite>()
                .Where(f => f.UserId == userId && f.PlaceId == placeId)
                .FirstOrDefaultAsync();

            return existing is not null;
        }

        // Bir kullanıcının favorilediği mekanları getirir (join mantığı)
        public async Task<List<Place>> GetFavoritePlacesAsync(int userId)
        {
            await InitAsync();

            // 1) Bu kullanıcının favori kayıtlarını çek
            var favorites = await _connection.Table<Favorite>()
                .Where(f => f.UserId == userId)
                .ToListAsync();

            // 2) Favorilenen PlaceId'leri topla
            var favoritePlaceIds = favorites.Select(f => f.PlaceId).ToList();

            // 3) Bu Id'lere sahip mekanları çek
            var allPlaces = await _connection.Table<Place>().ToListAsync();
            var favoritePlaces = allPlaces
                .Where(p => favoritePlaceIds.Contains(p.PlaceId))
                .ToList();

            return favoritePlaces;
        }
    }
}

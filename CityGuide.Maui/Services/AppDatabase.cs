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
    }
}

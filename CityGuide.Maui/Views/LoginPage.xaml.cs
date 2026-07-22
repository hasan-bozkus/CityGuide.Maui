using CityGuide.Maui.Models;
using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class LoginPage : ContentPage
{
    private readonly AppDatabase _appDatabase = new AppDatabase();

    public LoginPage()
	{
		InitializeComponent();
	}

    private void OnTogglePasswordVisibility(object sender, TappedEventArgs e)
    {
        PasswordEntry.IsPassword = !PasswordEntry.IsPassword;

        // Göz ikonunu duruma göre değiştir
        if (PasswordEntry.IsPassword)
            PasswordToggleIcon.Text = "\ue8f4";   // visibility (göz açık)
        else
            PasswordToggleIcon.Text = "\ue8f5";   // visibility_off (göz çizgili)
    }

    private async void OnForgotPasswordTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Şifremi Unuttum", "Şifre sıfırlama yakında eklenecek.", "Tamam");
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // 1) Girilen veriyi oku
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        // 2) Boş alan kontrolü
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlertAsync("Eksik Bilgi", "Lütfen e-posta ve şifrenizi girin.", "Tamam");
            return;
        }

        // 3) Veritabanından bu e-postaya sahip kullanıcıyı bul
        User? user = await _appDatabase.GetUserByEmailAsync(email);

        // 4) Kullanıcı yok mu, ya da şifre eşleşmiyor mu?
        if (user is null || user.Password != password)
        {
            await DisplayAlertAsync("Giriş Başarısız", "E-posta veya şifre hatalı.", "Tamam");
            return;
        }

        // 5) Başarılı giriş
        await DisplayAlertAsync("Hoş Geldiniz", $"Giriş başarılı! Merhaba, {user.FullName}.", "Tamam");
    }

    private async void OnGoogleTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Google", "Google ile giriş yakında eklenecek.", "Tamam");
    }

    private async void OnAppleTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Apple", "Apple ile giriş yakında eklenecek.", "Tamam");
    }

    private async void OnRequestAccessTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Erişim Talep Et", "Kayıt ekranı yakında bağlanacak.", "Tamam");
    }
}
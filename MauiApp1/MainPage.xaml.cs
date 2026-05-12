namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveBtnClicked(object sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
            string tresc = YourText.Text;

            await File.WriteAllTextAsync(sciezka, tresc);
        }

        private async void ReadBtnClicked(object sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");

            if (File.Exists(sciezka))
            {
                Result.Text = await File.ReadAllTextAsync(sciezka);
            }
            else await DisplayAlertAsync("Uwaga","Plik nie istnieje","ok");
        } 
    }
}

/* *****************************
nazwa funkcji: SaveBtnClicked
opis funkcji: funkcja zapisuje wartosc z pola edycyjnego do pliku
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Słotwiński
*****************************
nazwa funkcji: ReadBtnClicked
opis funkcji: funkcja pobiera tekst z pliku i go wyswietla
parametry: object sender, EventArgs e
zwracany typ i opis: (string) - tekst pobrany z pliku
autor: Karol Słotwiński
***************************** */
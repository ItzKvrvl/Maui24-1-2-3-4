using System.Collections.ObjectModel;

namespace r24z3
{
    public partial class MainPage : ContentPage
    {
        public class PlikInfo
        {
            public string Nazwa { get; set; }
            public string Rozmiar { get; set; }
        }
        public ObservableCollection<PlikInfo> ListaPlikow { get; set; } = new();
        private readonly string _katalog = FileSystem.Current.AppDataDirectory;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            LoadFiles();
        }

        private void LoadFiles()
        {
            ListaPlikow.Clear();
            string[] pliki = Directory.GetFiles(_katalog);
            long totalsize = 0;

            foreach (string sciezka in pliki)
            {
                FileInfo info = new FileInfo(sciezka);
                totalsize += info.Length;

                PlikInfo nowyPlik = new PlikInfo
                {
                    Nazwa = info.Name,
                    Rozmiar = (info.Length / 1024.0).ToString("F2") + " KB"
                };
                ListaPlikow.Add(nowyPlik);
            }
            AllFiles.Text = $"plikow {pliki.Length}, laczny rozmiar: {totalsize / 1024.0:F2}";
        }

        private async void OnFileSelected(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection.FirstOrDefault() is PlikInfo wybrany)
            {
                string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, wybrany.Nazwa);
                string tresc = File.ReadAllText(sciezka);
                await DisplayAlert(wybrany.Nazwa, tresc, "ok");

                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var plik = (PlikInfo)button.BindingContext;

            bool confirm = await DisplayAlert("potwierdzenie", $"czy na pewno usunac {plik.Nazwa}?", "tak", "nie");
            if (confirm)
            {
                string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, plik.Nazwa);
                File.Delete(sciezka);
                LoadFiles();
            }
        }
    }
}

/* *****************************
nazwa funkcji: LoadFiles
opis funkcji: funkcja wyswietla liste wsztstkich plikow, ich liczbe i laczny rozmair
parametry: brak
zwracany typ i opis: (string) - tekst pobrany z plikow, wyswietlony na ekranie
                     (long) - laczny rozmiar plikow
                     (int) - liczba plikow
autor: Karol Słotwiński
*****************************
nazwa funkcji: OnFileSelected
opis funkcji: funkcja wyswietla alert z nazwa i trescia wybranego pliky
parametry: object sender, SelectionChangedEventArgs e
zwracany typ i opis: informacja o pliku wybranym przez uzytkownika
autor: Karol Słotwiński
*****************************
nazwa funkcji: OnDeleteClicked
opis funkcji: funkcja usuwa wybrany plik
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Słotwiński
***************************** */
namespace r24z4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnEksportClicked(object sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatki_eksport.txt");
            string tresc = DateTime.Now.ToString("dd.MM.yyyy HH:mm ") + "\n" + EditorWpis.Text + "\n";

            await File.WriteAllTextAsync(sciezka, tresc);
            Informacja.Text = Informacja.Text + "\n" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "Eksport";
        }

        private async void OnImportClicked(object sender, EventArgs e)
        {
            try
            {
                var wynik = await FilePicker.Default.PickAsync();
                if (wynik != null)

                {
                    string nazwaPliku = wynik.FileName;
                    string pelnaSciezka = wynik.FullPath;
                    await DisplayAlertAsync("Wybrano plik", $"Nazwa: {nazwaPliku}", "OK");
                    string tresc = await File.ReadAllTextAsync(pelnaSciezka);
                    EditorWpis.Text = tresc;
                    Informacja.Text = Informacja.Text + "\n" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "Import";
                }
            }

            catch (Exception ex)
            {
                await DisplayAlertAsync("Błąd", $"Nie udało się wybrać pliku: {ex.Message}", "OK");
            }
        }
    }
}

/* *****************************
nazwa funkcji: OnEksportClicked
opis funkcji: funkcja odpowiada z eksport pliku notatki_eksport.txt i wyswietlenie komunikatu o tym
parametry: object sender, EventArgs e
zwracany typ i opis: (string) - tekst pobrany z pola do pliku, wyswietlony na ekranie
autor: Karol Słotwiński
*****************************
nazwa funkcji: OnImportClicked
opis funkcji: funkcja umozliwia wybranie pliku z urzadzenia i wyswietla go na ekranie
parametry: object sender, EventArgs e
zwracany typ i opis: plik wybrany z urzadzenia
autor: Karol Słotwiński
***************************** */

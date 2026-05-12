namespace r24z2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
            if (File.Exists(sciezka))
            {
                string tresc = File.ReadAllText(sciezka);
                YourMessages.Text = tresc;
            }
        }

        private async void AddTextBtnClicked(object sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "moj_plik.txt");
            string tresc = YourText.Text;
            DateTime czas = DateTime.Now;

            await File.WriteAllTextAsync(sciezka, YourMessages.Text + czas + "  -  " + tresc + "\n");

            if (File.Exists(sciezka))
            {
                YourMessages.Text = await File.ReadAllTextAsync(sciezka);
            }
            else await DisplayAlertAsync("Uwaga", "Plik nie istnieje", "ok");
        }

        private void ClearBtn(object sender, EventArgs e)
        {
            YourMessages.Text = "";
            YourText.Text = string.Empty;
        }
    }
}

/* *****************************
nazwa funkcji: AddTextBtnClicked
opis funkcji: funkcja pobiera tekst z pola, zapisuje go w pliku i wyswietla jego zawartosc jeden pod drugim
parametry: object sender, EventArgs e
zwracany typ i opis: (string) - tekst pobrany z pola do pliku, wyswietlony na ekranie
autor: Karol Słotwiński
*****************************
nazwa funkcji: ClearBtn
opis funkcji: funkcja czysci pole edycyjne oraz caly plik z tekstem
parametry: object sender, EventArgs e
zwracany typ i opis: brak
autor: Karol Słotwiński
***************************** */
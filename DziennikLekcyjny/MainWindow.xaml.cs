using DziennikLekcyjny.Interfaces;
using DziennikLekcyjny.Models;
using DziennikLekcyjny.Views;
using DziennikLekcyjny.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DziennikLekcyjny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDziennikService _dziennik;
        public Nauczyciel ZalogowanoJako = new Nauczyciel();
        private MainWindowView _context;
        private Ocena Ocena { get; set; } = new Ocena();
        public MainWindow(IDziennikService dziennikService)
        {
            InitializeComponent();
            _dziennik = dziennikService;
            _context = new MainWindowView();
            this.DataContext = _context;

            Ocena.IdNauczyciela = ZalogowanoJako.Id;
            LoadKlasy();
        }

        public void LoadKlasy()
        {
            var klasyLista = new KlasyView();
            DodawanieOcenButton.Visibility = Visibility.Hidden;
            _dziennik.GetKlasy().ForEach(klasa => klasyLista.Klasy.Add(klasa));
            klasyLista.WybranoKlase += (KlasaList klasa) =>
            {
                var przedmiotyView = new PrzedmiotyView();
                var przedmiotyLista = _dziennik.GetPrzedmioty(klasa.Id);
                przedmiotyLista.ForEach(przedmiot =>
                {
                    przedmiot.KlasaId = klasa.Id;
                    przedmiotyView.Przedmioty.Add(przedmiot);
                });

                przedmiotyView.WybranoPrzedmiot += (PrzedmiotList przedmiot) =>
                {
                    Ocena.IdPrzedmiotu = przedmiot.Id;
                    var uczniowieView = new UczniowieView();
                    var uczniowie = _dziennik.GetUczniowie(przedmiot.KlasaId, przedmiot.Id);
                    uczniowie.ForEach(uczen =>
                    {
                        uczen.PrzedmiotId = przedmiot.Id;
                        uczniowieView.Uczniowie.Add(uczen);
                    });

                    uczniowieView.WybranoUcznia += (UczenList uczen) =>
                    {
                        Ocena.IdUcznia = uczen.Id;
                        DodawanieOcenButton.Visibility = Visibility.Visible;
                        var ocenyView = new OcenyView();
                        var oceny = _dziennik.GetOceny(uczen.Id, przedmiot.Id);
                        oceny.ForEach(ocena => ocenyView.Oceny.Add(ocena));
                        ocenyView.WybranoOcene += (Ocena ocena) =>
                        {
                            var ocenaOkienko = App._serviceProvider.GetService<NowaOcenaWindow>();
                            ocenaOkienko.OcenaDoWstawienia = ocena;
                            ocenaOkienko.Tryb = 1;

                            ocenaOkienko.DodanoOcene += () =>
                            {
                                LoadKlasy();
                            };
                            ocenaOkienko.Show();
                        };
                        Wyswietlacz.Navigate(ocenyView);
                    };

                    Wyswietlacz.Navigate(uczniowieView);
                };
                Wyswietlacz.Navigate(przedmiotyView);
            };
            Wyswietlacz.Navigate(klasyLista);
        }

        public void SetNauczyciel(Nauczyciel nauczyciel)
        {
            ZalogowanoJako = nauczyciel;
            _context.SetNauczyciel(nauczyciel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadKlasy();
        }

        private void DodajOcene(object sender, RoutedEventArgs e)
        {
            var nowaOcena = new Ocena
            {
                IdUcznia = Ocena.IdUcznia,
                IdPrzedmiotu = Ocena.IdPrzedmiotu,
                IdNauczyciela = ZalogowanoJako.Id
            };

            var wstawianieOcenyOkienko = App._serviceProvider.GetService<NowaOcenaWindow>();
            wstawianieOcenyOkienko.Tryb = 0;
            wstawianieOcenyOkienko.OcenaDoWstawienia = nowaOcena;

            wstawianieOcenyOkienko.DodanoOcene += () =>
            {
                LoadKlasy();
            };

            wstawianieOcenyOkienko.Show();

        } 
    }
}

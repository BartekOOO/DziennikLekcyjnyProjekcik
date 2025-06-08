using DziennikLekcyjny.Interfaces;
using DziennikLekcyjny.Models;
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
using System.Windows.Shapes;

namespace DziennikLekcyjny.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy NowaOcenaWindow.xaml
    /// </summary>
    public partial class NowaOcenaWindow : Window
    {
        private readonly IDziennikService _dziennik;
        public NowaOcenaWindowViewModel _context;
        public event Action DodanoOcene;
        public int Tryb {  get; set; } = 0; //Dodawanie 0 Edytowanie 1

        public Ocena OcenaDoWstawienia {  get; set; }

        public NowaOcenaWindow(IDziennikService dziennikService)
        {
            InitializeComponent();
            _dziennik = dziennikService;
            _context = new NowaOcenaWindowViewModel();
            this.DataContext = _context;
            OcenaDoWstawienia = new Ocena();
        }

        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(Int32.TryParse(OcenaTextBox.Text,out int ocena))
            {
                if (Int32.TryParse(WagaTextBox.Text, out int waga))
                {
                    OcenaDoWstawienia.Wartosc = ocena;
                    OcenaDoWstawienia.Waga = waga;
                    if (Tryb == 0)
                    {
                        _dziennik.WstawOcene(OcenaDoWstawienia);
                    }
                    else
                    {
                        _dziennik.EdytujOcene(OcenaDoWstawienia);
                    }

                    DodanoOcene.Invoke();
                    this.Close();
                }
            }
        }
    }
}

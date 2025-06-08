using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DziennikLekcyjny.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UczniowieView.xaml
    /// </summary>
    public partial class UczniowieView : Page
    {
        public ObservableCollection<UczenList> Uczniowie {  get; set; }
        public event Action<UczenList> WybranoUcznia;
        public UczniowieView()
        {
            InitializeComponent();
            Uczniowie = new ObservableCollection<UczenList>();
            Lista.ItemsSource = Uczniowie;
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var wybranyUczen = (UczenList)Lista.SelectedItem;
            if (wybranyUczen != null)
                WybranoUcznia?.Invoke(wybranyUczen);
        }
    }
}

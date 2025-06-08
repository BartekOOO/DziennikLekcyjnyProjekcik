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
    /// Logika interakcji dla klasy OcenyView.xaml
    /// </summary>
    public partial class OcenyView : Page
    {
        public event Action<Ocena> WybranoOcene;
        public ObservableCollection<Ocena> Oceny {  get; set; }
        public OcenyView()
        {
            InitializeComponent();
            Oceny = new ObservableCollection<Ocena>();
            Lista.ItemsSource = Oceny;
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var wybranaOcena = (Ocena)Lista.SelectedItem;
            if(wybranaOcena != null ) 
                WybranoOcene?.Invoke(wybranaOcena);
        }
    }
}

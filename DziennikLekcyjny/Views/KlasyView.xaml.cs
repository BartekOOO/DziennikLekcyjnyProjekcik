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
    /// Logika interakcji dla klasy KlasyView.xaml
    /// </summary>
    public partial class KlasyView : Page
    {
        public ObservableCollection<KlasaList> Klasy { get; set; }
        public event Action<KlasaList> WybranoKlase;
        public KlasyView()
        {
            InitializeComponent();
            Klasy = new ObservableCollection<KlasaList>();
            Lista.ItemsSource = Klasy;  
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var wk = (KlasaList)Lista.SelectedItem;
            if (wk != null) 
                WybranoKlase?.Invoke(wk);
        }
    }
}

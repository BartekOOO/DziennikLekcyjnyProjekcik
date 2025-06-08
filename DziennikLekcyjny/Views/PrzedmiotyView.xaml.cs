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
    /// Logika interakcji dla klasy PrzedmiotyView.xaml
    /// </summary>
    public partial class PrzedmiotyView : Page
    {
        public ObservableCollection<PrzedmiotList> Przedmioty { get; set; }
        public event Action<PrzedmiotList> WybranoPrzedmiot;
        public PrzedmiotyView()
        {
            InitializeComponent();
            Przedmioty = new ObservableCollection<PrzedmiotList>(); 
            Lista.ItemsSource = Przedmioty;
        }

        private void Lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var si = (PrzedmiotList)Lista.SelectedItem;
            if(si != null) 
                WybranoPrzedmiot?.Invoke(si);
        }
    }
}

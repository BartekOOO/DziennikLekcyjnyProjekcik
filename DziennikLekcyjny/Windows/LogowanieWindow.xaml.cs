using DziennikLekcyjny.Interfaces;
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
using System.Windows.Shapes;

namespace DziennikLekcyjny.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy LogowanieWindows.xaml
    /// </summary>
    public partial class LogowanieWindow : Window
    {
        private readonly ILogowanieService _logowanie;
        private LogowanieWindowViewModel _context;
        public LogowanieWindow(ILogowanieService logowanieService)
        {
            InitializeComponent();
            _logowanie = logowanieService;
            _context = new LogowanieWindowViewModel();
            this.DataContext = _context;
        }

        private void Zaloguj(object sender, RoutedEventArgs e)
        {
            int id = 0;
            if (_logowanie.Zaloguj(_context.Login,_context.Password, ref id))
            {
                MainWindow main = App._serviceProvider.GetService<MainWindow>();
                main.SetNauczyciel(_logowanie.GetNauczycielInfo(id));
                main.Show();
                this.Close();
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _context.Password = ((PasswordBox)sender).Password;
        }
    }
}

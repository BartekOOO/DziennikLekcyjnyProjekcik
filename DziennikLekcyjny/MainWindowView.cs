using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny
{
    public class MainWindowView : INotifyPropertyChanged
    {
        private Nauczyciel _nauczyciel = new Nauczyciel();
        
        public void SetNauczyciel(Nauczyciel nauczyciel)
        {
            _nauczyciel = nauczyciel;
        }

        public string NazwaOkna => $"Zalogowano jako: {_nauczyciel.Imie} {_nauczyciel.Nazwisko}";


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

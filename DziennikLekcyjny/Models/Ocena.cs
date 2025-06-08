using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class Ocena
    {
        public int Id { get; set; }
        public int Wartosc {  get; set; }
        public float Waga { get; set; }
        public int IdPrzedmiotu { get; set; }
        public int IdUcznia { get; set; }
        public int IdNauczyciela { get; set; }
        public DateTime DataWstawienia { get; set; }
        public DateTime DataModyfikacji { get; set; }
    }
}

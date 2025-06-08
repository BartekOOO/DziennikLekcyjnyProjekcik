using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class Klasa
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public List<PrzedmiotKlasy> Przedmioty { get; set; } = new List<PrzedmiotKlasy>();
        public List<Uczen> Uczniowie { get; set; } = new List<Uczen>();

    }
}

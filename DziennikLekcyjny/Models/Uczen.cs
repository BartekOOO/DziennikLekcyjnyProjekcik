using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class Uczen
    {
        public int Id { get; set; }
        public string Imie {  get; set; }
        public string Nazwisko { get; set; }
        public int IdKlasy { get; set; }
    }
}

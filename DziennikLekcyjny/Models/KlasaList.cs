using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class KlasaList
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Przedmioty { get; set; }
        public int LiczbaUczniow {  get; set; }
    }
}

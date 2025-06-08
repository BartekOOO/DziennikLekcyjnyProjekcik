using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class PrzedmiotList
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int KlasaId { get; set; }
    }
}

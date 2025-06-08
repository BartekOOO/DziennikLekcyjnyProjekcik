using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class UczenList
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int LiczbaOcen {  get; set; }
        public float SredniaOcen {  get; set; }
        public int PrzedmiotId { get; set; }
    }
}

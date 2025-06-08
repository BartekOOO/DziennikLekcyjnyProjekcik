using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Interfaces
{
    public interface IDziennikService
    {
        List<KlasaList> GetKlasy();
        List<PrzedmiotList> GetPrzedmioty(int klasaId);
        List<UczenList> GetUczniowie(int klasaId, int przedmiotId);
        List<Ocena> GetOceny(int uczenId, int przedmiotId);
        void WstawOcene(Ocena ocena);
        void EdytujOcene(Ocena ocena);
    }
}

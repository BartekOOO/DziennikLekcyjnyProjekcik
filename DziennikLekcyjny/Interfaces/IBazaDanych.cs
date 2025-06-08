using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Interfaces
{
    public interface IBazaDanych
    {
        void DodajOcene(Ocena ocena);
        void ModyfikujOcene(Ocena ocena);
        float ObliczSredniaUcznia(int przedmiotId, int uczenId);
        List<Klasa> WyswietlKlasy();
        List<Przedmiot> WyswietlPrzedmioty(int idKlasy);
        List<Uczen> WyswietlUczniow(int idKlasy);
        List<Ocena> WyswietlOceny(int uczenId);
        Nauczyciel PokazNauczyciela(string login, string haslo);
        Nauczyciel PokazNauczyciela(int id);
    }
}

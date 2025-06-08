using DziennikLekcyjny.Helpers;
using DziennikLekcyjny.Interfaces;
using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Services
{
    public class BazaDanychService : IBazaDanych
    {
        private List<Klasa> _klasy;
        private List<Przedmiot> _przedmioty;
        private List<PrzedmiotKlasy> _przedmiotyRelacje;
        private List<Uczen> _uczniowie;
        private List<Ocena> _oceny;
        private List<Nauczyciel> _nauczyciele;

        public BazaDanychService()
        {
            TestDataSeeder.WypelnijFakeDane(out _klasy,out _przedmioty,out _przedmiotyRelacje,out _uczniowie,out _oceny,out _nauczyciele);
        }
        
        public void DodajOcene(Ocena ocena)
        {
            _oceny.Add(ocena);
        }

        public void ModyfikujOcene(Ocena ocena)
        {
            foreach(var oc in _oceny)
            {
                if(oc.Id == ocena.Id)
                {
                    oc.IdNauczyciela = ocena.IdNauczyciela;
                    oc.DataModyfikacji = ocena.DataModyfikacji;
                    oc.DataWstawienia = oc.DataWstawienia;
                    oc.IdUcznia = ocena.IdUcznia;
                    oc.IdPrzedmiotu = ocena.IdPrzedmiotu;
                    oc.Waga = ocena.Waga;
                    oc.Wartosc = ocena.Wartosc;
                    break;
                }
            }
        }

        public float ObliczSredniaUcznia(int przedmiotId, int uczenId)
        {
            var ocenyUcznia = _oceny.Where(o => o.IdUcznia == uczenId && o.IdPrzedmiotu == przedmiotId);
            if (!ocenyUcznia.Any())
                return 0;

            float sumaWazona = ocenyUcznia.Sum(o => o.Wartosc * o.Waga);
            float sumaWag = ocenyUcznia.Sum(o => o.Waga);

            return sumaWag == 0 ? 0 : sumaWazona / sumaWag;
        }

        public Nauczyciel PokazNauczyciela(string login, string haslo)
        {
            return _nauczyciele.FirstOrDefault(nauczyciel => (nauczyciel.Haslo == haslo && nauczyciel.Login == login));
        }

        public Nauczyciel PokazNauczyciela(int id)
        {
            return _nauczyciele.FirstOrDefault(nauczyciel => nauczyciel.Id == id);
        }

        public List<Klasa> WyswietlKlasy()
        {
            return _klasy;
        }

        public List<Ocena> WyswietlOceny(int uczenId)
        {
            return _oceny.Where(ocena => ocena.IdUcznia == uczenId).ToList();
        }

        public List<Przedmiot> WyswietlPrzedmioty(int idKlasy)
        {
            var relacje = _przedmiotyRelacje.Where(relacja => relacja.IdKlasy == idKlasy);
            return _przedmioty.Where(przedmiot => relacje.Select(a=>a.IdPrzedmiotu).Contains(przedmiot.Id)).ToList();
        }

        public List<Uczen> WyswietlUczniow(int idKlasy)
        {
            return _uczniowie.Where(uczen => uczen.IdKlasy == idKlasy).ToList();
        }
    }
}

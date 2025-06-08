using DziennikLekcyjny.Interfaces;
using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Services
{
    public class DziennikService : IDziennikService
    {
        private readonly IBazaDanych _bazaDanych;

        public DziennikService(IBazaDanych bazaDanych)
        {
            _bazaDanych = bazaDanych;
        }

        public void EdytujOcene(Ocena ocena)
        {
            _bazaDanych.ModyfikujOcene(ocena);
        }

        public List<KlasaList> GetKlasy()
        {
            var listaKlas = new List<KlasaList>();

            foreach(var klasa in _bazaDanych.WyswietlKlasy())
            {
                var klasaDoListy = new KlasaList();
                klasaDoListy.Id = klasa.Id;
                klasaDoListy.Nazwa = klasa.Nazwa;
                klasaDoListy.LiczbaUczniow = _bazaDanych.WyswietlUczniow(klasa.Id).ToList().Count;
                klasaDoListy.Przedmioty = String.Join(", ",_bazaDanych.WyswietlPrzedmioty(klasa.Id).Select(przedmiot => przedmiot.Nazwa.Substring(0,przedmiot.Nazwa.Length >= 2 ? 2 : przedmiot.Nazwa.Length-1)));
                listaKlas.Add(klasaDoListy);
            }


            return listaKlas;
        }

        public List<Ocena> GetOceny(int uczenId, int przedmiotId)
        {
            var ocenyUcznia = _bazaDanych.WyswietlOceny(uczenId).Where(ocena => ocena.IdPrzedmiotu == przedmiotId);
            return ocenyUcznia.ToList();
        }

        public List<PrzedmiotList> GetPrzedmioty(int klasaId)
        {
            var przedmioty = _bazaDanych.WyswietlPrzedmioty(klasaId);
            var przedmiotyList = new List<PrzedmiotList>();
            foreach (var przedmiot in przedmioty)
            {
                var przed = new PrzedmiotList();
                przed.Nazwa = przedmiot.Nazwa;
                przed.Id = przedmiot.Id;
                przed.KlasaId = 0;
                przedmiotyList.Add(przed);
            }
            return przedmiotyList;
        }

        public List<UczenList> GetUczniowie(int klasaId, int przedmiotId)
        {
            var listaUczniow = new List<UczenList>();

            var przedmiotyKlasy = _bazaDanych.WyswietlPrzedmioty(klasaId);
            foreach(var uczen in _bazaDanych.WyswietlUczniow(klasaId))
            {
                var uczenDoDodania = new UczenList();
                uczenDoDodania.Id = uczen.Id;
                uczenDoDodania.Nazwa = $"{uczen.Imie} {uczen.Nazwisko}";
                uczenDoDodania.LiczbaOcen = _bazaDanych.WyswietlOceny(uczen.Id).Where(a=>a.IdPrzedmiotu == przedmiotId).ToList().Count;
                uczenDoDodania.SredniaOcen = _bazaDanych.ObliczSredniaUcznia(przedmiotId,uczen.Id);
                listaUczniow.Add(uczenDoDodania);
            }

            return listaUczniow;
        }

        public void WstawOcene(Ocena ocena)
        {
            _bazaDanych.DodajOcene(ocena);
        }
    }
}

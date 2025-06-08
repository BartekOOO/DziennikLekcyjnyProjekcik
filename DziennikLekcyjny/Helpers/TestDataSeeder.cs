using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;

namespace DziennikLekcyjny.Helpers
{
    public static class TestDataSeeder
    {
        public static void WypelnijFakeDane(
            out List<Klasa> klasy,
            out List<Przedmiot> przedmioty,
            out List<PrzedmiotKlasy> relacje,
            out List<Uczen> uczniowie,
            out List<Ocena> oceny,
            out List<Nauczyciel> nauczyciele)
        {
            klasy = new List<Klasa>
            {
                new Klasa { Id = 1, Nazwa = "1A" },
                new Klasa { Id = 2, Nazwa = "1B" },
                new Klasa { Id = 3, Nazwa = "2A" },
                new Klasa { Id = 4, Nazwa = "2B" },
            };

            przedmioty = new List<Przedmiot>
            {
                new Przedmiot { Id = 1, Nazwa = "Matematyka" },
                new Przedmiot { Id = 2, Nazwa = "Chemia" },
                new Przedmiot { Id = 3, Nazwa = "Informatyka" },
                new Przedmiot { Id = 4, Nazwa = "Programowanie" },
                new Przedmiot { Id = 5, Nazwa = "Gastronomia" },
                new Przedmiot { Id = 6, Nazwa = "Biologia" },
                new Przedmiot { Id = 7, Nazwa = "WF" },
                new Przedmiot { Id = 8, Nazwa = "Fizyka" },
                new Przedmiot { Id = 9, Nazwa = "Historia" },
                new Przedmiot { Id = 10, Nazwa = "Geografia" }
            };

            relacje = new List<PrzedmiotKlasy>
            {
                new PrzedmiotKlasy { Id = 1, IdKlasy = 1, IdPrzedmiotu = 1 },
                new PrzedmiotKlasy { Id = 2, IdKlasy = 1, IdPrzedmiotu = 3 },
                new PrzedmiotKlasy { Id = 3, IdKlasy = 1, IdPrzedmiotu = 4 },
                new PrzedmiotKlasy { Id = 4, IdKlasy = 1, IdPrzedmiotu = 7 },

                new PrzedmiotKlasy { Id = 5, IdKlasy = 2, IdPrzedmiotu = 2 },
                new PrzedmiotKlasy { Id = 6, IdKlasy = 2, IdPrzedmiotu = 3 },
                new PrzedmiotKlasy { Id = 7, IdKlasy = 2, IdPrzedmiotu = 5 },
                new PrzedmiotKlasy { Id = 8, IdKlasy = 2, IdPrzedmiotu = 7 },

                new PrzedmiotKlasy { Id = 9, IdKlasy = 3, IdPrzedmiotu = 1 },
                new PrzedmiotKlasy { Id = 10, IdKlasy = 3, IdPrzedmiotu = 6 },
                new PrzedmiotKlasy { Id = 11, IdKlasy = 3, IdPrzedmiotu = 8 },
                new PrzedmiotKlasy { Id = 12, IdKlasy = 3, IdPrzedmiotu = 9 },

                new PrzedmiotKlasy { Id = 13, IdKlasy = 4, IdPrzedmiotu = 2 },
                new PrzedmiotKlasy { Id = 14, IdKlasy = 4, IdPrzedmiotu = 4 },
                new PrzedmiotKlasy { Id = 15, IdKlasy = 4, IdPrzedmiotu = 5 },
                new PrzedmiotKlasy { Id = 16, IdKlasy = 4, IdPrzedmiotu = 10 },
            };

            nauczyciele = new List<Nauczyciel>
            {
                new Nauczyciel { Id = 1, Imie = "Adam", Nazwisko = "Kowalski", Login = "ADKOW", Haslo = "Haslo" },
                new Nauczyciel { Id = 2, Imie = "Barbara", Nazwisko = "Nowak", Login = "BANOW", Haslo = "Haslo" },
                new Nauczyciel { Id = 3, Imie = "Celina", Nazwisko = "Wiśniewska", Login = "CEWIS", Haslo = "Haslo" },
                new Nauczyciel { Id = 4, Imie = "Dariusz", Nazwisko = "Wójcik", Login = "DAWOJ", Haslo = "Haslo" },
                new Nauczyciel { Id = 5, Imie = "Ewa", Nazwisko = "Zielińska", Login = "EWZIE", Haslo = "Haslo" }
            };

            uczniowie = new List<Uczen>
            {
                new Uczen { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", IdKlasy = 1 },
                new Uczen { Id = 2, Imie = "Anna", Nazwisko = "Nowak", IdKlasy = 1 },
                new Uczen { Id = 3, Imie = "Piotr", Nazwisko = "Zieliński", IdKlasy = 1 },
                new Uczen { Id = 4, Imie = "Kasia", Nazwisko = "Wiśniewska", IdKlasy = 2 },
                new Uczen { Id = 5, Imie = "Tomek", Nazwisko = "Wójcik", IdKlasy = 2 },
                new Uczen { Id = 6, Imie = "Marta", Nazwisko = "Kaczmarek", IdKlasy = 2 },
                new Uczen { Id = 7, Imie = "Kamil", Nazwisko = "Mazur", IdKlasy = 3 },
                new Uczen { Id = 8, Imie = "Ola", Nazwisko = "Krawczyk", IdKlasy = 3 },
                new Uczen { Id = 9, Imie = "Bartek", Nazwisko = "Dąbrowski", IdKlasy = 3 },
                new Uczen { Id = 10, Imie = "Zosia", Nazwisko = "Piotrowska", IdKlasy = 4 },
                new Uczen { Id = 11, Imie = "Michał", Nazwisko = "Pawlak", IdKlasy = 4 },
                new Uczen { Id = 12, Imie = "Emilia", Nazwisko = "Michalak", IdKlasy = 4 }
            };

            oceny = new List<Ocena>();
            int ocenaId = 1;
            foreach (var uczen in uczniowie)
            {
                var przedmiotyUcznia = relacje.FindAll(r => r.IdKlasy == uczen.IdKlasy);
                for (int i = 0; i < 5; i++)
                {
                    var rel = przedmiotyUcznia[i % przedmiotyUcznia.Count];
                    int nauczycielId = (uczen.Id % nauczyciele.Count) + 1;

                    oceny.Add(new Ocena
                    {
                        Id = ocenaId++,
                        IdUcznia = uczen.Id,
                        IdPrzedmiotu = rel.IdPrzedmiotu,
                        IdNauczyciela = nauczycielId,
                        Wartosc = 3 + (i % 3),
                        Waga = 1.0f,
                        DataWstawienia = DateTime.Now.AddDays(-i * 2),
                        DataModyfikacji = DateTime.Now
                    });
                }
            }

        }
    }
}

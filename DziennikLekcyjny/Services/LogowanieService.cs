using DziennikLekcyjny.Interfaces;
using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Services
{
    public class LogowanieService : ILogowanieService
    {
        private readonly IBazaDanych _bazaDanych;

        public LogowanieService(IBazaDanych bazaDanych)
        {
            _bazaDanych = bazaDanych;
        }

        public Nauczyciel GetNauczycielInfo(int id)
        {
            return _bazaDanych.PokazNauczyciela(id);
        }

        public bool Zaloguj(string login, string haslo, ref int id)
        {
            var nauczyciel = _bazaDanych.PokazNauczyciela(login, haslo);
            if (nauczyciel == null) return false;
            id = nauczyciel.Id;
            return true;
        }
    }
}

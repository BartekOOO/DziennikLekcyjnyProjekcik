using DziennikLekcyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Interfaces
{
    public interface ILogowanieService
    {
        bool Zaloguj(string login,string haslo, ref int id);
        Nauczyciel GetNauczycielInfo(int id);
    }
}

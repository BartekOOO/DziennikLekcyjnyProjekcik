﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DziennikLekcyjny.Models
{
    public class Nauczyciel
    {
        public int Id { get; set; }
        public string Imie {  get; set; }
        public string Nazwisko { get; set; }

        public string Login { get; set; }
        public string Haslo {  get; set; }

    }
}

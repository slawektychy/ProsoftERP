using Prosoft.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosoft.Modules.Kartoteki
{
    public class PracownicyTable : BaseTable<PracownikRow>
    {
        public override string TableName => "Pracownicy";
        public override string ModuleName => "Kartoteki";

        public PracownicyTable()
        {
            //Console.WriteLine("Inicjalizacja tabeli Kontrahenci");
        }
    }

    public class PracownikRow : BaseRow
    {
        public string Nazwisko { get; set; }
        public string Imie { get; set; }

        public PracownikRow(int Id, string Nazwisko, string Imie)
        {
            ID = Id;
            Nazwisko = Nazwisko;
            Imie = Imie;
        }
    }
}

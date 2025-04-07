using Prosoft.Core;
using Prosoft.Core.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosoft.Modules.Kartoteki
{
    [MenuRegistration("Kartoteki/Pracownicy", typeof(KontrahenciTable))]
    public class PracownicyTable : BaseTable<PracownikRow>
    {
        public override string TableName => "Pracownicy";
        public override string GetTableName() { return TableName; }
        public override string GetModuleName() { return "Kartoteki"; }

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

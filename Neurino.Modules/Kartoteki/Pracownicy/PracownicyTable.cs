using Neurino.Core.Atributes;
using Neurino.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Modules.Kartoteki
{
    [MenuRegistration("Kartoteki/Pracownicy", typeof(PracownicyTable))]
    public class PracownicyTable : BaseTable<KontrahentRow>
    {
        public override string TableName => "Pracownicy";
        public override string GetTableName() { return TableName; }
        public override string GetModuleName() { return "Kartoteki"; }

        public PracownicyTable()
        {
            //Console.WriteLine("Inicjalizacja tabeli Kontrahenci");
        }

    }
}

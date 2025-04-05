using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prosoft.Core;

namespace Prosoft.Modules.Kartoteki
{
    [MenuRegistration("Kartoteki/Kontrahenci")]
    public class KontrahenciTable : BaseTable<KontrahentRow>
    {
        public override string TableName => "Kontrahenci";
        public override string GetTableName() { return TableName; }
        public override string GetModuleName() { return "Kartoteki"; }

        public KontrahenciTable()
        {
            //Console.WriteLine("Inicjalizacja tabeli Kontrahenci");
        }

    }
}

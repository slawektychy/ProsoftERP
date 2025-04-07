using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurino.Core;
using Neurino.Core.Atributes;

namespace Neurino.Modules.Kartoteki
{
    [MenuRegistration("Kartoteki/Kontrahenci", typeof(KontrahenciTable))]
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

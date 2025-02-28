using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prosoft.Core;

namespace Prosoft.Modules.Kartoteki.Kontrahenci
{
    public class KontrahenciTable : BaseTable<KontrahentRow>
    {
        public override string ModuleName => "Kartoteki";

        public KontrahenciTable()
        {
            Console.WriteLine("Inicjalizacja tabeli Kontrahenci");
        }
    }
}

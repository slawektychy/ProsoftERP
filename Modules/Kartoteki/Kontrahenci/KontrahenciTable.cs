using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Kartoteki.Kontrahenci
{
    public class KontrahenciTable : BaseTable<KontrahentRow>
    {
        public KontrahenciTable()
        {
            Console.WriteLine("Inicjalizacja tabeli Kontrahenci");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Kartoteki.Kontrahenci
{
    public class KontrahentRow : BaseRow
    {
        public string Kod { get; set; }
        public string Nazwa { get; set; }

        public KontrahentRow(int id, string kod, string nazwa)
        {
            ID = id;
            Kod = kod;
            Nazwa = nazwa;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurino.Core;

namespace Neurino.Modules.Kartoteki
{
    public class KontrahentRow : BaseRow
    {
        public string Kod { get; set; }
        public string Nazwa { get; set; }

        public KontrahentRow(int Id, string Kod, string Nazwa)
        {
            ID = Id;
            Kod = Kod;
            Nazwa = Nazwa;
        }
    }
}

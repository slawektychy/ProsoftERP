using Modules.Kartoteki.Kontrahenci;
using ProsoftERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Kartoteki
{
    public class KartotekiModule : IModule
    {
        public string Name => "Kartoteki";

        public void Initialize()
        {
            Console.WriteLine("Moduł kartotek został załadowany!");
        }


        private static List<object> registeredTables = new List<object>();

        public void Register()
        {
            Console.WriteLine("Rejestracja modułu Kartoteki");
            RegisterTable(new KontrahenciTable());
        }

        private static void RegisterTable<T>(T table) where T : class
        {
            registeredTables.Add(table);
            Console.WriteLine($"Zarejestrowano tabelę {typeof(T).Name}");
        }
    }



   

   
}

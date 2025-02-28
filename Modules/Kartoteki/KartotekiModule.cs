using Prosoft.Modules.Kartoteki.Kontrahenci;
using Prosoft.Core;
using System.Reflection;

namespace Prosoft.Modules.Kartoteki
{
    public class KartotekiModule : IModule
    {
        public string Name => "Kartoteki";
        public Assembly Assembly => Assembly.GetExecutingAssembly();
        
        public void Initialize()
        {
            Console.WriteLine("Moduł kartotek został załadowany!");
        }


        private static List<object> registeredTables = new List<object>();

        public void Register()
        {
            Console.WriteLine("Rejestracja modułu Kartoteki");
            RegisterTables();
        }

        public void RegisterTables()
        {
            var tableTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(BaseTable<>));

            foreach (var type in tableTypes)
            {
                var instance = Activator.CreateInstance(type) as dynamic;
                if (instance != null)
                {
                    if (instance.ModuleName == "Kartoteki")
                    {
                        registeredTables.Add(instance);
                        Console.WriteLine($"Zarejestrowano tabelę {type.Name} w module Kartoteki");
                    }
                }
            }
        }
    }



   

   
}

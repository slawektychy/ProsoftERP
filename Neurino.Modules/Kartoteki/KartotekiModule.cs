using Neurino.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Modules.Kartoteki
{
    public class KartotekiModule : IModule
    {
        public string Name => "Kartoteki";
        public string Title => "Kartoteki systemowe";
        public string Description => "Moduł systemowy zawierający definicje obiektów kartotekowych";
        public Int16 Priority => 1;
        public Assembly Assembly => Assembly.GetExecutingAssembly();

        public void Initialize()
        {
            //Console.WriteLine("Moduł kartotek został załadowany!");
        }

        private static List<object> _tableObjects = new List<object>();
        private static List<object> _rowObjects = new List<object>();

        public List<object> TableObjects { get { return _tableObjects; } }
        public List<object> RowObjects => new List<object>();


        public void Register()
        {
            //Console.WriteLine("Rejestracja modułu Kartoteki");
            RegisterTables();
            RegisterRows();
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
                    if (instance.GetModuleName() == Name)
                    {
                        _tableObjects.Add(instance);
                        //Console.WriteLine($"Zarejestrowano tabelę {type.Name} w module Kartoteki");
                    }
                }
            }
        }

        public void RegisterRows()
        {
            //throw new NotImplementedException();
        }
    }
}

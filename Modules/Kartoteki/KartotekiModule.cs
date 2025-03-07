using Prosoft.Modules.Kartoteki;
using Prosoft.Core;
using System.Reflection;

namespace Prosoft.Modules.Kartoteki
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
                    if (instance.ModuleName == Name)
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




    //public abstract class BaseModule : IModule
    //{
    //    public abstract string Name { get; }
    //    public abstract string Title { get; }
    //    public abstract string Description { get; }
    //    public abstract Int16 Priority { get; }
    //    public virtual Assembly Assembly => Assembly.GetExecutingAssembly(); // Można nadpisać dla modułów w innych assembly

    //    private readonly List<object> _tableObjects = new();
    //    private readonly List<object> _rowObjects = new();

    //    public List<object> TableObjects => _tableObjects;
    //    public List<object> RowObjects => _rowObjects;

    //    public virtual void Initialize()
    //    {
    //        // Domyślna implementacja - można nadpisać
    //    }

    //    public void Register()
    //    {
    //        RegisterTables();
    //        RegisterRows();
    //    }

    //    protected virtual void RegisterTables()
    //    {
    //        var tableTypes = Assembly.GetTypes()
    //            .Where(t => t.BaseType is { IsGenericType: true } &&
    //                        t.BaseType.GetGenericTypeDefinition() == typeof(BaseTable<>));

    //        foreach (var type in tableTypes)
    //        {
    //            if (Activator.CreateInstance(type) is not dynamic instance) continue;

    //            if (instance.ModuleName == Name) // Sprawdzamy, czy tabela należy do tego modułu
    //            {
    //                _tableObjects.Add(instance);
    //                Console.WriteLine($"Zarejestrowano tabelę {type.Name} w module {Name}");
    //            }
    //        }
    //    }

    //    protected virtual void RegisterRows()
    //    {
    //        // Implementacja rejestracji wierszy (jeśli potrzeba)
    //    }
    //}


}

using Prosoft.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prosoft.Core
{
    public class ApplicationContext
    {

        /// <summary>
        /// Zwraca listę zarejestrowanych modułów
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IModule> GetLoadedModules()
        {
            //return _modules.Select(m => m.GetType().Name);
            return _modules;
        }
        //public IEnumerable<IModule> GetModules() => _modules;



        private static readonly Lazy<ApplicationContext> _instance =
            new Lazy<ApplicationContext>(() => new ApplicationContext());

        public static ApplicationContext Instance => _instance.Value;

        private readonly List<IModule> _modules = new List<IModule>();
        private readonly Dictionary<Type, object> _tables = new Dictionary<Type, object>();

        private ApplicationContext() { }

        public void RegisterModule(IModule module)
        {
            _modules.Add(module);
            module.Register();
        }

        public void RegisterTable<T>(T table)
        {
            _tables[typeof(T)] = table;
        }

        public T GetTable<T>() where T : class
        {
            return _tables.TryGetValue(typeof(T), out var table) ? table as T : null;
        }

    }
}

using Prosoft.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            return _modules;
        }

        /// <summary>
        /// Zwraca listę zarejestrowanych pozycji menu
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> GetMenuItems()
        {
            return _menuItems;
        }


        private static readonly Lazy<ApplicationContext> _instance = new Lazy<ApplicationContext>(() => new ApplicationContext());
        public static ApplicationContext Instance => _instance.Value;

        private readonly List<IModule> _modules = new List<IModule>();
        private readonly List<Type> _menuItems = new List<Type>();

        private readonly Dictionary<Type, object> _tables = new Dictionary<Type, object>();

        private ApplicationContext() { }

        public void RegisterModule(IModule module)
        {
            _modules.Add(module);
            module.Register();
        }

        public void RegisterMenuAtributClasses(List<Type> classess)
        {
            _menuItems.AddRange(classess);
        }
       

    }
}

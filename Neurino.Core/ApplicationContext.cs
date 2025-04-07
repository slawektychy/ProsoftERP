using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Core
{
    public class ApplicationContext
    {
        private static readonly Lazy<ApplicationContext> _instance = new Lazy<ApplicationContext>(() => new ApplicationContext());
        public static ApplicationContext Instance => _instance.Value;

        private readonly List<IModule> _modules = new List<IModule>();
        private readonly List<Type> _menuItems = new List<Type>();

        public ApplicationContext() { }

        #region Testy

        public string LoggedUser { get; set; } = "anonim";
        public string GetLoggedUserName() => LoggedUser;

        #endregion


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

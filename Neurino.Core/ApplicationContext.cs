using Neurino.Core.Models;
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

        public event Action? MenuChanged;

        private readonly List<IModule> _modules = new List<IModule>();
        private List<Type> _menuItems = new List<Type>();
        public bool ModuleLoaded = false;

        public ApplicationContext() { }

        #region Testy

        public string LoggedUser { get; set; } = "Sławomir, Dobroś";
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
        public IEnumerable<Type> GetMenuItems() => _menuItems;


        public void RegisterModule(IModule module)
        {
            _modules.Add(module);
            module.Register();
        }

        public void RegisterMenuAtributClasses(List<Type> classess)
        {
           _menuItems.AddRange(classess);
            MenuChanged?.Invoke();
        }


    }


}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProsoftERP
{
    public interface IModule
    {
        string Name { get; }
        void Initialize();
    }

    public class ModuleLoader
    {
        private readonly List<IModule> _modules = new List<IModule>();

        public List<IModule> Modules
        {
            get { return _modules; } 
        }


        public void LoadModules(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(file);
                    var types = assembly.GetTypes().Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface);
                    foreach (var type in types)
                    {
                        if (Activator.CreateInstance(type) is IModule module)
                        {
                            module.Initialize();
                            _modules.Add(module);
                            Console.WriteLine($"Loaded module: {module.Name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading module from {file}: {ex.Message}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prosoft ERP System");
            ModuleLoader loader = new ModuleLoader();
            loader.LoadModules("./Modules");
            Console.WriteLine("All modules loaded.");
        }
    }
}

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace Neurino.Core
{

    public class ModuleWebLoader
    {
        public async Task<List<IModule>> LoadModules(HttpClient http)
        {
            var modules = new List<IModule>();

            var moduleUrls = new[]
            {
                    "modules/Neurino.Modules.dll"
            };

            try
            {

                foreach (var url in moduleUrls)
            {

                var c = url;
                var bytes = await http.GetByteArrayAsync(url);
                var asm = Assembly.Load(bytes);

                foreach (var type in asm.GetTypes())
                {
                    if (typeof(IModule).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        var module = (IModule)Activator.CreateInstance(type)!;
                        module.Initialize();
                        modules.Add(module);
                    }
                }
            }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Błąd ładowania modułów DLL: {ex.Message}");
            }

            return modules;
        }
    }


   
            


    public class ModuleLoader
    {

        private readonly List<IModule> _modules = new List<IModule>();

        public List<IModule> Modules
        {
            get { return _modules; }
        }

        public void LoadModules()
        {
            var path = string.Empty;

            path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? "", "Modules");

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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prosoft.Core
{
    public interface IModule
    {
        string Name { get; }
        Assembly Assembly { get; }

        void Register();
        void RegisterTables();
        void Initialize();
    }
}

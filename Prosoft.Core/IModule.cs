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
        string Title { get; }
        string Description { get; }
        Int16 Priority { get; }
        Assembly Assembly { get; }

        List<object> TableObjects { get; }
        List<object> RowObjects { get; }

        void Initialize();

        void Register();
        void RegisterTables();
        void RegisterRows();




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Core.Atributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MenuRegistrationAttribute : Attribute
    {
        public string MenuPath { get; }
        public Type TargetType { get; }

        public MenuRegistrationAttribute(string menuPath, Type targetType)
        {
            MenuPath = menuPath;
            TargetType = targetType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Core.UI
{
    public static class AppIconMap
    {
        public static string? GetCssClass(AppIcon icon) => icon switch
        {
            AppIcon.Home => "bi bi-house",
            AppIcon.Users => "bi bi-people",
            AppIcon.Inventory => "bi bi-box-seam",
            AppIcon.Import => "bi bi-box-arrow-in-down",
            AppIcon.Export => "bi bi-box-arrow-up",
            AppIcon.Settings => "bi bi-gear",
            AppIcon.Folder => "bi bi-folder",
            AppIcon.Modules => "bi bi-puzzle",
            _ => null
        };

        public static string? GetSvgPath(AppIcon icon) => icon switch
        {
            // Przykład – tylko jeśli chcesz zastąpić niektóre ikony niestandardowymi SVG
            AppIcon.Modules => "icons/modules.svg",
            _ => null
        };
    }
}

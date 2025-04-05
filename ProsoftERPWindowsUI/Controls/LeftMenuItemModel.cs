using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosoft.WindowsUI.Controls
{
    public class LeftMenuItemModel
    {
        public string Header { get; set; }
        public List<LeftMenuItemModel> Children { get; set; }

        public LeftMenuItemModel()
        {
            Children = new List<LeftMenuItemModel>();
        }
    }
}

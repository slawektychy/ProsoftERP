using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prosoft.WindowsUI
{
    public class TabItemModel
    {
        public string Title { get; set; }
        public UserControl Content { get; set; }

        public TabItemModel(string title, UserControl content)
        {
            Title = title;
            Content = content;
        }
    }

}

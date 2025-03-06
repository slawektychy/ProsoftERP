using System.Windows;
using System.Windows.Controls;

namespace Prosoft.WindowsUI.UIControls
{
    public class UILabel : Label
    {
        static UILabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UILabel),
                new FrameworkPropertyMetadata(typeof(UILabel)));
        }
    }
}
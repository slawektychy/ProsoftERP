using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurino.Core.Models
{
    public class MenuGroup
    {
        public string? Title { get; set; }
        public List<MenuItem> Items { get; set; } = new();
    }
}

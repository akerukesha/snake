using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Models
{   [Serializable]
    class Wall:Drawer
    {
        public int MyProperty { get; set; }
        public Wall()
        {
            sign = '#';
        }
    }
}

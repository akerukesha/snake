﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Models
{   [Serializable]
    class Food:Drawer
    {
        public Food()
        {
            sign = '$';
        }
    }
}

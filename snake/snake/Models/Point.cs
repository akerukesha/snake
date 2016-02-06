using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Models
{   [Serializable]
    class Point
    {   
        /// <summary>
        /// каждая точка будет иметь х и у координату
        /// также создается конструктор для класса
        /// </summary>
        public int x;
        public int y;
        public Point()
        {

        }
    }
}

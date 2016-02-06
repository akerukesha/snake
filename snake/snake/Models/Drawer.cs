using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace snake.Models
{   [Serializable]
    class Drawer
    {   
        /// <summary>
        /// создаются методы для постановки символов, сериализации и десериализации файлов через BinaryFormatter
        /// </summary>
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;
        public Drawer()
        {
            color = ConsoleColor.Blue;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Save()
        {
            /*Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.xml", t.Name), FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(t);
            xs.Serialize(fs, this);
            fs.Close();*/
            Type t = GetType();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(string.Format("{0}.dat", t.Name), FileMode.Create, FileAccess.Write);
            formatter.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            /*Type t = GetType();
            FileStream fs = new FileStream(string.Format("{0}.xml", t.Name), FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(t);
            if (t == typeof(Wall)) Game.wall = xs.Deserialize(fs) as Wall;
            if (t == typeof(Snake)) Game.snake = xs.Deserialize(fs) as Snake;
            if (t == typeof(Food)) Game.food = xs.Deserialize(fs) as Food;
            fs.Close();*/
            Type t = GetType();
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(string.Format(@"C:\snake\snake\snake\bin\Debug\{0}.dat", t.Name), FileMode.Open, FileAccess.Read);
            if (t == typeof(Wall)) Game.wall = formatter.Deserialize(fs) as Wall;
            if (t == typeof(Snake)) Game.snake = formatter.Deserialize(fs) as Snake;
            if (t == typeof(Food)) Game.food = formatter.Deserialize(fs) as Food;
            fs.Close();
        }
    }
}

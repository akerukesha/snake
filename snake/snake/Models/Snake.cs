using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake.Models
{   [Serializable]
    class Snake:Drawer
    {
        /// <summary>
        /// создается метод для перемещения змейки
        /// в него передаются значения перемещения первой точки змейки, затем прописываются действия для отдельных случаев
        /// создается доп. метод для генерирования еды в рандомном безопасном месте при съедении предыдущей
        /// </summary>
        public Snake()
        {
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            //за пределы рамки - с другой стороны
            if (body[0].x < 0)
            {
                body[0].x = 47;
            }
            else if (body[0].x > 47)
            {
                body[0].x = 0;
            }
            if (body[0].y < 0)
            {
                body[0].y = 47;
            }
            else if (body[0].y > 47)
            {
                body[0].y = 0;
            }
            //за пределы рамки - game over
            /*if (Game.snake.body[0].x == 0 || Game.snake.body[0].x == 47 || Game.snake.body[0].y == 0 || Game.snake.body[0].y == 47)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Game over!");
                Game.isActive = false;
                Program.level = 1;
                Program.gainedPoints = 0;
            }*/

            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            {
                Program.gainedPoints++;
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });

                if (Program.gainedPoints % 5 == 0 && Program.gainedPoints != 0)
                {
                    Program.level++;
                    Console.Clear();
                    Game.isActive = false;
                }
                /*Game.food.body[0].x = new Random().Next(0, 47);
                Game.food.body[0].y = new Random().Next(0, 47);*/
                RandomFood();
            }

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game over!");
                    Game.isActive = false;
                    Program.level = 1;
                    Program.gainedPoints = 0;
                    Program.second = 0;
                    Program.minute = 0;
                }
            }
        }
        public void RandomFood()
        {
            Game.food.body[0].x = new Random().Next(0, 47);
            Game.food.body[0].y = new Random().Next(0, 47);

            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.wall.body[i].x && Game.food.body[0].y == Game.wall.body[i].y)
                {
                    RandomFood();
                }
                else
                {
                    continue;
                }
            }

            for (int i = 0; i < Game.snake.body.Count; ++i)
            {
                if (Game.food.body[0].x == Game.snake.body[i].x && Game.food.body[0].y == Game.snake.body[i].y)
                {
                    RandomFood();
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

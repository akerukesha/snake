using snake.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        /// <summary>
        /// создаются 2 счетчика: для левела и набранных очков
        /// левелы прогружаются, пока не достигнут конца
        /// когда кончаются левелы, выходит сообщение о выигрыше
        /// </summary>
        public static int level = 1;
        public static int gainedPoints = 0;
        //public static Thread forKey = new Thread(new ParameterizedThreadStart(key));
        public static Thread forMove;// = new Thread(new ParameterizedThreadStart(move));
        public static Thread forTimer;// = new Thread(new ParameterizedThreadStart(timer));
        public static int second = 0, minute = 0;
        public static string dir;

        static void Main(string[] args)
        {
            //Console.SetCursorPosition(3, 51);
            //Console.WriteLine("Level" + level);
            ChangeLevel();
            //Console.ReadKey();
            
            //вот это в какое-то другое место
            /*Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Conratulations! You won!");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("Your score is " + gainedPoints);
            Game.isActive = false;*/
        }

        public static void timer(object obj)
        {
            while (Game.isActive)
            {
                second++;
                if (second == 60)
                {
                    minute++;
                    second = 0;
                }
                Thread.Sleep(1000);
            }
        }

        public static void move(object obj)
        {
            while (Game.isActive)
            {
                Game.snake.Erase();
                switch (dir)
                {
                    case "up":
                        Game.snake.Move(0, -1);
                        break;
                    case "down":
                        Game.snake.Move(0, 1);
                        break;
                    case "left":
                        Game.snake.Move(-1, 0);
                        break;
                    case "right":
                        Game.snake.Move(1, 0);
                        break;
                }
                Game.Draw();
                Thread.Sleep(100);
            }
        }
        public static void ChangeLevel()
        {
            Game.Init();
            Game.LoadlLevel(level);
            Game.RandomSnake();
            forMove = new Thread(new ParameterizedThreadStart(move));
            forTimer = new Thread(new ParameterizedThreadStart(timer));
            forMove.Start();
            forTimer.Start();
            while (Game.isActive)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        dir = "up";
                        break;
                    case ConsoleKey.DownArrow:
                        dir = "down";
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = "left";
                        break;
                    case ConsoleKey.RightArrow:
                        dir = "right";
                        break;
                    case ConsoleKey.Escape:
                        Game.isActive = false;
                        break;
                    case ConsoleKey.Q:
                        Game.Save();
                        break;
                    case ConsoleKey.W:
                        Game.Resume();
                        break;
                }
            }
            //if (level == )
            forMove.Abort();
            forTimer.Abort();
            ChangeLevel();
        }
    }
}

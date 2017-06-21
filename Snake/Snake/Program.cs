using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            Walls walls = new Walls(80, 25); //создаем и рисуем стенки
            walls.Draw();

            //рамка
            HorizontalLine lineH1 = new HorizontalLine(0 ,78 ,0 ,'+');
            HorizontalLine lineH2 = new HorizontalLine(0, 78, 24, '+');
            VerticalLine lineU1 = new VerticalLine(0, 24, 0, '+');
            VerticalLine lineU2 = new VerticalLine(0, 24, 78, '+');
            lineH1.Draw();
            lineH2.Draw();
            lineU1.Draw();
            lineU2.Draw();

            //рисуем точки-змейки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$'); //обозначаем, где появляется еда
            Point food = foodCreator.CreateFood(); //создаем точку с едой
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail()) //проверка столкновения со стеной или хвостом
                {
                    break;
                }

                if (snake.Eat(food)) //проверка поедания
                {
                    food = foodCreator.CreateFood();
                    food.Draw(); 
                }
                else //если не едим то двигаемся
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}

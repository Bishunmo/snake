using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, this.direction);
                pList.Add(p);
            }
        }

        internal void Move() // передвижение
        {
            Point tail = pList.First();
            pList.Remove(tail); //убираем хвост
            Point head = GetNextPoint();
            pList.Add(head); //добавляем бошку
            
            tail.Clear(); //удаление хранимого хвоста
            head.Draw(); //добавляем голову со сдвигом
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last(); //текущая позиция головы
            Point nextPoint = new Point(head); //новая точка, копия головы
            nextPoint.Move(1, direction); // сдвиг в направлении
            return nextPoint;
        }

        internal bool IsHitTail() //проверка хвоста
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                head.Draw();
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else return false;
        }
    }
}

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
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            head.Draw(); //добавляем голову со сдвигом
            tail.Clear(); //удаление хвоста
            
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last(); //текущая позиция головы
            Point nextPoint = new Point(head); //новая точка, копия головы
            nextPoint.Move(1, direction); // сдвиг в направлении
            return nextPoint;
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
    }
}

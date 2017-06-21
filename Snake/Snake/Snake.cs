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

        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();

            for (int i = 0; i<length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move() // передвижение
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear(); //удаление хвоста
            head.Draw(); //добавляем голову со сдвигом
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last(); //текущая позиция головы
            Point nextPoint = new Point(head); //новая точка, копия головы
            nextPoint.Move(1, direction); // сдвиг в направлении
            return nextPoint;
        }
    }
}

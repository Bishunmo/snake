﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1,3,'*');
            p1.Draw();

            Point p2 = new Point(4,6,'#');
            p2.Draw();


            HorizontalLine line = new HorizontalLine(5,10,8,'_');
            line.Draw();




            Console.ReadLine();


            // LISTS
            /*List<int> numList = new List<int>();

            numList.Add(0);
            numList.Add(1);
            numList.Add(2);

            int x = numList[0];
            int y = numList[1];
            int z = numList[2];

            foreach(int i in numList)
            {
                Console.WriteLine(i);
            }
            //numList.RemoveAt(0);

            List<Point> pList = new List<Point>();
            pList.Add(p1);
            pList.Add(p2);*/

            /*Draw(p2.x, p2.y, p2.sym);

            int x2 = 4;
            int y2 = 6;
            char sym2 = '#';

            Draw(x2, y2, sym2);*/

        }

    }
}

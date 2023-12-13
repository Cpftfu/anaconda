using System;
using System.Threading;

namespace anaconda
{
    internal class Igrushka
    {
        //это наш отдельный ЕНУМчик
        enum Num : int
        {
            widht = 40, hight = 20
        }

        int[] X = new int[50];
        int[] Y = new int[50];

        //тут координаты для яблочек на карте
        int appleX;
        int appleY;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random randd = new Random();

        //это типа изначальная длина нашей АНАКОНДЫ
        int parts = 5;

        Igrushka()
        {
            //это координаты откуда берет свое начало наша анаконда
            X[0] = 10;
            Y[0] = 10;

            Console.CursorVisible = false;
            appleX = randd.Next(2, ((int)Num.widht - 2));
            appleY = randd.Next(2, ((int)Num.hight - 2));
        }

        public void WriteShit1()
        {
            Console.Clear();

            for (int v = 1; v <= ((int)Num.widht + 2); v++)
            {
                Console.SetCursorPosition(v, 1);
                Console.Write("=");
            }
            for (int v = 1; v <= ((int)Num.widht + 2); v++)
            {
                Console.SetCursorPosition(v, ((int)Num.hight + 2));
                Console.Write("=");
            }
            for (int v = 1; v <= ((int)Num.hight + 1); v++)
            {
                Console.SetCursorPosition(1, v);
                Console.Write("|");
            }
            for (int v = 1; v <= ((int)Num.hight + 1); v++)
            {
                Console.SetCursorPosition(((int)Num.widht + 2), v);
                Console.Write("|");
            }
        }

        public void LogicShit()
        {
            if (X[0] == appleX)
            {
                if (Y[0] == appleY)
                {
                    parts = parts +1;
                    appleX = randd.Next(2, (int)Num.widht - 2);
                    appleY = randd.Next(2, (int)Num.hight - 2);
                }
            }

            for (int v = parts; v > 1; v--)
            {
                X[v - 1] = X[v - 2];
                Y[v - 1] = Y[v - 2];
            }

            switch (key)
            {
                case 'w':
                    Y[0]--;
                    break;

                case 's':
                    Y[0]++;
                    break;

                case 'd':
                    X[0]++;
                    break;

                case 'a':
                    X[0]--;
                    break;
            }

            for (int v = 0; v <= (parts - 1); v++)
            {
                WritePoint(X[v], Y[v]);
                WritePoint(appleX, appleY);
            }
            Thread.Sleep(170);
        }

        public void InputShit()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        public void WritePoint(int x, int y)
        {
            //Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("░");
        }
        
        static void Main()
        {
            Igrushka govno = new Igrushka();
            while (true)
            {
                govno.WriteShit1();
                govno.InputShit();
                govno.LogicShit();
            }
        }
    }
}//видосы индусов на ютубе реально ✨make sense✨
//хотя у русских тоже есть годные видосики
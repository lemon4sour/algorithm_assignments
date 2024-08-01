using System;

namespace DEUgame
{
    class Program
    {
        static void Main()
        {
            var defaultforeground = ConsoleColor.White;
            var defaultbackground = ConsoleColor.DarkGray;
            Console.BackgroundColor = defaultbackground;
            Console.Clear();
            Console.ForegroundColor = defaultforeground;


            byte step = 255;
            //setup array

            //extra two spaces to prevent OutOfRange error (playfield is still 15x3)
            char[] array1 = new char[17];
            char[] array2 = new char[17];
            char[] array3 = new char[17];
            Array.Fill<char>(array1, ' ');
            Array.Fill<char>(array2, ' ');
            Array.Fill<char>(array3, ' ');
            byte p1 = 120;
            byte p2 = 120;

            string[] names = {"Derya", "Elife", "Fatih", "Ali", "Azra", "Sibel", "Cem", "Nazan", "Mehmet", "Nil", "Can", "Tarkan",null};
            byte[] scores = { 100, 100, 95, 90, 85, 80, 80, 70, 55, 50, 30, 30 , 0};
            byte namecount = 11;


            static void WriteLetter(char[] array,byte posx)
            {
                switch (array[posx])
                {
                    case 'D':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'E':
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 'U':
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                }
                Console.Write(array[posx]);
            }

            Console.WriteLine("*****************");

            //FALSE = PLAYER1
            //TRUE = PLAYER2
            bool playerturn = false;

            bool match = false;

            while (true)
            {
                if (step != 44)
                {
                    step += 1;
                    if (playerturn)
                    {
                        p2 -= 5;
                        playerturn = false;
                    }
                    else
                    {
                        p1 -= 5;
                        playerturn = true;
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, 6 + (step * 5));
                    Console.WriteLine("TIE - No Winners");
                    break;
                }

                //random letter
                char letter = '?';
                byte rand = (byte)new Random().Next(3);
                switch (rand)
                {
                    case 0:
                        letter = 'D';
                        break;
                    case 1:
                        letter = 'E';
                        break;
                    case 2:
                        letter = 'U';
                        break;
                }


                byte posx = 1, posy = 1;

                bool placed = false;
                while (!placed)
                {
                    //random pos
                    posx = (byte)new Random().Next(1,16);
                    posy = (byte)new Random().Next(3);

                    //place attempt
                    switch (posy)
                    {
                        case 0:
                            if (array1[posx] == ' ')
                            {
                                array1[posx] = letter;
                                placed = true;
                            }
                            break;
                        case 1:
                            if (array2[posx] == ' ')
                            {
                                array2[posx] = letter;
                                placed = true;
                            }
                            break;
                        case 2:
                            if (array3[posx] == ' ')
                            {
                                array3[posx] = letter;
                                placed = true;
                            }
                            break;
                    }
                }

                //write table
                System.Threading.Thread.Sleep(300);
                Console.SetCursorPosition(0, 1 + (step * 5));
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("P1=");
                Console.Write(p1);
                Console.SetCursorPosition(10, 1 + (step * 5));
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("P2=");
                Console.Write(p2);
                Console.SetCursorPosition(16, 1 + (step * 5));
                Console.ForegroundColor = defaultforeground;
                Console.Write("* STEP = ");
                Console.WriteLine(step + 1);
                Console.Write('*');
                for (byte i = 1; i < 16; i++) WriteLetter(array1, i);
                Console.ForegroundColor = defaultforeground;
                Console.SetCursorPosition(16, 2 + (step * 5));
                Console.WriteLine('*');
                Console.Write('*');
                for (byte i = 1; i < 16; i++) WriteLetter(array2, i);
                Console.ForegroundColor = defaultforeground;
                Console.SetCursorPosition(16, 3 + (step * 5));
                Console.WriteLine('*');
                Console.Write('*');
                for (byte i = 1; i < 16; i++) WriteLetter(array3, i);
                Console.ForegroundColor = defaultforeground;
                Console.SetCursorPosition(16, 4 + (step * 5));
                Console.WriteLine('*');
                Console.WriteLine("*****************");

                Console.SetCursorPosition(posx, 2 + posy + (step * 5));
                Console.ForegroundColor = defaultbackground;
                switch (letter)
                {
                    case 'D':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case 'E':
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 'U':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                }
                Console.WriteLine(letter);
                Console.ForegroundColor = defaultforeground;
                Console.BackgroundColor = defaultbackground;

                //check win E
                if (letter == 'E')
                {
                    //horizontal check E
                    switch (posy)
                    {
                        case 0:
                            if (array1[posx - 1] == 'D' && array1[posx + 1] == 'U')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(posx - 1, 2 + (step * 5));
                                Console.Write("DEU");
                                match = true;
                                Console.BackgroundColor = defaultbackground;
                                Console.ForegroundColor = defaultforeground;
                            }
                            else if (array1[posx - 1] == 'U' && array1[posx + 1] == 'D')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(posx - 1, 2 + (step * 5));
                                Console.Write("UED");
                                match = true;
                                Console.BackgroundColor = defaultbackground;
                                Console.ForegroundColor = defaultforeground;
                            }
                            break;
                        case 1:
                            if (array2[posx - 1] == 'D' && array2[posx + 1] == 'U')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(posx - 1, 3 + (step * 5));
                                Console.Write("DEU");
                                match = true;
                                Console.BackgroundColor = defaultbackground;
                                Console.ForegroundColor = defaultforeground;
                            }
                            else if (array2[posx - 1] == 'U' && array2[posx + 1] == 'D')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(posx - 1, 3 + (step * 5));
                                Console.Write("UED");
                                match = true;
                                Console.BackgroundColor = defaultbackground;
                                Console.ForegroundColor = defaultforeground;
                            }
                            break;
                        case 2:
                            if (array3[posx - 1] == 'D' && array3[posx + 1] == 'U')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(posx - 1, 4 + (step * 5));
                                Console.Write("DEU");
                                match = true;
                                Console.BackgroundColor = defaultbackground;
                                Console.ForegroundColor = defaultforeground;
                            }
                            else if (array3[posx - 1] == 'U' && array3[posx + 1] == 'D')
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(posx - 1, 4 + (step * 5));
                                Console.Write("UED");
                                match = true;
                                Console.BackgroundColor = defaultbackground;
                                Console.ForegroundColor = defaultforeground;
                            }
                            break;
                    }

                    
                    if (posy == 1)
                    {
                        //vertical check E
                        if (array1[posx] == 'D' && array3[posx] == 'U') 
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(posx, 2 + (step * 5));
                            Console.Write('D');
                            Console.SetCursorPosition(posx, 3 + (step * 5));
                            Console.Write('E');
                            Console.SetCursorPosition(posx, 4 + (step * 5));
                            Console.Write('U');
                            match = true;
                            Console.BackgroundColor = defaultbackground;
                            Console.ForegroundColor = defaultforeground;
                        }
                        if (array1[posx] == 'U' && array3[posx] == 'D')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(posx, 2 + (step * 5));
                            Console.Write('U');
                            Console.SetCursorPosition(posx, 3 + (step * 5));
                            Console.Write('E');
                            Console.SetCursorPosition(posx, 4 + (step * 5));
                            Console.Write('D');
                            match = true;
                            Console.BackgroundColor = defaultbackground;
                            Console.ForegroundColor = defaultforeground;
                        }

                        //diagonal check E
                        //    \ E
                        if (array1[posx - 1] == 'D' && array3[posx + 1] == 'U')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(posx - 1, 2 + (step * 5));
                            Console.Write('D');
                            Console.SetCursorPosition(posx, 3 + (step * 5));
                            Console.Write('E');
                            Console.SetCursorPosition(posx + 1, 4 + (step * 5));
                            Console.Write('U');
                            match = true;
                            Console.BackgroundColor = defaultbackground;
                            Console.ForegroundColor = defaultforeground;
                        }
                        if (array1[posx - 1] == 'U' && array3[posx + 1] == 'D')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(posx - 1, 2 + (step * 5));
                            Console.Write('U');
                            Console.SetCursorPosition(posx, 3 + (step * 5));
                            Console.Write('E');
                            Console.SetCursorPosition(posx + 1, 4 + (step * 5));
                            Console.Write('D');
                            match = true;
                            Console.BackgroundColor = defaultbackground;
                            Console.ForegroundColor = defaultforeground;
                        }

                        //    / E
                        if (array1[posx + 1] == 'D' && array3[posx - 1] == 'U')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(posx + 1, 2 + (step * 5));
                            Console.Write('D');
                            Console.SetCursorPosition(posx, 3 + (step * 5));
                            Console.Write('E');
                            Console.SetCursorPosition(posx - 1, 4 + (step * 5));
                            Console.Write('U');
                            match = true;
                            Console.BackgroundColor = defaultbackground;
                            Console.ForegroundColor = defaultforeground;
                        }
                        if (array1[posx + 1] == 'U' && array3[posx - 1] == 'D')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(posx + 1, 2 + (step * 5));
                            Console.Write('U');
                            Console.SetCursorPosition(posx, 3 + (step * 5));
                            Console.Write('E');
                            Console.SetCursorPosition(posx - 1, 4 + (step * 5));
                            Console.Write('D');
                            Console.BackgroundColor = defaultbackground;
                            Console.ForegroundColor = defaultforeground;
                            match = true;
                        }
                    }
                }

                //check win D
                if (letter == 'D')
                {
                    //horizontal check D
                    switch (posy)
                    {
                        case 0:
                            if (array1[posx+1]=='E') if (array1[posx+2]=='U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write("DEU");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array1[posx - 1] == 'E') if (array1[posx - 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx - 2, 2 + (step * 5));
                                    Console.Write("UED");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            break;
                        case 1:
                            if (array2[posx + 1] == 'E') if (array2[posx + 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 3 + (step * 5));
                                    Console.Write("DEU");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx - 1] == 'E') if (array2[posx - 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx - 2, 3 + (step * 5));
                                    Console.Write("UED");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            break;
                        case 2:
                            if (array3[posx + 1] == 'E') if (array3[posx + 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write("DEU");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array3[posx - 1] == 'E') if (array3[posx - 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx - 2, 4 + (step * 5));
                                    Console.Write("UED");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            break;
                    }

                    //vertical and diagonal check D
                    if (posy!=1)
                    {
                        if (posy == 0)
                        {
                            if (array2[posx-1]=='E') if (array3[posx-2]=='U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('D');
                                    Console.SetCursorPosition(posx - 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx - 2, 4 + (step * 5));
                                    Console.Write('U');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx]=='E') if (array3[posx]=='U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('D');
                                    Console.SetCursorPosition(posx, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('U');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx+1]=='E') if (array3[posx+2]=='U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('D');
                                    Console.SetCursorPosition(posx + 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx + 2, 4 + (step * 5));
                                    Console.Write('U');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                        }

                        if (posy == 2)
                        {
                            if (array2[posx - 1] == 'E') if (array1[posx - 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('D');
                                    Console.SetCursorPosition(posx - 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx - 2, 2 + (step * 5));
                                    Console.Write('U');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx] == 'E') if (array1[posx] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('D');
                                    Console.SetCursorPosition(posx, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('U');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx + 1] == 'E') if (array1[posx + 2] == 'U')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('D');
                                    Console.SetCursorPosition(posx + 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx + 2, 2 + (step * 5));
                                    Console.Write('U');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                        }
                    }

                }

                //check win U
                if (letter == 'U')
                {
                    //horizontal check U
                    switch (posy)
                    {
                        case 0:
                            if (array1[posx + 1] == 'E') if (array1[posx + 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write("UED");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array1[posx - 1] == 'E') if (array1[posx - 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx - 2, 2 + (step * 5));
                                    Console.Write("DEU");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            break;
                        case 1:
                            if (array2[posx + 1] == 'E') if (array2[posx + 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 3 + (step * 5));
                                    Console.Write("UED");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx - 1] == 'E') if (array2[posx - 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx - 2, 3 + (step * 5));
                                    Console.Write("DEU");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            break;
                        case 2:
                            if (array3[posx + 1] == 'E') if (array3[posx + 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write("UED");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array3[posx - 1] == 'E') if (array3[posx - 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx - 2, 4 + (step * 5));
                                    Console.Write("DEU");
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            break;
                    }

                    //vertical and diagonal check D
                    if (posy != 1)
                    {
                        if (posy == 0)
                        {
                            if (array2[posx - 1] == 'E') if (array3[posx - 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('U');
                                    Console.SetCursorPosition(posx - 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx - 2, 4 + (step * 5));
                                    Console.Write('D');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx] == 'E') if (array3[posx] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('U');
                                    Console.SetCursorPosition(posx, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('D');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx + 1] == 'E') if (array3[posx + 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('U');
                                    Console.SetCursorPosition(posx + 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx + 2, 4 + (step * 5));
                                    Console.Write('D');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                        }

                        if (posy == 2)
                        {
                            if (array2[posx - 1] == 'E') if (array1[posx - 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('U');
                                    Console.SetCursorPosition(posx - 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx - 2, 2 + (step * 5));
                                    Console.Write('D');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx] == 'E') if (array1[posx] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('U');
                                    Console.SetCursorPosition(posx, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx, 2 + (step * 5));
                                    Console.Write('D');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                            if (array2[posx + 1] == 'E') if (array1[posx + 2] == 'D')
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.SetCursorPosition(posx, 4 + (step * 5));
                                    Console.Write('U');
                                    Console.SetCursorPosition(posx + 1, 3 + (step * 5));
                                    Console.Write('E');
                                    Console.SetCursorPosition(posx + 2, 2 + (step * 5));
                                    Console.Write('D');
                                    match = true;
                                    Console.BackgroundColor = defaultbackground;
                                    Console.ForegroundColor = defaultforeground;
                                }
                        }
                    }

                }

                //end game

                

                if (match)
                {
                    Console.SetCursorPosition(0, 6 + (step * 5));
                    if (!playerturn) Console.WriteLine("Player2 wins with " + p2 + " points");
                    else Console.WriteLine("Player1 wins with " + p1 + " points");
                    break;
                }
            }

            byte counter = 0;
            if (match)
            {
                byte insertedscore;
                if (!playerturn) insertedscore = p2;
                else insertedscore = p1;

                //insert score on scoreboard
                foreach (byte i in scores)
                {
                    if (i < insertedscore)
                    {
                        //shift
                        for (byte j = namecount; j >= counter; j--)
                        {
                            names[j + 1] = names[j];
                            scores[j + 1] = scores[j];
                        }
                        //insert
                        scores[counter] = insertedscore;
                        if (!playerturn) names[counter] = "Player2";
                        else names[counter] = "Player1";
                        break;
                    }
                    counter++;
                }
            }

            //show scoreboard
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Name     Score");
            Console.WriteLine("##############");
            Console.ForegroundColor = defaultforeground;
            counter = 0;
            foreach (string i in names)
            {
                Console.Write(i);
                Console.SetCursorPosition(9, (step * 5) + 9 + counter);
                if (scores[counter] > 0) Console.WriteLine(scores[counter]);
                counter++;
            }

            Console.WriteLine();
            Console.Write("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}

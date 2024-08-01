using System;

namespace Calendar
{
    class Program
    {

        static void Main()
        {
            //function for checking if the input is a number
            static bool IsDigit(string str)
            {
                if (String.IsNullOrEmpty(str)) return false;

                //check each character
                foreach (char c in str)
                {
                        //if anything but a digit is detected, return false
                        if ((c < '0' || c > '9')) return false;
                }

                return true;

            }

            static bool CheckLeapYear(ushort year)
            {

                //leap year check
                if (year % 400 == 0)
                {
                    return true;
                }
                else
                {
                    if (year % 100 == 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (year % 4 == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }

            static string week(byte k)
            {
                switch (k)
                {
                    case 0: { return "Monday"; }
                    case 1: { return "Tuesday"; }
                    case 2: { return "Wednesday"; }
                    case 3: { return "Thursday"; }
                    case 4: { return "Friday"; }
                    case 5: { return "Saturday"; }
                    case 6: { return "Sunday"; }
                    default: { return "Error"; }
                }
            }

            string input;

            //DATE 1 YEAR
            Console.Write("(Date 1) Enter Year = ");
            ushort year1;
            while (true)
            {
                input = Console.ReadLine();
                if (IsDigit(input))
                {

                    year1 = ushort.Parse(input);
                    //2015 check
                    if (year1 > 2014)
                    {
                        break;
                    }

                }
                Console.Write("Invalid year. Try again.\n(Date 1) Enter year = ");
            }

            

            //DATE 1 MONTH
            byte month1;
            Console.Write("(Date 1) Enter Month = ");
            while (true)
            {
                input = Console.ReadLine().ToLower();
                if (input == "january")
                {
                    month1 = 1;
                    break;
                }
                else if (input == "february")
                {
                    month1 = 2;
                    break;
                }
                else if (input == "march")
                {
                    month1 = 3;
                    break;
                }
                else if (input == "april")
                {
                    month1 = 4;
                    break;
                }
                else if (input == "may")
                {
                    month1 = 5;
                    break;
                }
                else if (input == "june")
                {
                    month1 = 6;
                    break;
                }
                else if (input == "july")
                {
                    month1 = 7;
                    break;
                }
                else if (input == "august")
                {
                    month1 = 8;
                    break;
                }
                else if (input == "september")
                {
                    month1 = 9;
                    break;
                }
                else if (input == "october")
                {
                    month1 = 10;
                    break;
                }
                else if (input == "november")
                {
                    month1 = 11;
                    break;
                }
                else if (input == "december")
                {
                    month1 = 12;
                    break;
                }
                else
                {
                    Console.Write("Invalid month. Try again.\n(Date 1) Enter month = ");
                }
            }

            //DATE 1 DAY
            byte day1;
            Console.Write("(Date 1) Enter Day = ");
            while (true)
            {
                input = Console.ReadLine();
                if (IsDigit(input))
                {
                    if (255 > ushort.Parse(input) && ushort.Parse(input) > 0)
                    {
                        day1 = byte.Parse(input);

                        //month check
                        if (month1 < 8)
                        {
                            if (month1 % 2 == 1)
                            {
                                if (day1 <= 31)
                                {
                                    break;
                                }
                            }
                            else if (month1 == 2)
                            {
                                if (CheckLeapYear(year1))
                                {
                                    if (day1 <= 29)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (day1 <= 28)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (day1 <= 30)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (month1 % 2 == 1)
                            {
                                if (day1 <= 30)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (day1 <= 31)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.Write("Invalid day. Try again.\n(Date 1) Enter day = ");
            }

            //DATE 2 YEAR
            Console.Write("(Date 2) Enter Year = ");
            ushort year2;
            while (true)
            {
                input = Console.ReadLine();
                if (IsDigit(input))
                {

                    year2 = ushort.Parse(input);
                    //2015 check
                    if (year2 > 2014)
                    {
                        break;
                    }

                }
                Console.Write("Invalid year. Try again.\n(Date 2) Enter year = ");
            }



            //DATE 2 MONTH
            byte month2;
            Console.Write("(Date 2) Enter Month = ");
            while (true)
            {
                input = Console.ReadLine().ToLower();
                if (input == "january")
                {
                    month2 = 1;
                    break;
                }
                else if (input == "february")
                {
                    month2 = 2;
                    break;
                }
                else if (input == "march")
                {
                    month2 = 3;
                    break;
                }
                else if (input == "april")
                {
                    month2 = 4;
                    break;
                }
                else if (input == "may")
                {
                    month2 = 5;
                    break;
                }
                else if (input == "june")
                {
                    month2 = 6;
                    break;
                }
                else if (input == "july")
                {
                    month2 = 7;
                    break;
                }
                else if (input == "august")
                {
                    month2 = 8;
                    break;
                }
                else if (input == "september")
                {
                    month2 = 9;
                    break;
                }
                else if (input == "october")
                {
                    month2 = 10;
                    break;
                }
                else if (input == "november")
                {
                    month2 = 11;
                    break;
                }
                else if (input == "december")
                {
                    month2 = 12;
                    break;
                }
                else
                {
                    Console.Write("Invalid month. Try again.\n(Date 2) Enter month = ");
                }
            }

            //DATE 2 DAY
            byte day2;
            Console.Write("(Date 2) Enter Day = ");
            while (true)
            {
                input = Console.ReadLine();
                if (IsDigit(input))
                {
                    if (255 > ushort.Parse(input) && ushort.Parse(input) > 0)
                    {
                        day2 = byte.Parse(input);

                        //month check
                        if (month2 < 8)
                        {
                            if (month2 % 2 == 1)
                            {
                                if (day2 <= 31)
                                {
                                    break;
                                }
                            }
                            else if (month2 == 2)
                            {
                                if (CheckLeapYear(year2))
                                {
                                    if (day2 <= 29)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (day2 <= 28)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (day2 <= 30)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (month2 % 2 == 1)
                            {
                                if (day2 <= 30)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (day2 <= 31)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.Write("Invalid day. Try again.\n(Date 2) Enter day = ");
            }


            //swap if necessary
            ushort yearswapstorage;
            byte swapstorage;
            if (year1 > year2)
            {
                yearswapstorage = year2;
                year2 = year1;
                year1 = yearswapstorage;

                swapstorage = month2;
                month2 = month1;
                month1 = swapstorage;

                swapstorage = day2;
                day2 = month1;
                day1 = swapstorage;

            }
            else if (year1 == year2)
            {
                if (month1 > month2)
                {
                    swapstorage = month2;
                    month2 = month1;
                    month1 = swapstorage;

                    swapstorage = day2;
                    day2 = month1;
                    day1 = swapstorage;
                }
                else if (month1 == month2)
                {
                    if (day1 > day2)
                    {
                        swapstorage = day2;
                        day2 = month1;
                        day1 = swapstorage;
                    }
                }
            }

            byte n;
            Console.Write("Enter increment = ");
            while (true)
            {
                input = Console.ReadLine();
                if (IsDigit(input))
                {
                    if (224 > ushort.Parse(input) && ushort.Parse(input) > 0 )
                    {
                        n = byte.Parse(input);
                        break;
                    }
                }
                Console.Write("Invalid input. Try again.\nEnter Increment = ");
            }

            //starter day check
            byte imonth;
            ushort iyear;
            if (month1 >= 3) { imonth = (byte)(month1); iyear = year1; }
            else { imonth = (byte)(month1 + 12); iyear = (ushort)(year1 - 1); }

            byte zeller = (byte)((day1 + 13 * (imonth + 1) / 5 + (iyear % 100) + (iyear % 100) / 4 + (iyear / 100) / 4 + 5 * (iyear / 100) - 2)%7);

            Console.WriteLine("");
            Console.WriteLine("");

            //starter season check
            switch (month1)
            {
                case 1:
                    {
                        Console.WriteLine("WINTER");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("WINTER");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("SPRING");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("SPRING");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("SPRING");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("SUMMER");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("SUMMER");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("SUMMER");
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("AUTUMN");
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("AUTUMN");
                        break;
                    }
                case 11:
                    {
                        Console.WriteLine("AUTUMN");
                        break;
                    }
                case 12:
                    {
                        Console.WriteLine("WINTER");
                        break;
                    }
            }

            //starter month check
            byte daysinmonth;
            if (month1 < 8)
            {
                if (month1 % 2 == 1)
                {
                    daysinmonth = 31;
                }
                else if (month1 == 2)
                {
                    if (CheckLeapYear(year1))
                    {
                        daysinmonth = 29;
                    }
                    else
                    {
                        daysinmonth = 28;
                    }
                }
                else
                {
                    daysinmonth = 30;
                }
            }
            else
            {
                if (month1 % 2 == 1)
                {
                    daysinmonth = 30;
                }
                else
                {
                    daysinmonth = 31;
                }
            }

            //list all days
            while (true)
            {
                Console.Write(day1 + " ");

                switch (month1)
                {
                    case 1:
                        {
                            Console.Write("January");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("February");
                            break;
                        }
                    case 3:
                        {
                            Console.Write("March");
                            break;
                        }
                    case 4:
                        {
                            Console.Write("April");
                            break;
                        }
                    case 5:
                        {
                            Console.Write("May");
                            break;
                        }
                    case 6:
                        {
                            Console.Write("June");
                            break;
                        }
                    case 7:
                        {
                            Console.Write("July");
                            break;
                        }
                    case 8:
                        {
                            Console.Write("August");
                            break;
                        }
                    case 9:
                        {
                            Console.Write("September");
                            break;
                        }
                    case 10:
                        {
                            Console.Write("October");
                            break;
                        }
                    case 11:
                        {
                            Console.Write("November");
                            break;
                        }
                    case 12:
                        {
                            Console.Write("December");
                            break;
                        }
                }

                //write day
                Console.WriteLine(" " + year1 + " " + week(zeller));

                //increment
                day1 += n;

                //update day in week
                zeller = (byte)((zeller + n) % 7);

                //month pass check
                while (day1 > daysinmonth)
                {
                    day1 -= daysinmonth;

                    //move to next month
                    month1 += 1;

                    //year pass check
                    if (month1 > 12)
                    {

                        //move to next year
                        month1 = 1;
                        year1 += 1;

                    }


                    //season check
                    switch (month1)
                    {
                        case 3:
                            {
                                Console.WriteLine("");
                                Console.WriteLine("SPRING");
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("");
                                Console.WriteLine("SUMMER");
                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine("");
                                Console.WriteLine("AUTUMN");
                                break;
                            }
                        case 12:
                            {
                                Console.WriteLine("");
                                Console.WriteLine("WINTER");
                                break;
                            }
                    }

                    //update number of days in selected month
                    if (month1 < 8)
                    {
                        if (month1 % 2 == 1)
                        {
                            daysinmonth = 31;
                        }
                        else if (month1 == 2)
                        {
                            if (CheckLeapYear(year1))
                            {
                                daysinmonth = 29;
                            }
                            else
                            {
                                daysinmonth = 28;
                            }
                        }
                        else
                        {
                            daysinmonth = 30;
                        }
                    }
                    else
                    {
                        if (month1 % 2 == 1)
                        {
                            daysinmonth = 30;
                        }
                        else
                        {
                            daysinmonth = 31;
                        }
                    }
                }

                //limit reach check
                if (year1 > year2)
                {
                    break;
                }
                else if (year1 == year2)
                {
                    if (month1 > month2)
                    {
                        break;
                    }
                    else if (month1 == month2)
                    {
                        if (day1 >= day2)
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.CursorVisible = false;
            Console.ReadKey();
        }
    }
}

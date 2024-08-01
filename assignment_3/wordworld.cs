using System;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";


            //enter text
            bool loop = true;
            while (loop)
            {
                Console.Write("Enter text:");
                text = Console.ReadLine();
                Console.Clear();
                loop = false;
                foreach (byte charactervalue in text)
                {

                    //character check
                    if (!(((charactervalue <= 90) && (65 <= charactervalue)) || ((charactervalue <= 122) && (97 <= charactervalue)) || (charactervalue == 44) || (charactervalue == 46) || (charactervalue == 32)))
                    {
                        loop = true;
                        Console.WriteLine("Text cannot contain numbers and symbols other than full stop(.) and comma(,)");
                        break;
                    }
                }
            }

            //remove full stop and comma
            text = text.Replace(".", "");
            text = text.Replace(",", "");



            string pattern = "";
            bool asterisk = false;
            bool hyphen = false;

            //enter pattern
            loop = true;
            while (loop)
            {
                Console.Write("Enter pattern:");
                pattern = Console.ReadLine();

                loop = false;
                foreach (byte charactervalue in pattern)
                {

                    //character check
                    if (!(((charactervalue <= 90) && (65 <= charactervalue)) || ((charactervalue <= 122) && (97 <= charactervalue)) || (charactervalue == 44) || (charactervalue == 42) || (charactervalue == 45)))
                    {
                        loop = true;
                        Console.Clear();
                        Console.WriteLine("Pattern cannot contain numbers and symbols other than hyphen(-) and asterisk(*)");
                        break;
                    }

                    //hyphen check
                    if (charactervalue == 42)
                    {
                        if (hyphen)
                        {
                            loop = true;
                            Console.Clear();
                            Console.WriteLine("Pattern cannot contain both hyphen(-) and asterisk(*)");
                            break;
                        }
                        else asterisk = true;
                    }

                    //asterisk check
                    if (charactervalue == 45)
                    {
                        if (asterisk)
                        {
                            loop = true;
                            Console.Clear();
                            Console.WriteLine("Pattern cannot contain both hyphen(-) and asterisk(*)");
                            break;
                        }
                        else hyphen = true;
                    }
                }
            }
            pattern = pattern.ToLower();

            string[] words = text.Split();
            bool match;
            ushort matchnumber = 0;
            string[] matchwords = new string[words.Length];
            //look for matches
            if (!asterisk)
            {
                //hyphen or none
                foreach (string word in words)
                {

                    //length check
                    if (word.Length == pattern.Length)
                    {
                        string lowerword = word.ToLower();
                        byte index = 0;
                        match = true;
                        foreach (char character in pattern)
                        {
                            if (character != '-')
                            {
                                //match check
                                if (character != lowerword[index])
                                {
                                    match = false;
                                    break;
                                }
                            }
                            index++;
                        }

                        //write
                        if (match)
                        {
                            bool repeats = false;
                            foreach (string i in matchwords)
                            {
                                if (i != null)
                                {
                                    if (i.ToLower() == lowerword)
                                    {
                                        repeats = true;
                                        break;
                                    }
                                }
                            }
                            if (!repeats)
                            {
                                matchwords[matchnumber] = word;
                                Console.WriteLine(word);
                                matchnumber++;
                            }
                        }
                    }
                }
            }
            else
            {
                //asterisk

                //convert pattern
                string buffer = "";
                bool suppressasterisk = false;
                foreach (char letter in pattern)
                {
                    if (letter == '*')
                    {
                        if (!suppressasterisk)
                        {
                            buffer += "*";
                            suppressasterisk = true;
                        }
                    }
                    else
                    {
                        buffer += letter;
                        if (suppressasterisk) suppressasterisk = false;
                    }
                }
                //start and end characters
                pattern = "," + buffer + ".";

                //split word into packages
                string[] packagelist = pattern.Split("*");

                foreach (string word in words)
                {
                    match = true;
                    string targetword = ("," + word + ".").ToLower();
                    byte index = 0;

                    //compare packages
                    foreach (string package in packagelist)
                    {
                        int targetlocation = targetword.IndexOf(package, index);
                        if (targetlocation == -1)
                        {
                            match = false;
                            break;
                        }
                        else
                        {
                            index = (byte)(targetlocation + package.Length);
                        }
                    }

                    //write
                    if (match)
                    {
                        bool repeats = false;
                        foreach (string i in matchwords)
                        {
                            if (i != null)
                            {
                                if (i.ToLower() == word.ToLower())
                                {
                                    repeats = true;
                                    break;
                                }
                            }
                        }
                        if (!repeats)
                        {
                            matchwords[matchnumber] = word;
                            Console.WriteLine(word);
                            matchnumber++;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}

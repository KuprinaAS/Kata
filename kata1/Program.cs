using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata1
{
    class Program
    {
        /// <summary>
        /// Highest and Lowest:
        /// In this little assignment you are given a string of space separated numbers,
        /// and have to return the highest and lowest number.
        /// </summary>
        public static string HighAndLow(string num)
        {
            string[] m = num.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] m2 = new int[m.Length];

            for (int i = 0; i < m.Length; i++)
            {
                m2[i] = Convert.ToInt32(m[i]);
            }
            return m2.Max() + " " + m2.Min();
        }
        /// <summary>
        /// Split Strings:
        /// Complete the solution so that it splits the string into pairs of two characters.
        /// If the string contains an odd number of characters then it should replace the missing second
        /// character of the final pair with an underscore ('_').
        /// </summary>
        public static string[] SplitStr(string str)
        {
            if (str.Length % 2 != 0)
                str += "_";
            string[] strDu = new string[str.Length/2 + (str.Length % 2 == 0 ? 0 : 1)];
            int i = 0;
            while (str.Length > 0)
            {
                strDu[i] = str.Substring(0, 2);
                str = str.Remove(0, strDu[i].Length);
                ++i;
            }
            return strDu;
        }
        /// <summary>
        /// Reverse words:
        /// Complete the function that accepts a string parameter, and reverses each word in the string.
        /// All spaces in the string should be retained.
        /// </summary>
        public static string ReverseWords(string str)
        {
            string resStr = "";
            string[] words = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string output = "";
                for (int j = words[i].Length - 1; j >= 0; j--)
                {
                    output += words[i][j];
                }
                if (i == words.Length - 1)
                    resStr += output;
                else
                    resStr += output + " ";
            }
            return resStr;
        }
        /// <summary>
        /// Snail Sort:
        /// Given an n x n array, return the array elements arranged from outermost elements to the middle element, 
        /// traveling clockwise.
        /// </summary>
        public static int[] Snail(int[,] array)
        {
            int[] r = new int[array.Length];
            int l = 0, i = 0, j, t = 0, n = (int)Math.Sqrt(array.Length);
            while (l < array.Length)
            {
                for (j = t; j < n; j++)
                {
                    r[l++] = array[i, j];
                }
                j--;
                for (i = t + 1; i < n; i++)
                {
                    r[l++] = array[i, j];
                }
                i--;
                for (j = n - 2; j >= t; j--)
                {
                    r[l++] = array[i, j];
                }
                j = t;
                for (i = n - 2; i > t; i--)
                {
                    r[l++] = array[i, j];
                }
                n--;
                t++;
                j = t;
                i = t;
            }
            return r;
        }
        /// <summary>
        /// Isograms:
        /// An isogram is a word that has no repeating letters, consecutive or non-consecutive.
        /// Implement a function that determines whether a string that contains only letters is an isogram.
        /// Assume the empty string is an isogram. Ignore letter case.
        /// </summary>
        public static bool IsIsogram(string str)
        {
            bool result = false;
            int k = str.ToLower().Length - str.ToLower().ToCharArray().Distinct().Count();
            if (k == 0)
                result = true;
            return result;
        }
        /// <summary>
        /// Disemvowel Trolls:
        /// Trolls are attacking your comment section!
        /// A common way to deal with this situation is to remove all of the vowels from the trolls' comments,
        /// neutralizing the threat.
        /// Your task is to write a function that takes a string and return a new string with all vowels removed.
        /// For example, the string "This website is for losers LOL!" would become "Ths wbst s fr lsrs LL!".
        /// Note: for this kata y isn't considered a vowel.
        /// </summary>
        public static string Disemvowel(string str)
        {
            var glas = new string[] { "a", "e", "o", "i", "u", "A", "E", "O", "I", "U", "а", "е", "ё", "и", "о",
                                      "у", "ы", "э", "ю", "я", "А", "Е", "Ё", "И", "О", "У", "Ы", "Э", "Ю", "Я"};
            foreach (var s in glas)
            {
                str = str.Replace(s, "");
            }
            return str;
        }
        /// <summary>
        /// Equal Sides Of An Array:
        /// You are going to be given an array of integers.
        /// Your job is to take that array and find an index N where the sum of the integers
        /// to the left of N is equal to the sum of the integers to the right of N.
        /// If there is no index that would make this happen, return -1.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int EqualSides(int[] num)
        {
            int n = -1, suml = 0, sumr, k = 1;
            for (int i = 0; i < num.Length; i++)
            {
                sumr = 0;
                for (int j = k; j < num.Length; j ++)
                {
                    sumr += num[j];
                }
                if (suml == sumr)
                {
                    return i;
                }
                else
                {
                    k++;
                    suml += num[i];
                }
            }
            return n;
        }
        static void Main(string[] args)
        {
            //---Highest and Lowest
            Console.WriteLine("Введите число(а) раздляя их пробелом:");
            string number = Console.ReadLine();
            Console.WriteLine(HighAndLow(number));

            //---Split Strings
            Console.WriteLine("Введите строку символов:");
            string str = Console.ReadLine();
            string[] res = SplitStr(str);
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i] + " ");
            }

            //---Isograms
            Console.WriteLine("\nIsogram? " + IsIsogram(str));
            
            //---Reverse words
            Console.WriteLine("Введите строку:");
            str = Console.ReadLine();
            Console.WriteLine(ReverseWords(str));

            //---Disemvowel Trolls
            Console.WriteLine("Disemvowel Trolls: " + Disemvowel(str));
            
            //---Snail Sort
            Console.WriteLine("Размерность массива nxn: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0)
                n = 1;
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Random ran = new Random();
                    array[i, j] = ran.Next(9) + 1;
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //int[,] array = { { 1, 2, 3}, {4, 5, 6 }, {7, 8, 9 } };

            int[] result = Snail(array);
            for (int k = 0; k < result.Length; k++)
            {
                Console.Write(result[k] + " ");
            }

            //---Equal Sides Of An Array
            Console.WriteLine("\n Введите количество чисел в массиве: ");
            n = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[n]; // { 10, -80, 10, 10, 15, 35, 20 };
            for (int i = 0; i < n; i++)
            {
                Random ran = new Random();
                numbers[i] = ran.Next(-100, 100);
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine("\n" + EqualSides(numbers));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleStrings
{
    class Program
    {

        static void Main(string[] args)
        {
            int k = 0, maxlen = -1;
            bool flag = false;
            StringBuilder max = new StringBuilder();
            string str = Console.ReadLine();
            StringBuilder[] words = new StringBuilder[str.Length / 2 + 1];
            for (int i = 0; i < str.Length / 2 + 1; i++)
                words[i] = new StringBuilder();
            int count1 = 0, count11 = 0, count2 = 0, count22 = 0;
            flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(') count1++;
                if (str[i] == ')') count11++;
                if (str[i] == '[') count2++;
                if (str[i] == ']') count22++;
                if (((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'А' && str[i] <= 'Я') || (str[i] >= 'а' && str[i] <= 'я')))
                {
                    words[k].Append(str[i]);
                    flag = false;
                }
                else
                {
                    if (!flag) k++;
                    flag = true;
                }
            }
            string pattern;
            string curword = "";
            for (int i = 0; i <= k; i++)
            {
                // Console.WriteLine(words[i] + "-");
                if (words[i].Length > maxlen)
                {
                    max = words[i];
                    maxlen = words[i].Length;
                }
                flag = false;
                for (int j = 0; j < words[i].Length; j++)
                {
                    curword = words[i].ToString();
                    if (!((curword[j] >= 'A' && curword[j] <= 'Z') || (curword[j] >= 'a' && curword[j] <= 'z'))) flag = true;
                }
                if (!flag && curword != "")
                {
                    pattern = @"(^|\W|[0-9])" + curword + @"(\W|[0-9]|$)";
                    str = Regex.Replace(str, pattern, "$1$2");
                }
            }
            if (count1 != count11)
                Console.WriteLine("Количество круглых открытых скобок: " + count1.ToString() + "\nКоличество круглых закрытых скобок: " + count11.ToString());
            else Console.WriteLine("С круглыми скобками все ок");
            if (count2 != count22)
                Console.WriteLine("Количество открытых квадратных скобок: " + count2.ToString() + "\nКоличество закрытых квадратных скобок: " + count22.ToString());
            else Console.WriteLine("С квадратными скобками все ок");
            Console.WriteLine("Самое длинное слово: " + max.ToString());
            Console.WriteLine("Текст после обработки:\n" + str);
            Console.ReadKey();
        }

    }
}

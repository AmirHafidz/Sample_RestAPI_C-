using System;
using System.Collections.Generic;

namespace AmirRestAPI.Services
{
    public class Payment
    {
        public enum Barang
        {
            BURGER = 10,
            PIZZA = 9,
            FRIES = 8
        }

        //public static Main moneyChanges()
        //{
        //    float res = 
        //    return res;
        //}
        public static int makan(string item)
        {

            var ProductItem = new Dictionary<string, int>()
            {
                {"BURGER" , 5 },
                {"PIZZA" , 8 },
                {"FRIES" , 4 }

            };
            if (ProductItem.ContainsKey(item))
            {
                int res = ProductItem[item];
                return res;
            }
            else
            {
                return 0;
            }

        }

        public static string upperWord(string m)
        {
            return m.ToUpper();
        }

        public static string Print()
        {
            string l = "";

            string[] arr;

            Random rand = new Random();
            arr = new String[7];
            for (int i = 0; i < arr.Length; i++)
            {
                string k = rand.Next(1, 10).ToString();
                arr[i] = k;
            }
            foreach (string s in arr)
            {
                Console.WriteLine(s);
                l += s;

            }
            string h = "#" + l;
            return h;
        }
    }
}

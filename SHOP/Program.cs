using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using System.ComponentModel.Design;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int climb = 0;
            string line = "";
            string[] start = new string[] { };
            string[] setup = new string[4] ;
            List<string[]> rating = new List<string[]>();
            List<string[]> shop = new List<string[]>();


            using (StreamReader sr = new StreamReader("setup.ini"))
            {
                int t = 0;
                while ((line = sr.ReadLine()) != null)
                {  
                    start = line.Split("=");
                    for(int i =0; i< start.Length; i++)
                    {
                        setup[t] = start[i];
                        t++;
                    }
                }
            }
        
            string source = setup[1];
            string outthere = setup[3];

            using (StreamReader sr = new StreamReader(source))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    start = line.Split(",");
                    shop.Add(start);

                }
            }
            //foreach (string[] s in shop)
            //{
            //    if (s[5] == "case-fan")
            //    {
            //        foreach(string l in s)
            //        {
            //            Console.Write(l + "\t");
            //        }
            //        Console.WriteLine();
            //    }
            //}
            
            for(int x = 0; x <= 5; x++)
            {
                List<string[]> temp = shop;
                for (int y = 0; y < temp.Count; y++)
                {
                    int xnum = int.Parse(shop[y][1]);
                    if(xnum == x)
                    {
                        rating.Add(shop[y]);
                        shop.RemoveAt(y);
                    }
                }
            }
            foreach (string[] k in rating)
            {
                foreach(string s in k)
                {
                    Console.Write(s + "\t");
                }
                count++;
                Console.WriteLine();
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            string[] start = new string[] { };
            string[] setup = new string[4] ;
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
        }
    }
}
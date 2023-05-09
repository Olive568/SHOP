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
            List<string[]> shop = new List<string[]>();
            string[] start = new string[2] ;
            string[] setup = new string[4] ;
            string[] categories = new string[27] { "case-accessory", "case-fan", "case", "cpu-cooler", "cpu", 
                "external-hard-drive" , "fan-controller" , "headphones" , "internal-hard-drive" , "keyboard", 
                "laptop" , "memory", "monitor" , "motherboard" , "mouse" , "optical-drive" , "os" , "power-supply" , "software" , "sound-card"
            , "speakers", "thermal-paste" , "ups" , "video-card" , "webcam" , "wired-network-card" , "wireless-network-card"};
            List<string[]> rating = new List<string[]>();
            bool cont = true;


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


            while (cont)
            {
                List<int> list = new List<int>();
                List<string[]> main = new List<string[]>();
                Console.WriteLine("COMMANDS: RATING, RATING COUNT, PRICE");
                string choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "RATING":
                        for (int x = 5; x >= 0; x--)
                        {
                            List<string[]> temp = shop;
                            for (int y = 0; y < temp.Count; y++)
                            {
                                int xnum = int.Parse(shop[y][1]);
                                if (xnum == x)
                                {
                                    main.Add(shop[y]);
                                }
                            }
                        }
                        for (int x = 0; x < categories.Length; x++)
                        {
                            string filePath = outthere + categories[x] + ".csv";
                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                foreach (string[] s in main)
                                {
                                    if (s[5] == categories[x])
                                    {
                                        foreach (string l in s)
                                        {
                                            sw.Write(l + ",");
                                        }
                                        sw.WriteLine();
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Rating Csv's has been created, press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "RATING COUNT":
                        foreach (string[] s in shop)
                        {
                            if (!list.Contains(int.Parse(s[2])))
                            {
                                list.Add(int.Parse(s[2]));
                            }
                        }
                        bool swapped = true;
                        do
                        {
                            swapped = false;
                            for (int i = 0; i < list.Count - 1; i++)
                            {
                                if (list[i] < list[i + 1])
                                {
                                    // Swap the elements
                                    int temp = list[i];
                                    list[i] = list[i + 1];
                                    list[i + 1] = temp;

                                    swapped = true;
                                }
                            }
                        } while (swapped);
                        foreach (int count in list)
                        {
                            foreach (string[] s in shop)
                            {
                                if (int.Parse(s[2]) == count)
                                {
                                    foreach (string l in s)
                                    {
                                        Console.Write(l + ",");
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                        break; 
                        
                }
                
            }           
            Console.WriteLine("done");
        }
    }
}
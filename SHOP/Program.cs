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
            bool swapped = true;
            List<string[]> shop = new List<string[]>();
            string[] start = new string[2] ;
            string[] setup = new string[4] ;
            string[] categories = new string[27] { "case-accessory", "case-fan", "case", "cpu-cooler", "cpu", 
                "external-hard-drive" , "fan-controller" , "headphones" , "internal-hard-drive" , "keyboard", 
                "laptop" , "memory", "monitor" , "motherboard" , "mouse" , "optical-drive" , "os" , "power-supply" , "software" , "sound-card"
            , "speakers", "thermal-paste" , "ups" , "video-card" , "webcam" , "wired-network-card" , "wireless-network-card"};
            List<string[]> rating = new List<string[]>();
            List<string[]> shop2 = new List<string[]>();
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
                Console.WriteLine("There are " + categories.Length + " categories");
                Console.WriteLine("This program will segregate files by category");
                Console.WriteLine("How Do you want them To be sorted? It will always be in ascending order");
                Console.WriteLine("\t" + "[A] Rating");
                Console.WriteLine("\t" + "[B] Rating Count");
                Console.WriteLine("\t" + "[C] Price");
                Console.WriteLine("\t" + "[D] Clear Console");
                Console.WriteLine("\t" + "[E] Exit");
                Console.Write("Please input your answer here: ");
                string choice = Console.ReadLine();
                choice = choice.ToUpper();
                switch (choice)
                {
                    case "A":
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
                            Console.Write("sorting " + categories[x] + "   ....   ");
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
                            Console.Write("Done!");
                            Console.WriteLine();
                        }
                        break;
                    case "B":
                        foreach (string[] s in shop)
                        {
                            if (!list.Contains(int.Parse(s[2])))
                            {
                                list.Add(int.Parse(s[2]));
                            }
                        }
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
                        for (int x = 0; x < categories.Length; x++)
                        {
                            Console.Write("sorting " + categories[x] + "   ....   ");
                            string filePath = outthere + categories[x] + ".csv";
                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                foreach (int com in list)
                                {
                                    foreach (string[] s in shop)
                                    {
                                        if (int.Parse(s[2]) == com && s[5] == categories[x])
                                        {
                                            for (int t = 0; t < s.Length; t++)
                                            {
                                                sw.Write(s[t] + ",");
                                            }
                                            sw.WriteLine();
                                        }
                                    }
                                }
                            }
                            Console.Write("Done!");
                            Console.WriteLine();
                        }
                        break;
                    case "C":
                        for (int i = 0; i < shop.Count - 1; i++)
                        {
                            int maxIndex = i;
                            for (int j = i + 1; j < shop.Count; j++)
                            {
                                if (double.Parse(shop[j][3]) > double.Parse(shop[maxIndex][3]))
                                {
                                    maxIndex = j;
                                }
                            }
                            if (maxIndex != i)
                            {
                                count++;
                                string[] temp = shop[maxIndex];
                                shop[maxIndex] = shop[i];
                                shop[i] = temp;
                            }
                        }
                        for(int x = 0; x < categories.Length; x++)
                        {
                            string filePath = outthere + categories[x] + ".csv";
                            Console.Write("sorting " +categories[x] + "   ....   ");
                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                foreach (string[] s in shop)
                                    if (s[5] == categories[x])
                                    { 
                                        foreach(string l in s)
                                        {
                                            sw.Write(l + ",");
                                        }
                                        sw.WriteLine();
                                    }      
                            }
                            Console.Write("Done!");
                            Console.WriteLine();
                        }
                        break;
                    case "D":
                        Console.Clear();
                        break;
                    case "E":
                            cont = false;
                            break;
                    default:
                        Console.WriteLine("That is not a valid command");
                            break;
                }
                             
            }           
        }
    }
}
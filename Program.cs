using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace ConsoleApp6
{
    internal class Program
    {
        private static string path = "ahoj.txt";
        private static StreamReader sr = null;
        static void Main(string[] args)
        {
            sr = new StreamReader(path);
            /*
            sr = new StreamReader(path);
            int[] x = Vytahni_Cisla_Portu();
            if(x == null) { Console.Write("tak nic"); }
            else
            {
                foreach(int i in x)
                {
                    Console.WriteLine(i.ToString());
                }
            }*/
            
            Find_Specific_Line(564);
            
            /*
            if (!File.Exists(path)) { File.Create("ahoj.txt"); }
            Final_Append(Find_Place("cmdoekrjjsl", "654/udp", "#JEN PROSTĚ TAK"), "ahojky");
            */
            sr.Close();

            //Final_Append("d\t\t5019/tcp\t#aa", "ahojky?");
            Console.ReadKey();
        }


        static List<int> Najit_Presny()
        {
            bool tabnuto = true;
            string cislo_jako_string = "5";
            List<string> radek = sr.ReadToEnd().Split('\n').ToList();
            List<int> cisla = new List<int>();
            //StringBuilder sb = null;

            foreach(string s in radek )
            {
                if (s.Length > 2)
                {
                    char[] radek_do_char = s.ToCharArray();
                    //sb = new StringBuilder(cislo_jako_string);
                    for (int i = 0; i < s.Length; i++)
                    {
                        //if (radek_do_char[i] == '\t')
                        //    tabnuto = tabnuto == true ? false : true;
                        if(char.IsDigit(radek_do_char[i]))
                            cislo_jako_string += Convert.ToString(radek_do_char[i]);
                    }
                    //cislo_jako_string.Remove(cislo_jako_string.Length - 4, 4);
                    cislo_jako_string.Remove(0, 1);
                    cisla.Add(Convert.ToInt32(cislo_jako_string));
                    cislo_jako_string = " ";

                    //další podmínka na to jestli se rovná port portu a vybere se řídek
                }
            }
            return cisla;
        }
        //najít nižší řádek
        private static void Find_Specific_Line(int port)
        {
            char[] rozdeleni = new char[] { ' ', '\t', '/'};
            string[] radky = sr.ReadToEnd().Split('\n');

            foreach(string r in radky)
            {
                if (r.Length > 5)
                {
                    string[] cislo_portu = r.Split(rozdeleni);
                }
            }
        }
        static void Final_Append(string vypsany_radek, string novy_radek)
        {
            var txtLines = File.ReadAllLines(path).ToList();                    //Fill a list with the lines from the txt file.
            txtLines.Insert(txtLines.IndexOf(vypsany_radek), novy_radek);            //Insert the line you want to add last under the tag 'item1'.
            File.WriteAllLines(path, txtLines);                                 //Add the lines including the new one.
        }
    }
}

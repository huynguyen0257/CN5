using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable dictionary = new Hashtable();
            dictionary.Add("teacher", "giao Vien");
            dictionary.Add("studen", "sinh vien");
            dictionary.Add("hero", "anh hung");
            dictionary.Add("brother", "anh em");
            dictionary.Add("music", "am nhac");
            string key;
            do
            {
                Console.Write("Input English: ");
                key = Console.ReadLine();
                if(key == "\\")
                {
                    Console.WriteLine("Exit the program");
                    break;
                }
                try
                {
                    string value = dictionary[key].ToString();
                    Console.WriteLine("Vietnamese: {0}", value);
                }
                catch 
                {
                    Console.WriteLine("WARNING! This word dose not exist");
                }
            } while (true);
        }
    }
}

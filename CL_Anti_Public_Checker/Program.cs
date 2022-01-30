using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL_Anti_Public_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Util.RequestUtil.getHashesInDB();
            foreach(string p in File.ReadAllLines("data.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (Util.RequestUtil.HashExists(Util.HashUtil.sha256(p))) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(p);
                count++;
                Console.Title = count.ToString();   
            }
            Console.ReadLine();
        }
    }
}

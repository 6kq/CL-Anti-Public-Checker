﻿using System;
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
            Util.RequestUtil.getHashesInDB();
            foreach(string p in File.ReadAllLines("data.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (Util.RequestUtil.HashExists(Util.HashUtil.sha256(p))) Console.WriteLine(p);
                Util.StorageUtil.count++;
                Console.Title = Util.StorageUtil.count.ToString();   
            }
            Console.ReadLine();
        }
    }
}
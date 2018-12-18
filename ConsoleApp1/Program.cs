
using KetamaHash;
using KetamaHash.MurmurHash;
using RedBlackCS;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            ConsistencyRing hashRing = new ConsistencyRing();
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(hashRing.GetCurrent());
            }
            Console.WriteLine((DateTime.Now - start).TotalSeconds);
            Console.Read();
            //MurmurHashFactory.
            //RedBlack<int, string> redBlack = new RedBlack<int, string>("node");
            //redBlack.Add(1, conver(1));
            //redBlack.Add(2, conver(2));
            //redBlack.Add(3, conver(3));
            //redBlack.Add(4, conver(4));
            //redBlack.Add(5, conver(5));
            //redBlack.Add(6, conver(6));
            //redBlack.Add(8, conver(8));
            //redBlack.Add(7, conver(7));
            //redBlack.Add(9, conver(9));
            //var r = redBlack.TailMap(5);
            //Console.WriteLine(r.GetData(8));
            //Console.WriteLine(redBlack.GetData(8));
            Console.Read();


        }
       static string conver(int i)
        {
            return i.ToString();
        }
    }
}

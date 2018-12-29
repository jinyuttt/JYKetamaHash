
using KetamaHash;
using KetamaHash.MurmurHash;
using KetamaHash.NodeList;
using RedBlackCS;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        /*
         *持续更新地址 https://github.com/jinyuttt/LoadBalanceHash.git
         * 
         * 
         */
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("测试开始");
               DateTime start = DateTime.Now;
                ConsistencyRing hashRing = new ConsistencyRing();
                Dictionary<string, int> sum = new Dictionary<string, int>();
                int size = 1000000;
                int value = 0;
                string key = "";
                for (int i = 0; i < size; i++)
                {
                    //Console.WriteLine(hashRing.GetCurrent());
                    key = hashRing.GetCurrent().ToString();
                   
                    // Console.WriteLine(key);
                    if (sum.TryGetValue(key, out value))
                    {
                        sum[key] = value + 1;
                    }
                    else
                    {
                        sum[key] = 1;
                    }

                }
                Console.WriteLine("执行时间（秒）：" + (DateTime.Now - start).TotalSeconds);
                double d1 = 0;
                double d2 = 100;
                foreach (var item in sum)
                {
                    double d = item.Value / (double)size * 100;
                    Console.WriteLine(item.Key + ":" + d);
                    if (d > d1)
                    {
                        d1 = d;
                    }
                    if (d < d2)
                    {
                        d2 = d;
                    }
                }
                Console.WriteLine("命中的节点数：" + sum.Count);
                Console.WriteLine("最大命中率：" + d1 + "%,最小命中率：" + d2 + "%");
                Console.ReadLine();
            }
            //MurmurHashFactory.
            //RedBlack<int, string> redBlack = new RedBlack<int, string>("node");
            //for (int i = 0; i < 1600; i++)
            //{
            //    redBlack.Add(i, conver(i));
            //}
            //redBlack.Add(1700, conver(1700));
            //redBlack.Add(1800, conver(1800));
            //redBlack.Add(1900, conver(1900));
            //StoreList<int, string> redBlack = new StoreList<int, string>(15);
            //redBlack.Add(1, conver(1));
            //redBlack.Add(2, conver(2));
            //redBlack.Add(3, conver(3));
            //redBlack.Add(4, conver(4));
            //redBlack.Add(5, conver(5));
            //redBlack.Add(6, conver(6));

            //redBlack.Add(8, conver(8));
            //redBlack.Add(7, conver(7));
            //redBlack.Add(9, conver(9));
            //redBlack.Add(13, conver(13));
            //redBlack.Add(14, conver(13));
            //redBlack.Add(15, conver(13));
            //redBlack.Add(16, conver(13));
            //redBlack.Add(18, conver(18));
            //  redBlack.UpdateSort();
            // var r = redBlack.TailMap(5);
            //Console.WriteLine(redBlack.TailNode(1601).Key);
            //Console.WriteLine(r.GetData(8));
            //Console.WriteLine(redBlack.GetData(8));
            //Console.Read();


        }
       static string conver(int i)
        {
            return i.ToString();
        }
    }
}

using KetamaHash.MurmurHash;
using RedBlackTree;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KetamaHash
{

    /// <summary>
    /// 筛选
    /// </summary>
    public class KetamaNodeLocator: IKetamaHash
    {

        private RedBlack<ulong, StoreNode> ketamaNodes = null;
        private List<StoreNode> shards = new List<StoreNode>(); // 真实机器节点
        private int numReps = 160;

        private ManualResetEventSlim resetEvent = new ManualResetEventSlim(true);

        public KetamaNodeLocator()
        {
            ketamaNodes = new RedBlack<ulong, StoreNode>("node");
        }
    
        public void AddNode(List<StoreNode> nodes, int nodeCopies = 0)
        {
            resetEvent.Reset();
             shards = nodes;
            if (nodeCopies != 0)
            {
                numReps = nodeCopies;
            }
            ketamaNodes.Clear();
            //对所有节点，生成nCopies个虚拟结点
            List<ulong> lst = new List<ulong>();
            foreach (StoreNode node in nodes)
            {
                //每四个虚拟结点为一组
                lst.Clear();
                for (int i = 0; i < numReps; i++)
                {
                    //getKeyForNode方法为这组虚拟结点得到惟一名称 
                    /** Murmur是一个16字节长度的数组，将16字节的数组每四个字节一组，分别对应一个虚拟结点，这就是为什么上面把虚拟结点四个划分一组的原因*/
                    try
                    {
                        //byte[] digest = MurmurHashFactory.ComputeMurmur(node.ToString() + i);
                        //for (int h = 0; h < 4; h++)
                        //{
                        //    long m = MurmurHashFactory.Hash(digest, h);
                        //    ketamaNodes.Add(m, node);
                        //    lst.Add(m);
                        //}
                        byte[] digest = MurmurHashFactory.ComputeMurmur(node.ToString() + i);
                        ulong key = MurmurHashFactory.Hash(digest);
                        ketamaNodes.Add(key, node);
                        lst.Add(key);
                    }
                    catch (RedBlackException ex)
                    {
                        if (ex.Error == ReadBlackCode.KeyExists)
                        {
                            foreach (ulong key in lst)
                            {
                                try
                                {
                                    ketamaNodes.Remove(key);
                                }
                                catch
                                {

                                }
                            }
                        }
                        i--;
                    }
                }
            }
            resetEvent.Set();
        }

        public void AddNode(StoreNode node)
        {
            resetEvent.Reset();
           // ketamaNodes.ResetTree();
             List<ulong> lst = new List<ulong>();
            for (int i = 0; i < numReps; i++)
            {
                //getKeyForNode方法为这组虚拟结点得到惟一名称 
                /** 是一个16字节长度的数组，将16字节的数组每四个字节一组，分别对应一个虚拟结点，这就是为什么上面把虚拟结点四个划分一组的原因*/
                try
                {
                    //byte[] digest = MurmurHashFactory.ComputeMurmur(node.ToString() + i);
                    //for (int h = 0; h < 4; h++)
                    //{
                    //    long m = MurmurHashFactory.Hash(digest, h);
                    //    ketamaNodes.Add(m, node);
                    //    lst.Add(m);
                    //}
                    byte[] digest = MurmurHashFactory.ComputeMurmur(node.ToString() + i);
                    ulong key = MurmurHashFactory.Hash(digest);
                    //Console.WriteLine(node.ToString() + i + ":" + key);
                    ketamaNodes.Add(key, node);
                   // lst.Add(key);
                }
                catch (RedBlackException ex)
                {
                    if (ex.Error == ReadBlackCode.KeyExists)
                    {
                        foreach (ulong key in lst)
                        {
                            try
                            {
                                ketamaNodes.Remove(key);
                            }
                            catch
                            {

                            }
                        }
                    }
                    i--;
                }
            }
            resetEvent.Set();
        }

        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="node"></param>
        public void Remove(StoreNode node)
        {
            var lst= ketamaNodes.FindKeys(node);
            for (int i = 0; i < lst.Count; i++)
            {
                ketamaNodes.Remove(lst[i]);
            }
            lst.Clear();
        }


        /// <summary>
        /// 获取服务节点
        /// </summary>
        /// <param name="k">Key</param>
        /// <returns></returns>
        public StoreNode GetPrimary(string k)
        {
             Murmur128 murmur = MurmurHashFactory.MurmurHash.Create128((uint)Environment.TickCount);
            byte[] digest = murmur.ComputeHash(Encoding.UTF8.GetBytes(k));
            ulong key = MurmurHashFactory.Hash(digest);
            return GetNodeForKey(key);
        }

        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        StoreNode GetNodeForKey(ulong hash)
        {
            //string rv=null;
            ulong key = hash;
            //如果找到这个节点，直接取节点，返回   
            //得到大于当前key的那个子Map，然后从中取出第一个key，就是大于且离它最近的那个key
           // resetEvent.Wait();
            var cirCle = ketamaNodes.TailNode(key);
            if(cirCle==null)
            {
                cirCle = ketamaNodes.First();
            }
            return cirCle.Value;
                 
        }

       

        /// <summary>
        /// 测试使用
        /// </summary>
        public void Print()
        {
            //using (StreamWriter sw = new StreamWriter("allkeys.csv"))
            //{
            //    foreach(var item in dicnodes)
            //    {
            //        sw.WriteLine(item.Key + "," + item.Value);
            //    }
            //}
            //using (StreamWriter sw = new StreamWriter("search.csv"))
            //{
            //    foreach (var item in lstNodes)
            //    {
            //        sw.WriteLine(item);
            //    }
            //}
        }


        public double Test()
        {
            return 0;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace KetamaHash
{
   public interface IKetamaHash
    {

        /// <summary>
        /// 初始化添加节点
        /// </summary>
        /// <param name="nodes">真实节点</param>
        /// <param name="nodeCopies">每一个虚拟节点</param>
        void AddNode(List<StoreNode> nodes, int nodeCopies = 0);

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node"></param>
        void AddNode(StoreNode node);

        void Remove(StoreNode node);

         StoreNode GetPrimary(string k);

        double Test();

        void Print();

    }
}

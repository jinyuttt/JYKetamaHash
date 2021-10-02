# JYKetamaHash
Hash一致实现负载均衡  
底层使用红黑树保存节点信息
---------------------------------------------------------------------
使用方法：  
1.直接将数据发网服务端  
   hashRing.GetCurrent();  
2.将字符串Key映射到服务端  
   hashRing.GetStoreNode(key)  
3.将其它类型Key映射到服务端  
   byte[]k=你的转换方式(k)  
   hashRing.GetStoreNode(key)   
   需要将Key转换（序列化为byte[])
  
  使用前需要将真实节点插入  
    ConsistencyRing hashRing = new ConsistencyRing();  
    hashRing.AddNode();  

---------------------------------------------------------------------


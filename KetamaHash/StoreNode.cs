#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：KetamaHash
* 项目描述 ：
* 类 名 称 ：StoreNode
* 类 描 述 ：
* 命名空间 ：KetamaHash
* CLR 版本 ：4.0.30319.42000
* 作    者 ：jinyu
* 创建时间 ：2018
* 更新时间 ：2018
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ jinyu 2018. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion


namespace JYKetamaHash
{
    /* ============================================================================== 
    * 功能描述：StoreNode 
    * 创 建 者：jinyu 
    * 修 改 者：jinyu 
    * 创建日期：2018 
    * 修改日期：2018 
    * ==============================================================================*/

    public class StoreNode
    {
        public const int KeyLen = 40;
        public string Name { get; set; }

        public string IP { get; set; }

        public int Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format("Share-{0}-{1}-{2}-", IP, Port, Name);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType().Equals(GetType()) == false)
            {
                return false;
            }
            StoreNode temp = null;
            temp = (StoreNode)obj;

            return ToString().Equals(temp.ToString());
        }
    }
}

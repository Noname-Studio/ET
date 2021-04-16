namespace Panthea.NativePlugins.IAP
{
    public class IAPKit
    {
        /// <summary>
        /// 目前只接了一个UnityIAP,UnityIAP已经可以处理GooglePlay和Apple Store 两大常见平台了.后续扩展的时候在改成接口
        /// </summary>
        public static UnityIAP Inst { get; private set; }

        public static void Initialize(UnityIAP handler)
        {
            Inst = handler;
        }
    }
}

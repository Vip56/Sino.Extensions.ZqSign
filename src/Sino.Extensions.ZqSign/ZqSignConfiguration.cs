namespace Sino.Extensions.ZqSign
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class ZqSignConfiguration
    {
        /// <summary>
        /// 应用标识码
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 服务地址
        /// </summary>
        public string Url { get; set; }
    }
}

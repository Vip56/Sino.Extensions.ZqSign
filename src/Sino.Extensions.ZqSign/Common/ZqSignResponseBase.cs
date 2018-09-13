using Newtonsoft.Json;

namespace Sino.Extensions.ZqSign
{
    /// <summary>
    /// 回应基础类
    /// </summary>
    public class ZqSignResponseBase
    {
        /// <summary>
        /// 回应代码，具体错误参见ErrorCode
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 回应消息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}

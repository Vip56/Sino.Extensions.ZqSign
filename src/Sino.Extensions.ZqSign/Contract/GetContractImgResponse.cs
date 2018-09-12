using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取合同图片地址回应
    /// </summary>
    public class GetContractImgResponse: ZqSignResponseBase
    {
        /// <summary>
        /// 图片地址数组
        /// </summary>
        [JsonProperty("imgList")]
        public List<string> ImageList { get; set; }
    }
}

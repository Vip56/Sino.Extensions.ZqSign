using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取App签署页
    /// </summary>
    public class GetAppShowResponse: ZqSignResponseBase
    {
        /// <summary>
        /// 关键字页数
        /// </summary>
        [JsonProperty("keyword_page")]
        public string PageNumber { get; set; }

        /// <summary>
        /// 合同图片数组
        /// </summary>
        [JsonProperty("contract_img_path")]
        public string[] ContractImagePath { get; set; }

        /// <summary>
        /// 合同创建时间
        /// </summary>
        [JsonProperty("generator_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [JsonProperty("no")]
        public string ContractId { get; set; }

        /// <summary>
        /// 签署人编号
        /// </summary>
        [JsonProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 签署人名称
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [JsonProperty("contract_name")]
        public string ContractName { get; set; }
        
        /// <summary>
        /// 合同创建方名称
        /// </summary>
        [JsonProperty("generator")]
        public string CreateName { get; set; }

        /// <summary>
        /// 签章Base64图片
        /// </summary>
        [JsonProperty("signature_img")]
        public string SignImage { get; set; }

        /// <summary>
        /// 关键字相对坐标X
        /// </summary>
        [JsonProperty("x")]
        public string X { get; set; }

        /// <summary>
        /// 关键字相对坐标Y
        /// </summary>
        [JsonProperty("y")]
        public string Y { get; set; }

        /// <summary>
        /// 签署人手机号
        /// </summary>
        public string Mobile { get; set; }
    }
}

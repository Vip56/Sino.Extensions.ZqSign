using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取合同PDF
    /// </summary>
    public class GetContractPdfResponse: ZqSignResponseBase
    {
        /// <summary>
        /// 路径
        /// </summary>
        [JsonProperty("pdfUrl")]
        public string Path { get; set; }
    }
}

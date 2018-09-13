using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取App签署页
    /// </summary>
    public class GetAppShowRequest: ZqSignRequestBase<GetAppShowRequest>
    {
        /// <summary>
        /// 签署人
        /// </summary>
        [UrlProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }
    }
}

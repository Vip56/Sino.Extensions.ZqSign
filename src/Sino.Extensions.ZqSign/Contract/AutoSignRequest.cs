using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 自动签署
    /// </summary>
    public class AutoSignRequest: ZqSignRequestBase<AutoSignRequest>
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }

        /// <summary>
        /// 合同签署人
        /// </summary>
        [UrlProperty("signers")]
        public string Signers { get; set; }
    }
}

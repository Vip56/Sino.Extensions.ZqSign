using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 合同生效标记
    /// </summary>
    public class CompletionContractRequest: ZqSignRequestBase<CompletionContractRequest>
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }
    }
}

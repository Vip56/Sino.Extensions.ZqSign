using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取合同PDF地址
    /// </summary>
    public class GetContractPdfRequest: ZqSignRequestBase<GetContractPdfRequest>
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }
    }
}

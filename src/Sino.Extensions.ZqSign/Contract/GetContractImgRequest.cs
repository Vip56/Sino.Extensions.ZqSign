using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取合同图片地址
    /// </summary>
    public class GetContractImgRequest: ZqSignRequestBase<GetContractImgRequest>
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }
    }
}

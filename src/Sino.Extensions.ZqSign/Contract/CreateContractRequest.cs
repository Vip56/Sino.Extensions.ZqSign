using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 创建合同
    /// </summary>
    public class CreateContractRequest: ZqSignRequestBase<CreateContractRequest>
    {
        /// <summary>
        /// 模板编号
        /// </summary>
        [UrlProperty("t_no")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }

        /// <summary>
        /// 合同模板参数
        /// </summary>
        [UrlProperty("contract_val")]
        public string ContractVal { get; set; }

        /// <summary>
        /// 合同名
        /// </summary>
        [UrlProperty("name")]
        public string Name { get; set; }
    }
}

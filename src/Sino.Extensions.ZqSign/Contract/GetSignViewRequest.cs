using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 获取页面签署地址
    /// </summary>
    public class GetSignViewRequest: ZqSignRequestBase<GetSignViewRequest>
    {
        /// <summary>
        /// 合同号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }

        /// <summary>
        /// 签署人编号
        /// </summary>
        [UrlProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 签署类型
        /// </summary>
        [UrlProperty("sign_type")]
        public string SignType { get; set; }

        /// <summary>
        /// 异步回调地址
        /// </summary>
        [UrlProperty("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 同步回调地址
        /// </summary>
        [UrlProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
}

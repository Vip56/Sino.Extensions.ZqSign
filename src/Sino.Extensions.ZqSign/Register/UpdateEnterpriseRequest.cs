using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Register
{
    /// <summary>
    /// 企业用户更新数字证书
    /// </summary>
    public class UpdateEnterpriseRequest: ZqSignRequestBase<UpdateEnterpriseRequest>
    {
        /// <summary>
        /// 标识符
        /// </summary>
        [UrlProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [UrlProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 企业机构代码
        /// </summary>
        [UrlProperty("certificate")]
        public string Certificate { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [UrlProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 企业联系人
        /// </summary>
        [UrlProperty("contact")]
        public string Contact { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [UrlProperty("mobile")]
        public string Mobile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Register
{
    /// <summary>
    /// 个人用户更新数字证书
    /// </summary>
    public class UpdatePersonRequest: ZqSignRequestBase<UpdatePersonRequest>
    {
        /// <summary>
        /// 标识符
        /// </summary>
        [UrlProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [UrlProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [UrlProperty("id_card_no")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [UrlProperty("mobile")]
        public string Mobile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign
{
    public class ErrorCode
    {
        /// <summary>
        /// 调用成功
        /// </summary>
        public const string Success = "0";

        /// <summary>
        /// 参数签名验签不通过
        /// </summary>
        public const string SignatureError = "300000";

        /// <summary>
        /// name格式不正确，支持汉字
        /// </summary>
        public const string NameFormatError = "110001";

        /// <summary>
        /// UserCode已存在，无法推送
        /// </summary>
        public const string UserCodeExisted = "120000";

        /// <summary>
        /// 合同号已存在
        /// </summary>
        public const string ContractIdExisted = "120001";

        /// <summary>
        /// UserCode不存在，无法推送
        /// </summary>
        public const string UserCodeNotExisted = "130000";

        /// <summary>
        /// 合同模板不存在
        /// </summary>
        public const string TemplateIdNotExisted = "130006";
    }
}

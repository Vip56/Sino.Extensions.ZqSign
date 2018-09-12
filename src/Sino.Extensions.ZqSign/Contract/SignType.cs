using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 签署类型
    /// </summary>
    public class SignType
    {
        /// <summary>
        /// 签章不验证签署
        /// </summary>
        public const string SIGNATURE = "SIGNATURE";

        /// <summary>
        /// 签章验证签署
        /// </summary>
        public const string SIGNATURECODE = "SIGNATURECODE";

        /// <summary>
        /// 手写不验证签署（默认）
        /// </summary>
        public const string WRITTEN = "WRITTEN";

        /// <summary>
        /// 手写验证签署
        /// </summary>
        public const string WRITTENCODE = "WRITTENCODE";

        /// <summary>
        /// 短信验证签署
        /// </summary>
        public const string CODE = "CODE";
    }
}

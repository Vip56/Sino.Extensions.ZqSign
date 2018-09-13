using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Register
{
    /// <summary>
    /// 上传图片更换签章
    /// </summary>
    public class ChangeSignatureRequest: ZqSignRequestBase<ChangeSignatureRequest>
    {
        /// <summary>
        /// 标识符
        /// </summary>
        [UrlProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 签章图片（BASE64，支持JPG,BMP,PNG,GIF,TIFF）
        /// </summary>
        [UrlProperty("signature")]
        public string SignatureImage { get; set; }
    }
}

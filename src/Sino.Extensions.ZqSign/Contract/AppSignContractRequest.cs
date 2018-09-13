using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// App签署
    /// </summary>
    public class AppSignContractRequest : ZqSignRequestBase<AppSignContractRequest>
    {
        /// <summary>
        /// 签署人
        /// </summary>
        [UrlProperty("user_code")]
        public string UserCode { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }

        /// <summary>
        /// 签字页数
        /// </summary>
        [UrlProperty("signature_page")]
        public string PageNumber { get; set; }

        /// <summary>
        /// 签字X坐标
        /// </summary>
        [UrlProperty("signature_x")]
        public string X { get; set; }

        /// <summary>
        /// 签字Y坐标
        /// </summary>
        [UrlProperty("signature_y")]
        public string Y { get; set; }

        /// <summary>
        /// 屏幕宽度
        /// </summary>
        [UrlProperty("mobile_width")]
        public string MobileWidth { get; set; }

        /// <summary>
        /// 屏幕高度
        /// </summary>
        [UrlProperty("mobile_height")]
        public string MobileHeight { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        [UrlProperty("sign_img_width")]
        public string ImageWidth { get; set; }

        /// <summary>
        /// 图片高度
        /// </summary>
        [UrlProperty("sign_img_height")]
        public string ImageHeight { get; set; }

        /// <summary>
        /// 图片Base64
        /// </summary>
        [UrlProperty("sign_image")]
        public string ImageBase64 { get; set; }
    }
}

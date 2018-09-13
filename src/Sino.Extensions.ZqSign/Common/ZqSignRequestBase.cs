using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using Sino.Extensions.ZqSign.Utils;
using System.Threading.Tasks;
using System.Net;

namespace Sino.Extensions.ZqSign
{
    public class ZqSignRequestBase<T> where T: class
    {
        /// <summary>
        /// 排除字段
        /// </summary>
        public const string EXCLUDE_PARAMS = "Params";
        public const string EXCLUDE_SIGNATURE = "Signature";

        /// <summary>
        /// 应用标识符
        /// </summary>
        [UrlProperty("zqid")]
        public string AppId { get; set; }

        /// <summary>
        /// 签名值
        /// </summary>
        public string Signature { get; set; }

        public async Task<FormUrlEncodedContent> GetContentAsync(string privateKey)
        {
            var urlattrType = typeof(UrlPropertyAttribute);
            SortedDictionary<string, string> param = new SortedDictionary<string, string>();
            foreach(var propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.Name != EXCLUDE_PARAMS && propertyInfo.Name != EXCLUDE_SIGNATURE)
                {
                    var attrs = propertyInfo.GetCustomAttributes(urlattrType, false);
                    if(attrs.Length > 0)
                    {
                        var attr = attrs[0] as UrlPropertyAttribute;
                        param.Add(attr.PropertyName, propertyInfo.GetValue(this)?.ToString());
                    }
                    else
                    {
                        param.Add(propertyInfo.Name, propertyInfo.GetValue(this)?.ToString());
                    }
                }
            }
            var noSign = new FormUrlEncodedContent(param);
            var encodeContent = await noSign.ReadAsStringAsync();
            var decodeContent = WebUtility.UrlDecode(encodeContent);
            string signval = CryptionUtils.EncryptByPrivateKey(decodeContent, privateKey);
            param.Add("sign_val", signval);

            return new FormUrlEncodedContent(param);
        }
    }
}

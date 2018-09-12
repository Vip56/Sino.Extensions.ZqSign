using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;

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
        public string AppId { get; set; }

        /// <summary>
        /// 签名值
        /// </summary>
        public string Signature { get; set; }

        public FormUrlEncodedContent GetContent()
        {
            var urlattrType = typeof(UrlPropertyAttribute);
            Dictionary<string, string> param = new Dictionary<string, string>();
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

            return new FormUrlEncodedContent(param);
        }
    }
}

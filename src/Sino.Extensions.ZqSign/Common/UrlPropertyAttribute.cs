using System;

namespace Sino.Extensions.ZqSign
{
    /// <summary>
    /// Url参数注解属性
    /// </summary>
    public class UrlPropertyAttribute: Attribute
    {
        public string PropertyName { get; set; }

        public UrlPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}

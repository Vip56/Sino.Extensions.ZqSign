using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Extensions.ZqSign.Contract
{
    public class GetSignViewResponse: ZqSignResponseBase
    {
        /// <summary>
        /// 页面路径
        /// </summary>
        public string Path { get; set; }
    }
}

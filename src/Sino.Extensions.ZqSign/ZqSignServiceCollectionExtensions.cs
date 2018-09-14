using Sino.Extensions.ZqSign;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ZqSignServiceCollectionExtensions
    {
        /// <summary>
        /// 添加电子合同服务
        /// </summary>
        /// <param name="appid">标识符</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="publicKey">公钥（可选）</param>
        /// <param name="url">请求路径</param>
        public static IServiceCollection AddZqSignService(this IServiceCollection services, string appid, string privateKey, string publicKey, string url)
        {
            services.AddSingleton<IZqSignService>(new ZqSignService(new ZqSignConfiguration
            {
                AppId = appid,
                PrivateKey = privateKey,
                PublicKey = publicKey,
                Url = url
            }));
            return services;
        }
    }
}

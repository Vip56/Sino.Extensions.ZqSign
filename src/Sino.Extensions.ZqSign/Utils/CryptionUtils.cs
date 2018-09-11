using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using System;
using System.Text;

namespace Sino.Extensions.ZqSign.Utils
{
    public static class CryptionUtils
    {
        /// <summary>
        /// 利用私钥对内容进行加密
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="key">私钥</param>
        /// <returns>加密后的内容</returns>
        public static string EncryptByPrivateKey(string content, string key)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException(nameof(content));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            var contentBytes = Encoding.UTF8.GetBytes(content);
            var keyBytes = Convert.FromBase64String(key);
            var keyParam = PrivateKeyFactory.CreateKey(keyBytes);

            var signer = new RsaDigestSigner(new Sha1Digest());
            signer.Init(true, keyParam);
            signer.BlockUpdate(contentBytes, 0, contentBytes.Length);

            var resultBytes = signer.GenerateSignature();
            return Convert.ToBase64String(resultBytes);
        }
    }
}

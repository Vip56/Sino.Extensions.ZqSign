using Newtonsoft.Json;
using Sino.Extensions.ZqSign.Contract;
using Sino.Extensions.ZqSign.Register;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Extensions.ZqSign
{
    /// <summary>
    /// 众签服务
    /// </summary>
    public class ZqSignService: IZqSignService
    {
        protected HttpClient Http { get; set; }

        protected string AppId { get; set; }

        protected string PrivateKey { get; set; }

        protected string PublicKey { get; set; }

        protected string Url { get; set; }

        public ZqSignService(ZqSignConfiguration config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (string.IsNullOrEmpty(config.AppId))
                throw new ArgumentNullException(nameof(config.AppId));
            if (string.IsNullOrEmpty(config.PrivateKey))
                throw new ArgumentNullException(nameof(config.PrivateKey));
            if (string.IsNullOrEmpty(config.Url))
                throw new ArgumentNullException(nameof(config.Url));

            AppId = config.AppId;
            PrivateKey = config.PrivateKey;
            PublicKey = config.PublicKey;
            Url = config.Url;

            // 防止HttpClientBug忽略DNS刷新
            var sp = ServicePointManager.FindServicePoint(new Uri(Url));
            sp.ConnectionLeaseTimeout = 60 * 1000;

            Http = new HttpClient();
            Http.Timeout= new TimeSpan(0, 3, 0); //超时时间
        }

        public async Task<O> GetResponseAsync<O, I>(string path, ZqSignRequestBase<I> request, bool useString = false) where I : class where O: ZqSignResponseBase
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.AppId = AppId;

            string requestUrl = Url + path;
            HttpContent content = null;
            if (useString)
            {
                content = await request.GetStringContentAsync(PrivateKey);
            }
            else
            {
                content = await request.GetContentAsync(PrivateKey);
            }
            var response = await Http.PostAsync(requestUrl, content);
            if(response.IsSuccessStatusCode)
            {
                string strContent = string.Empty;
                using (StreamReader reader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                {
                    strContent = reader.ReadToEnd();
                }
                return JsonConvert.DeserializeObject<O>(strContent);
            }
            return null;
        }

        #region IZqSignService

        public async Task<ZqSignResponseBase> RegisterPersonAsync(RegisterPersonRequest request)
        {
            const string path = "personReg";
            var response = await GetResponseAsync<ZqSignResponseBase, RegisterPersonRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> RegisterEnterpriseAsync(RegisterEnterpriseRequest request)
        {
            const string path = "entpReg";
            var response = await GetResponseAsync<ZqSignResponseBase, RegisterEnterpriseRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> UpdatePersonAsync(UpdatePersonRequest request)
        {
            const string path = "personUpdate";
            var response = await GetResponseAsync<ZqSignResponseBase, UpdatePersonRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> UpdateEnterpriseAsync(UpdateEnterpriseRequest request)
        {
            const string path = "entpUpdate";
            var response = await GetResponseAsync<ZqSignResponseBase, UpdateEnterpriseRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> ChangeSignatureAsync(ChangeSignatureRequest request)
        {
            const string path = "signatureChange";
            var response = await GetResponseAsync<ZqSignResponseBase, ChangeSignatureRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> CreateContractAsync(CreateContractRequest request)
        {
            const string path = "pdfTemplate";
            var response = await GetResponseAsync<ZqSignResponseBase, CreateContractRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> AutoSignAsync(AutoSignRequest request)
        {
            const string path = "signAuto";
            var response = await GetResponseAsync<ZqSignResponseBase, AutoSignRequest>(path, request);
            return response;
        }

        public async Task<GetSignViewResponse> GetSignViewAsync(GetSignViewRequest request)
        {
            const string path = "mobileSignView";

            request.AppId = AppId;
            var content = await request.GetContentAsync(PrivateKey);
            var queryString = await content.ReadAsStringAsync();

            var response = new GetSignViewResponse
            {
                Path = Url + path + "?" + queryString,
                Code = "0"
            };

            return response;
        }

        public async Task<ZqSignResponseBase> UndoContractAsync(UndoContractRequest request)
        {
            const string path = "undoSign";
            var response = await GetResponseAsync<ZqSignResponseBase, UndoContractRequest>(path, request);
            return response;
        }

        public async Task<GetContractImgResponse> GetContractImgAsync(GetContractImgRequest request)
        {
            const string path = "getImg";
            var response = await GetResponseAsync<GetContractImgResponse, GetContractImgRequest>(path, request);
            return response;
        }

        public async Task<GetContractPdfResponse> GetContractPdfAsync(GetContractPdfRequest request)
        {
            const string path = "getPdfUrl";
            var response = await GetResponseAsync<GetContractPdfResponse, GetContractPdfRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> CompletionContractAsync(CompletionContractRequest request)
        {
            const string path = "completionContract";
            var response = await GetResponseAsync<ZqSignResponseBase, CompletionContractRequest>(path, request);
            return response;
        }

        public async Task<ZqSignResponseBase> AppSignContractAsync(AppSignContractRequest request)
        {
            const string path = "appSignContract";
            var response = await GetResponseAsync<ZqSignResponseBase, AppSignContractRequest>(path, request, true);
            return response;
        }

        public async Task<GetAppShowResponse> GetAppShowAsync(GetAppShowRequest request)
        {
            const string path = "appShowView";
            var response = await GetResponseAsync<GetAppShowResponse, GetAppShowRequest>(path, request);
            return response;
        }

        #endregion
    }
}

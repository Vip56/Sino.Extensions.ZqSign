using Sino.Extensions.ZqSign.Contract;
using Sino.Extensions.ZqSign.Register;
using System.Threading.Tasks;

namespace Sino.Extensions.ZqSign
{
    /// <summary>
    /// 众签服务接口
    /// </summary>
    public interface IZqSignService
    {
        /// <summary>
        /// 个人用户颁发数字证书
        /// </summary>
        Task<ZqSignResponseBase> RegisterPersonAsync(RegisterPersonRequest request);

        /// <summary>
        /// 企业用户颁发数字证书
        /// </summary>
        Task<ZqSignResponseBase> RegisterEnterpriseAsync(RegisterEnterpriseRequest request);

        /// <summary>
        /// 个人用户更新数字证书
        /// </summary>
        Task<ZqSignResponseBase> UpdatePersonAsync(UpdatePersonRequest request);

        /// <summary>
        /// 企业用户更新数字证书
        /// </summary>
        Task<ZqSignResponseBase> UpdateEnterpriseAsync(UpdateEnterpriseRequest request);

        /// <summary>
        /// 上传图片更换签章
        /// </summary>
        Task<ZqSignResponseBase> ChangeSignatureAsync(ChangeSignatureRequest request);

        /// <summary>
        /// 创建合同
        /// </summary>
        Task<ZqSignResponseBase> CreateContractAsync(CreateContractRequest request);

        /// <summary>
        /// 自动签署
        /// </summary>
        Task<ZqSignResponseBase> AutoSignAsync(AutoSignRequest request);

        /// <summary>
        /// 获取页面签署地址
        /// </summary>
        Task<GetSignViewResponse> GetSignViewAsync(GetSignViewRequest request);

        /// <summary>
        /// App签署
        /// </summary>
        Task<ZqSignResponseBase> AppSignContractAsync(AppSignContractRequest request);

        /// <summary>
        /// 获取App签署页
        /// </summary>
        Task<GetAppShowResponse> GetAppShowAsync(GetAppShowRequest request);

        /// <summary>
        /// 撤销合同
        /// </summary>
        Task<ZqSignResponseBase> UndoContractAsync(UndoContractRequest request);

        /// <summary>
        /// 合同生效
        /// </summary>
        Task<ZqSignResponseBase> CompletionContractAsync(CompletionContractRequest request);

        /// <summary>
        /// 获取合同图片地址
        /// </summary>
        Task<GetContractImgResponse> GetContractImgAsync(GetContractImgRequest request);

        /// <summary>
        /// 获取合同PDF路径
        /// </summary>
        Task<GetContractPdfResponse> GetContractPdfAsync(GetContractPdfRequest request);
    }
}

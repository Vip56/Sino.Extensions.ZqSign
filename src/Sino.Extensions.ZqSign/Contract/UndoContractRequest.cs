namespace Sino.Extensions.ZqSign.Contract
{
    /// <summary>
    /// 撤销合同
    /// </summary>
    public class UndoContractRequest: ZqSignRequestBase<UndoContractRequest>
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        [UrlProperty("no")]
        public string ContractId { get; set; }
    }
}

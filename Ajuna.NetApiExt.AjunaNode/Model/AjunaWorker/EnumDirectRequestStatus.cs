using Ajuna.NetApi.Model.Types.Base;


namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum DirectRequestStatus
    {
        Ok,
        TrustedOperationStatus,
        Error,
    }

    public sealed class EnumDirectRequestStatus : BaseEnumExt<DirectRequestStatus, BaseVoid, EnumTrustedOperationStatus, BaseVoid>
    {
    }

}

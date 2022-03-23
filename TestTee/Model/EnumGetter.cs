using Ajuna.NetApi.Model.Types.Base;


namespace Ajuna.NetApi.Model.AjunaWorker
{
    public enum Getter
    {
        TeePublic,
        Trusted
    }

    public sealed class EnumGetter : BaseEnumExt<Getter, EnumPublicGetter, TrustedGetterSigned>
    {
    }
}

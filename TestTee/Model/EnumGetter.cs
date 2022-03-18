using Ajuna.NetApi.Model.Types.Base;


namespace Ajuna.NetApi.Model.AjunaWorker
{

    public enum Getter
    {
        teePublic,
        trusted
    }

    public sealed class EnumGetter : BaseEnumExt<Getter, EnumPublicGetter, TrustedGetterSigned>
    {
    }
}

using System.ComponentModel;

namespace Verrassingskalender_Api.Models.Enums
{
    public enum CellContent
    {
        [Description("NoPrize")]
        NoPrize,
        [Description("ConsolationPrize")]
        ConsolationPrize,
        [Description("GrandPrize")]
        GrandPrize
    }
}

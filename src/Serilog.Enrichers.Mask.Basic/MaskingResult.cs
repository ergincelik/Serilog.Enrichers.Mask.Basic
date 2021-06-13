namespace Serilog.Enrichers.Mask.Basic
{
    public struct MaskingResult
    {
        public bool Match { get; set; }
        public string Result { get; set; }

        public static MaskingResult NoMatch => new MaskingResult { Match = false };
    }
}

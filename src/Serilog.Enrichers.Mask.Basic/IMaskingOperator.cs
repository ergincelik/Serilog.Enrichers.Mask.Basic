namespace Serilog.Enrichers.Mask.Basic
{
    public interface IMaskingOperator
    {
        MaskingResult Mask(string input, string mask);
    }
}

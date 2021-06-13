using Serilog.Configuration;

namespace Serilog.Enrichers.Mask.Basic
{
    public static class ExtensionMethods
    {
        public static LoggerConfiguration WithMasking(this LoggerEnrichmentConfiguration loggerConfiguration)
        {
            return loggerConfiguration.With(new SensitiveDataEnricher());
        }
    }
}

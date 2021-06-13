using Serilog.Core;
using Serilog.Events;
using Serilog.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Serilog.Enrichers.Mask.Basic
{
    internal class SensitiveDataEnricher : ILogEventEnricher
    {
        private const string MaskValue = "***MASKED***";

        private static readonly MessageTemplateParser Parser = new MessageTemplateParser();
        private readonly FieldInfo _messageTemplateBackingField;

        public SensitiveDataEnricher()
        {
            FieldInfo[] fields = typeof(LogEvent).GetFields(bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic);

            _messageTemplateBackingField = fields.SingleOrDefault(f => f.Name.Contains("<MessageTemplate>"));
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var messageTemplateText = ReplaceSensitiveDataFromString(logEvent.MessageTemplate.Text);

            _messageTemplateBackingField.SetValue(logEvent, Parser.Parse(messageTemplateText));

            foreach (var property in logEvent.Properties.ToList())
            {
                if (property.Value is ScalarValue scalar && scalar.Value is string stringValue)
                {
                    logEvent.AddOrUpdateProperty(
                        new LogEventProperty(
                            property.Key,
                            new ScalarValue(ReplaceSensitiveDataFromString(stringValue))));
                }
            }
        }

        private string ReplaceSensitiveDataFromString(string input)
        {
            foreach (var maskingOperator in DefaultOperators)
            {
                var maskResult = maskingOperator.Mask(input, MaskValue);

                if (maskResult.Match)
                {
                    input = maskResult.Result;
                }
            }

            return input;
        }

        public static IEnumerable<IMaskingOperator> DefaultOperators => new List<IMaskingOperator>
        {
            new EmailAddressMaskingOperator(),
            new IbanMaskingOperator(),
            new CreditCardMaskingOperator()
        };
    }
}

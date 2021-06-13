# Serilog Mask Basic [![NuGet](https://img.shields.io/nuget/v/Serilog.Enrichers.Mask.Basic)](https://www.nuget.org/packages/Serilog.Enrichers.Mask.Basic/)

This package makes it masking Email, Iban and Credit Card for Serilog


## Enabling the module:

Install from NuGet:

```powershell
Install-Package Serilog.Enrichers.Mask.Basic
```

Modify logger configuration:

```csharp
var log = new LoggerConfiguration()
    ....
    .Enrich.WithMasking()
    .CreateLogger();
```

There are 3 operator

```csharp
new EmailAddressMaskingOperator();
new IbanMaskingOperator();
new CreditCardMaskingOperator();
```

namespace Serilog.Enrichers.Mask.Basic.Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            Log.Information("Hello, world");

            // An e-mail address in text
            Log.Information("This is a secret email address: test.baz@mailinator.com");

            // Works for properties too
            Log.Information("This is a secret email address: {Email}", "test.baz@mailinator.com");

            // IBANs are also masked
            Log.Information("Bank transfer from Felix Leiter on PL02ABNA0123456789");

            // IBANs are also masked
            Log.Information("Bank transfer from Felix Leiter on {BankAccount}", "PL02ABNA0123456789");

            // Credit card numbers too
            Log.Information("Credit Card Number: 5111111111111111");
        }
    }
}

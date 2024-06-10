namespace Bookify.Domain.Shared;

public record Currency
{
    public string Code { get; init; }

    private Currency(string code)
    {
        Code = code;
    }

    public static readonly Currency Usd = new Currency("USD");
    public static readonly Currency Eur = new Currency("EUR");
    internal static readonly Currency None = new Currency(""); // hiding from outside of domain assembly

    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Eur
    };

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(e => e.Code == code) ??
               throw new ApplicationException("The currency code is invalid");
    }
}
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

public sealed class Apartment : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    // Address
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }

    // Price
    public decimal PriceAmount { get; private set; }
    public string PriceCurrency { get; private set; }

    // Cleaning Fee
    public decimal CleaningFeeAmount { get; private set; }
    public string CleaningFeeCurrency { get; private set; }

    public DateTime? LastBookedOnUtc { get; private set; }

    public List<Amenity> Amenities { get; private set; } = new();

    public Apartment(Guid id) : base(id)
    {
    }
}
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings
{
    public class PricingService
    {
        public PricingDetail CalculatePrice(Apartment apartment, DateRange period)
        {
            var currency = apartment.Price.Currency;
            var oneDayAmount = apartment.Price.Amount;

            var priceForPeriod = new Money(oneDayAmount * period.LengthInDays, currency);

            decimal percentageUpCharge = 0;
            foreach (var amenity in apartment.Amenities)
            {
                //switch (amenity)
                //{
                //    case Amenity.GardenView or Amenity.MountainView:
                //        percentageUpCharge += 0.05m;
                //        break;
                //    case Amenity.AirConditioning:
                //    case Amenity.Parking:
                //        percentageUpCharge += 0.01m;
                //        break;
                //    default:
                //        percentageUpCharge += 0;
                //        break;
                //}

                percentageUpCharge += amenity switch
                {
                    Amenity.GardenView or Amenity.MountainView => 0.05m,
                    Amenity.AirConditioning => 0.01m,
                    Amenity.Parking => 0.01m,
                    _ => 0
                };
            }

            var amenitiesUpCharge = Money.Zero(currency);
            if (percentageUpCharge > 0)
            {
                amenitiesUpCharge = new Money(priceForPeriod.Amount * percentageUpCharge, currency);
            }

            var cleaningFee = Money.Zero(currency);
            if (!apartment.CleaningFee.IsZero())
            {
                cleaningFee = apartment.CleaningFee;
            }

            var totalPrice = Money.Zero(currency);
            totalPrice += amenitiesUpCharge;
            totalPrice += priceForPeriod;
            totalPrice += cleaningFee;

            return new PricingDetail(priceForPeriod, cleaningFee, amenitiesUpCharge, totalPrice);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NoInterface.Entites;

namespace NoInterface.Services
{
     class RentalService
    {

        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private BrazilTaxServices _brazilTaxServices = new BrazilTaxServices();

        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInovice(CarRental carRental)
        {
            TimeSpan duration = carRental.finish.Subtract(carRental.start);

            double basicpayment = 0.0;
            if(duration.TotalHours <= 12.0)
            {
                basicpayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            } else
            {
                basicpayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brazilTaxServices.Tax(basicpayment);

            carRental.Invoice = new Invoice(basicpayment, tax);
        }
    }
}

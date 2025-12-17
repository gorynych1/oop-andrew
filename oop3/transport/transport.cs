using System;
namespace PassengerTransport
{
    public abstract class Transport
    {
        public string RouteName { get; }
        protected Transport(string routeName)
        {
            RouteName = routeName;
        }
        public abstract decimal CalculateRevenue();
    }
    public class Bus : Transport
    {
        public int PassengerCount { get; }
        public int DiscountPassengers { get; }
        public decimal TicketPrice { get; }
        public decimal DiscountCoefficient { get; }
        public Bus(string routeName, int passengerCount, int discountPassengers,
                   decimal ticketPrice, decimal discountCoefficient)
            : base(routeName)
        {
            PassengerCount = passengerCount;
            DiscountPassengers = discountPassengers;
            TicketPrice = ticketPrice;
            DiscountCoefficient = discountCoefficient;
        }
        public override decimal CalculateRevenue()
        {
            int fullPricePassengers = PassengerCount - DiscountPassengers;
            return fullPricePassengers * TicketPrice +
                   DiscountPassengers * TicketPrice * DiscountCoefficient;
        }
    }
    public class Taxi : Transport
    {
        public decimal DistanceKm { get; }
        public decimal PricePerKm { get; }
        public Taxi(string routeName, decimal distanceKm, decimal pricePerKm)
            : base(routeName)
        {
            DistanceKm = distanceKm;
            PricePerKm = pricePerKm;
        }
        public override decimal CalculateRevenue()
        {
            return DistanceKm * PricePerKm;
        }
    }

    public class Train : Transport
    {
        public int PassengerCount { get; }
        public decimal TicketPrice { get; }
        public Train(string routeName, int passengerCount, decimal ticketPrice)
            : base(routeName)
        {
            PassengerCount = passengerCount;
            TicketPrice = ticketPrice;
        }
        public override decimal CalculateRevenue()
        {
            return PassengerCount * TicketPrice;
        }
    }
}
using NUnit.Framework;
using PassengerTransport;

namespace TransportTests
{
    [TestFixture]
    public class TransportRevenueTests
    {
        [Test] public void Bus_Revenue_Without_Discounts() =>
            Assert.AreEqual(1000, new Bus("A", 20, 0, 50, 0.5m).CalculateRevenue());

        [Test] public void Bus_Revenue_With_Discounts() =>
            Assert.AreEqual(750, new Bus("A", 20, 10, 50, 0.5m).CalculateRevenue());

        [Test] public void Taxi_Revenue_Simple() =>
            Assert.AreEqual(300, new Taxi("B", 10, 30).CalculateRevenue());

        [Test] public void Taxi_Zero_Distance() =>
            Assert.AreEqual(0, new Taxi("B", 0, 30).CalculateRevenue());

        [Test] public void Train_Revenue_Simple() =>
            Assert.AreEqual(2000, new Train("C", 100, 20).CalculateRevenue());

        [Test] public void Train_No_Passengers() =>
            Assert.AreEqual(0, new Train("C", 0, 20).CalculateRevenue());

        [Test] public void Bus_All_Discount_Passengers() =>
            Assert.AreEqual(500, new Bus("A", 20, 20, 50, 0.5m).CalculateRevenue());

        [Test] public void Taxi_Fractional_Distance() =>
            Assert.AreEqual(75, new Taxi("B", 2.5m, 30).CalculateRevenue());

        [Test] public void Bus_Single_Passenger() =>
            Assert.AreEqual(50, new Bus("A", 1, 0, 50, 0.5m).CalculateRevenue());

        [Test] public void Train_Single_Passenger() =>
            Assert.AreEqual(30, new Train("C", 1, 30).CalculateRevenue());
    }
}
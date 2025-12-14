using NUnit.Framework;
using BankCredits;

namespace CreditTests
{
    [TestFixture]
    public class CreditCalculationTests
    {
        [Test] public void BankEmployee_Limit() =>
            Assert.AreEqual(200000, new BankEmployee(10000).CalculateCreditLimit());

        [Test] public void BankEmployee_Rate() =>
            Assert.AreEqual(5, new BankEmployee(10000).CalculateInterestRate());

        [Test] public void RegularClient_Limit() =>
            Assert.AreEqual(100000, new RegularClient(10000).CalculateCreditLimit());

        [Test] public void RegularClient_Rate() =>
            Assert.AreEqual(12, new RegularClient(10000).CalculateInterestRate());

        [Test] public void BadHistory_Limit() =>
            Assert.AreEqual(30000, new BadCreditHistoryClient(10000).CalculateCreditLimit());

        [Test] public void BadHistory_Rate() =>
            Assert.AreEqual(25, new BadCreditHistoryClient(10000).CalculateInterestRate());

        [Test] public void Privileged_Limit() =>
            Assert.AreEqual(80000, new PrivilegedClient(10000).CalculateCreditLimit());

        [Test] public void Privileged_Rate() =>
            Assert.AreEqual(8, new PrivilegedClient(10000).CalculateInterestRate());

        [Test] public void Zero_Income_Limit() =>
            Assert.AreEqual(0, new RegularClient(0).CalculateCreditLimit());

        [Test] public void Zero_Income_Rate() =>
            Assert.AreEqual(12, new RegularClient(0).CalculateInterestRate());
    }
}
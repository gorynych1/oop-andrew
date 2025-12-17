namespace BankCredits
{
    public abstract class Client
    {
        public decimal MonthlyIncome { get; }
        protected Client(decimal monthlyIncome)
        {
            MonthlyIncome = monthlyIncome;
        }
        public abstract decimal CalculateCreditLimit();
        public abstract decimal CalculateInterestRate();
    }
    public class BankEmployee : Client
    {
        public BankEmployee(decimal income) : base(income) { }

        public override decimal CalculateCreditLimit() => MonthlyIncome * 20;
        public override decimal CalculateInterestRate() => 5;
    }
    public class RegularClient : Client
    {
        public RegularClient(decimal income) : base(income) { }
        public override decimal CalculateCreditLimit() => MonthlyIncome * 10;
        public override decimal CalculateInterestRate() => 12;
    }
    public class BadCreditHistoryClient : Client
    {
        public BadCreditHistoryClient(decimal income) : base(income) { }
        public override decimal CalculateCreditLimit() => MonthlyIncome * 3;
        public override decimal CalculateInterestRate() => 25;
    }
    public class PrivilegedClient : Client
    {
        public PrivilegedClient(decimal income) : base(income) { }
        public override decimal CalculateCreditLimit() => MonthlyIncome * 8;
        public override decimal CalculateInterestRate() => 8;
    }
}
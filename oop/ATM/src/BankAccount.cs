using System;

namespace ATM
{
    public abstract class BankAccount
    {
        public decimal Money { get; protected set; }
        public static decimal TotalBalance { get; protected set; }
        public string AccountNumber { get; protected set; }

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            Money = 0;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной");
            
            Money += amount;
            TotalBalance += amount;
            Console.WriteLine($"📥 Пополнение: +{amount:C}. Баланс: {Money:C}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной");
            if (amount > 30000)
                throw new InvalidOperationException("Нельзя снять более 30000 за операцию");
            if (amount > Money)
                throw new InvalidOperationException("Недостаточно средств");

            Money -= amount;
            TotalBalance -= amount;
            Console.WriteLine($"📤 Снятие: -{amount:C}. Баланс: {Money:C}");
        }

        public virtual void Transfer(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
                throw new ArgumentNullException(nameof(targetAccount));

            Withdraw(amount);
            targetAccount.Deposit(amount);
            Console.WriteLine($"🔄 Перевод {amount:C} на счет {targetAccount.AccountNumber}");
        }
    }

    public sealed class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountNumber) : base(accountNumber) { }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);
            
            if (amount > 1000000)
            {
                Console.WriteLine("🎉 Бонус: за крупное пополнение вы получаете 2000 на баланс!");
                Money += 2000;
            }
        }
    }

    public sealed class DebitAccount : BankAccount
    {
        private CreditAccount? linkedCreditAccount;

        public DebitAccount(string accountNumber, CreditAccount? creditAccount = null) 
            : base(accountNumber)
        {
            linkedCreditAccount = creditAccount;
        }

        private void CheckCreditDebt()
        {
            if (linkedCreditAccount != null && linkedCreditAccount.Money < -20000)
            {
                throw new InvalidOperationException(
                    "Запрет на работу с дебетовым счетом при наличии кредитного счета с балансом более минус 20 000");
            }
        }

        public override void Withdraw(decimal amount)
        {            
            CheckCreditDebt();
            base.Withdraw(amount);
        }

        public override void Deposit(decimal amount)
        {
            CheckCreditDebt();
            base.Deposit(amount);
        }

        public override void Transfer(BankAccount targetAccount, decimal amount)
        {
            CheckCreditDebt();
            base.Transfer(targetAccount, amount);
        }

        public void LinkCreditAccount(CreditAccount? creditAccount)
        {
            linkedCreditAccount = creditAccount;
        }
    }

    public sealed class CreditAccount : BankAccount
    {
        public decimal CreditLimit { get; private set; } = -50000;

        public CreditAccount(string accountNumber) : base(accountNumber) { }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной");

            decimal newBalance = Money - amount;
            if (newBalance < CreditLimit)
                throw new InvalidOperationException(
                    $"Превышен кредитный лимит. Максимум: {CreditLimit:C}");

            Money = newBalance;
            TotalBalance -= amount;
            Console.WriteLine($"💳 Снятие с кредитного счета: -{amount:C}. Баланс: {Money:C}");
        }

        public void PayCredit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной");

            Money += amount;
            TotalBalance += amount;
            Console.WriteLine($"✅ Погашение кредита: +{amount:C}. Баланс: {Money:C}");
        }
    }
}
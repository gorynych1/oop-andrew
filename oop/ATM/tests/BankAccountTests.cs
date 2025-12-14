using NUnit.Framework;
using System;
using ATM;

namespace ATMTests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            // Arrange
            var account = new CurrentAccount("TEST-001");
            
            // Act
            account.Deposit(1000);
            
            // Assert
            Assert.AreEqual(1000, account.Money);
        }

        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            // Arrange
            var account = new DebitAccount("TEST-002");
            account.Deposit(5000);
            
            // Act
            account.Withdraw(2000);
            
            // Assert
            Assert.AreEqual(3000, account.Money);
        }

        [Test]
        public void Withdraw_AmountExceedsLimit_ThrowsException()
        {
            // Arrange
            var account = new DebitAccount("TEST-003");
            account.Deposit(40000);
            
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(35000));
        }

        [Test]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            // Arrange
            var account = new DebitAccount("TEST-004");
            account.Deposit(1000);
            
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(2000));
        }

        [Test]
        public void Transfer_ValidAmount_TransfersBetweenAccounts()
        {
            // Arrange
            var account1 = new CurrentAccount("TEST-005");
            var account2 = new DebitAccount("TEST-006");
            account1.Deposit(3000);
            
            // Act
            account1.Transfer(account2, 1500);
            
            // Assert
            Assert.AreEqual(1500, account1.Money);
            Assert.AreEqual(1500, account2.Money);
        }

        [Test]
        public void CreditAccount_WithdrawWithinLimit_WorksCorrectly()
        {
            // Arrange
            var account = new CreditAccount("TEST-007");
            
            // Act
            account.Withdraw(10000);
            
            // Assert
            Assert.AreEqual(-10000, account.Money);
        }

        [Test]
        public void CreditAccount_ExceedCreditLimit_ThrowsException()
        {
            // Arrange
            var account = new CreditAccount("TEST-008");
            
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(60000));
        }

        [Test]
        public void TotalBalance_StaticField_UpdatesCorrectly()
        {
            // Arrange
            var initialBalance = BankAccount.TotalBalance;
            var account1 = new CurrentAccount("TEST-009");
            var account2 = new DebitAccount("TEST-010");
            
            // Act
            account1.Deposit(5000);
            account2.Deposit(3000);
            
            // Assert
            Assert.AreEqual(initialBalance + 8000, BankAccount.TotalBalance);
        }

        [Test]
        public void Deposit_NegativeAmount_ThrowsException()
        {
            // Arrange
            var account = new CurrentAccount("TEST-011");
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(-100));
        }

        // НОВЫЕ ТЕСТЫ
        [Test]
        public void DebitAccount_LinkedCreditBelowMinus20000_BlocksOperations()
        {
            // Arrange
            var creditAcc = new CreditAccount("CREDIT-TEST-001");
            var debitAcc = new DebitAccount("DEBIT-TEST-001", creditAcc);
            creditAcc.Withdraw(25000);
            
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => debitAcc.Withdraw(1000));
        }

        [Test]
        public void DebitAccount_LinkedCreditAboveMinus20000_AllowsOperations()
        {
            // Arrange
            var creditAcc = new CreditAccount("CREDIT-TEST-002");
            var debitAcc = new DebitAccount("DEBIT-TEST-002", creditAcc);
            creditAcc.Withdraw(15000);
            
            // Act
            debitAcc.Deposit(5000);
            
            // Assert
            Assert.AreEqual(5000, debitAcc.Money);
        }

        [Test]
        public void DebitAccount_NoLinkedCreditAccount_WorksNormally()
        {
            // Arrange
            var debitAcc = new DebitAccount("DEBIT-TEST-003");
            var creditAcc = new CreditAccount("CREDIT-TEST-003");
            creditAcc.Withdraw(30000);
            
            // Act
            debitAcc.Deposit(10000);
            debitAcc.Withdraw(3000);
            
            // Assert
            Assert.AreEqual(7000, debitAcc.Money);
        }

        [Test]
        public void DebitAccount_ReLinkCreditAccount_UpdatesRestriction()
        {
            // Arrange
            var creditAcc = new CreditAccount("CREDIT-TEST-004");
            var debitAcc = new DebitAccount("DEBIT-TEST-004");
            debitAcc.Deposit(20000);
            
            // Act 1: Связываем когда кредит нормальный
            creditAcc.Withdraw(10000);
            debitAcc.LinkCreditAccount(creditAcc);
            debitAcc.Withdraw(5000);
            
            // Act 2: Ухудшаем кредит
            creditAcc.Withdraw(20000);
            Assert.Throws<InvalidOperationException>(() => debitAcc.Withdraw(1000));
            
            // Act 3: Отвязываем
            debitAcc.LinkCreditAccount(null);
            debitAcc.Withdraw(5000);
            
            // Assert
            Assert.AreEqual(10000, debitAcc.Money);
        }

        [Test]
        public void CurrentAccount_NeverBlockedByCreditDebt()
        {
            // Arrange
            var creditAcc = new CreditAccount("CREDIT-TEST-005");
            var currentAcc = new CurrentAccount("CURRENT-TEST-001");
            creditAcc.Withdraw(50000);
            
            // Act & Assert
            currentAcc.Deposit(50000);
            currentAcc.Withdraw(20000);
            
            Assert.AreEqual(30000, currentAcc.Money);
        }
    }
}
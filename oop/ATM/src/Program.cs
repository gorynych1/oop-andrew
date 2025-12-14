using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🏦 СИСТЕМА БАНКОМАТА\n");

            try
            {
                Console.WriteLine("=== 1. БАЗОВОЕ ТЕСТИРОВАНИЕ ===");
                
                var creditAcc = new CreditAccount("CREDIT-001");
                var debitAcc = new DebitAccount("DEBIT-001");
                var currentAcc = new CurrentAccount("CURRENT-001");

                currentAcc.Deposit(50000);
                debitAcc.Deposit(100000);
                
                creditAcc.Withdraw(10000);
                
                currentAcc.Deposit(1500000);
                
                debitAcc.Withdraw(25000);
                currentAcc.Transfer(debitAcc, 15000);
                
                creditAcc.PayCredit(5000);

                Console.WriteLine("\n=== 2. ПРОВЕРКА ОГРАНИЧЕНИЙ ===");
                try
                {
                    debitAcc.Withdraw(35000); // Превышение лимита
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✓ Ожидаемая ошибка: {ex.Message}");
                }

                try
                {
                    creditAcc.Withdraw(60000); // Превышение кредитного лимита
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✓ Ожидаемая ошибка: {ex.Message}");
                }
                
                Console.WriteLine("\n=== 3. ТЕСТ НОВОГО ТРЕБОВАНИЯ ===");
                Console.WriteLine("Запрет на работу с дебетовым при кредите < -20 000\n");
                
                var creditAcc2 = new CreditAccount("CREDIT-002");
                var debitAcc2 = new DebitAccount("DEBIT-002", creditAcc2);
                
                Console.WriteLine("1) Сначала кредитный счет > -20 000:");
                creditAcc2.Withdraw(15000);
                debitAcc2.Deposit(50000);
                Console.WriteLine("   ✓ Дебетовый работает нормально");
                
                Console.WriteLine("\n2) Кредитный счет становится < -20 000:");
                creditAcc2.Withdraw(10000);
                
                try
                {
                    debitAcc2.Withdraw(1000);
                    Console.WriteLine("   ✗ ОШИБКА: Не сработала блокировка!");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"   ✓ Дебетовый заблокирован: {ex.Message}");
                }
                
                try
                {
                    debitAcc2.Deposit(5000);
                    Console.WriteLine("   ✗ ОШИБКА: Не сработала блокировка!");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"   ✓ Пополнение тоже заблокировано: {ex.Message}");
                }
                
                Console.WriteLine("\n3) Погашаем кредит до > -20 000:");
                creditAcc2.PayCredit(10000);
                debitAcc2.Withdraw(2000);
                Console.WriteLine("   ✓ Дебетовый снова работает после погашения");
                
                Console.WriteLine("\n4) Отвязываем кредитный счет:");
                debitAcc2.LinkCreditAccount(null);
                creditAcc2.Withdraw(20000);
                debitAcc2.Deposit(3000);
                Console.WriteLine("   ✓ Дебетовый работает без связи с кредитным");
                
                Console.WriteLine("\n5) Привязываем снова и проверяем:");
                debitAcc2.LinkCreditAccount(creditAcc2);
                
                try
                {
                    debitAcc2.Withdraw(1000);
                    Console.WriteLine("   ✗ ОШИБКА: Не сработала блокировка!");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"   ✓ Снова заблокирован после привязки: {ex.Message}");
                }
                
                Console.WriteLine("\n=== 4. ДОПОЛНИТЕЛЬНЫЕ ПРОВЕРКИ ===");
                
                Console.WriteLine("Проверка расчетного счета:");
                var currentAcc2 = new CurrentAccount("CURRENT-002");
                var creditAcc3 = new CreditAccount("CREDIT-003");
                creditAcc3.Withdraw(30000);
                currentAcc2.Deposit(50000);
                currentAcc2.Withdraw(10000);
                Console.WriteLine("   ✓ Расчетный счет работает всегда (не блокируется)");
                
                Console.WriteLine("\nПроверка перевода при блокировке:");
                var creditAcc4 = new CreditAccount("CREDIT-004");
                var debitAcc3 = new DebitAccount("DEBIT-003", creditAcc4);
                debitAcc3.Deposit(20000);
                creditAcc4.Withdraw(25000);
                
                try
                {
                    debitAcc3.Transfer(currentAcc2, 5000);
                    Console.WriteLine("   ✗ ОШИБКА: Перевод не заблокирован!");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"   ✓ Перевод заблокирован: {ex.Message}");
                }
                
                Console.WriteLine($"\n💰 ОБЩИЙ БАЛАНС ВСЕХ СЧЕТОВ: {BankAccount.TotalBalance:C}");
                Console.WriteLine($"📊 Всего операций проверено: успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Критическая ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
using System;

namespace Documents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("📋 СИСТЕМА РАБОТЫ С ДОКУМЕНТАМИ\n");
            Console.WriteLine("Доступные ключи:");
            Console.WriteLine(" - PRO-версия: PRO-12345");
            Console.WriteLine(" - EXPERT-версия: EXP-67890");
            Console.Write("\nВведите ключ доступа (или нажмите Enter для бесплатной версии): ");

            string key = Console.ReadLine();
            DocumentWorker document;

            // Выбор версии на основе ключа
            if (key == "PRO-12345")
            {
                document = new ProDocumentWorker();
                Console.WriteLine("\n✅ Активирована PRO-версия!");
            }
            else if (key == "EXP-67890")
            {
                document = new ExpertDocumentWorker();
                Console.WriteLine("\n🎉 Активирована EXPERT-версия!");
            }
            else
            {
                document = new DocumentWorker();
                Console.WriteLine("\n🆓 Используется бесплатная версия");
            }

            // Работа с документом
            Console.WriteLine("\n--- РАБОТА С ДОКУМЕНТОМ ---");
            document.OpenDocument();
            document.EditDocument();
            document.SaveDocument();

            // Дополнительные операции для демонстрации
            Console.WriteLine("\n--- ДОПОЛНИТЕЛЬНЫЕ ОПЕРАЦИИ ---");
            document.OpenDocument();
            
            // Попытка использовать специфические методы
            if (document is ProDocumentWorker proDoc)
            {
                Console.WriteLine("\n💡 Дополнительные функции PRO:");
                proDoc.EditDocument();
                proDoc.SaveDocument();
            }
            
            if (document is ExpertDocumentWorker expertDoc)
            {
                Console.WriteLine("\n🚀 Дополнительные функции EXPERT:");
                expertDoc.SaveDocument();
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
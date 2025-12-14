using System;

namespace Documents
{
    public class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("📄 Документ открыт");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("⚠️ Редактирование документа доступно в версии Про");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("⚠️ Сохранение документа доступно в версии Про");
        }
    }

    public class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("✏️ Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("💾 Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }

    public class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("🚀 Документ сохранен в новом формате");
        }
        
        public void SaveInAllFormats()
        {
            Console.WriteLine("📚 Документ сохранен во всех поддерживаемых форматах");
        }
    }
}
using NUnit.Framework;
using System;
using System.IO;
using Documents;

namespace DocumentsTests
{
    [TestFixture]
    public class DocumentWorkerTests
    {
        private StringWriter consoleOutput;

        [SetUp]
        public void Setup()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        [TearDown]
        public void TearDown()
        {
            consoleOutput.Dispose();
        }

        [Test]
        public void Test1_DocumentWorker_Methods()
        {
            var document = new DocumentWorker();
            
            document.OpenDocument();
            document.EditDocument();
            document.SaveDocument();

            var output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Документ открыт"));
            Assert.That(output, Does.Contain("Редактирование документа доступно в версии Про"));
            Assert.That(output, Does.Contain("Сохранение документа доступно в версии Про"));
        }

        [Test]
        public void Test2_ProDocumentWorker_Methods()
        {
            var document = new ProDocumentWorker();
            
            document.EditDocument();
            document.SaveDocument();

            var output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Документ отредактирован"));
            Assert.That(output, Does.Contain("Документ сохранен в старом формате"));
        }

        [Test]
        public void Test3_ExpertDocumentWorker_Methods()
        {
            var document = new ExpertDocumentWorker();
            
            document.SaveDocument();

            var output = consoleOutput.ToString();
            Assert.That(output, Does.Contain("Документ сохранен в новом формате"));
        }
    }
}
using System;
using System.IO;
using System.Text;

namespace TextReaderProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ISmartTextReader textReader = new SmartTextReader();

            string testFilePath = Path.Combine(AppContext.BaseDirectory, "test.txt");
            if (!File.Exists(testFilePath))
            {
                File.WriteAllText(testFilePath, "Тестовий файл.\nТекст у тестовому файлі.\n12345678.");
                Console.WriteLine($"Файл {testFilePath} створено.");
            }

            ISmartTextReader checkerProxy = new SmartTextChecker(textReader);
            checkerProxy.ReadTextFile(testFilePath);

            string restrictedFilePath = Path.Combine(AppContext.BaseDirectory, "restricted.txt");
            if (!File.Exists(restrictedFilePath))
            {
                File.WriteAllText(restrictedFilePath, "Це обмежений файл.\nДоступ заборонено.");
                Console.WriteLine($"Файл {restrictedFilePath} створено.");
            }

            ISmartTextReader lockerProxy = new SmartTextReaderLocker(textReader, "restricted.*");
            lockerProxy.ReadTextFile(restrictedFilePath);
            lockerProxy.ReadTextFile(testFilePath);
        }
    }
}
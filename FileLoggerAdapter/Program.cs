using System.Text;

namespace FileLoggerAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ILogger consoleLogger = new Logger();
            consoleLogger.Log("Повiдомлення лога");
            consoleLogger.Error("Повiдомлення помилки");
            consoleLogger.Warn("Попередження");

            FileWriter fileWriter = new FileWriter("log.txt");
            ILogger fileLogger = new FileLoggerAdapter(fileWriter);
            fileLogger.Log("Повiдомлення лога у файл");
            fileLogger.Error("Повiдомлення помилки у файл");
            fileLogger.Warn("Попередження у файл");
        }
    }
}
using System;

namespace TextReaderProxy
{
    public class SmartTextChecker : ISmartTextReader
    {
        private ISmartTextReader _textReader;

        public SmartTextChecker(ISmartTextReader textReader)
        {
            _textReader = textReader;
        }

        public char[][] ReadTextFile(string filePath)
        {
            Console.WriteLine($"Відкриття файлу: {filePath}");
            char[][] result = _textReader.ReadTextFile(filePath);
            Console.WriteLine($"Файл прочитано: {filePath}");
            Console.WriteLine($"Закриття файлу: {filePath}");

            int linesCount = result.Length;
            int charsCount = 0;
            foreach (char[] line in result)
            {
                charsCount += line.Length;
            }

            Console.WriteLine($"Кількість рядків: {linesCount}, кількість символів: {charsCount}");
            return result;
        }
    }
}
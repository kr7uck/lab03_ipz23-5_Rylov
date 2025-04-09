using System;
using System.Text.RegularExpressions;

namespace TextReaderProxy
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private ISmartTextReader _textReader;
        private Regex _accessRegex;

        public SmartTextReaderLocker(ISmartTextReader textReader, string regexPattern)
        {
            _textReader = textReader;
            _accessRegex = new Regex(regexPattern);
        }

        public char[][] ReadTextFile(string filePath)
        {
            if (_accessRegex.IsMatch(filePath))
            {
                Console.WriteLine($"Access denied! Файл {filePath} обмежений.");
                return new char[0][];
            }
            return _textReader.ReadTextFile(filePath);
        }
    }
}
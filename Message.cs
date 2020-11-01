using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab9_RegEx
{
    class Message
    {
        public String Value { get; set; }

        public Message(String value = "")
        {
            Value = value;
        }

        public bool Contains(String word)
        {
            return Regex.IsMatch(Value, @"\b" + word + @"\b", RegexOptions.IgnoreCase);
        }

        public List<String> GetWordsWithLength(int length)
        {
            List<String> words = new List<string>();
            foreach (Match match in Regex.Matches(Value, @"\b\w{" + length + "," + length + @"}\b"))
            {
                words.Add(match.Value);
            }
            return words;
        }

        public void DeleteSingleLetterWords()
        {
            Value = Regex.Replace(Value, @"\b\w\b", "");
        }

        public void DeleteRussianFirstVowelWords()
        {
            Value = Regex.Replace(Value, @"\b[ёуеыаоэяию]\w*\b", "", RegexOptions.IgnoreCase);
        }

        public void ReplaceEnglishWordsByEllipsis()
        {
            Value = Regex.Replace(Value, @"\b[a-z]+\b", "...", RegexOptions.IgnoreCase);
        }

        public double SumUpAllNumbers()
        {
            double sum = 0;
            foreach (Match match in Regex.Matches(Value, @"\b\d+(,\d+)?\b"))
            {
                sum += double.Parse(match.Value);
            }
            return sum;
        }

        public List<String> GetPhoneNumbers()
        {
            List<String> numbers = new List<string>();
            foreach (Match match in Regex.Matches(
                Value, @"(\d{3}\-\d{3})|(\d{2}\-\d{2}\-\d{2})|(\d{3}\-\d{2}\-\d{2})"))
            {
                numbers.Add(match.Value);
            }
            return numbers;
        }

        public List<String> GetCurrentYearDates()
        {
            int currentYear = DateTime.Now.Year;
            List<String> dates = new List<string>();
            foreach (Match match in Regex.Matches(
                Value, @"\b([12]?\d|3[01])\.([1-9]|1[0-2])\." + currentYear + @"\b"))
            {
                dates.Add(match.Value);
            }
            return dates;
        }

        public List<String> GetWebAdresses()
        {
            List<String> adresses = new List<string>();
            foreach (Match match in Regex.Matches(Value, @"\bwww(\.\w+){2,}\b"))
            {
                adresses.Add(match.Value);
            }
            return adresses;
        }

        public void RoundSecInTime()
        {
            Value = Regex.Replace(
                Value,
                @"\b([01]\d|2[0-3])(:[0-5]\d){2}\b",
                (match) => 
                {
                    int hour = int.Parse(match.Value.Substring(0, 2));
                    int min = int.Parse(match.Value.Substring(3, 2));
                    int sec = int.Parse(match.Value.Substring(6, 2));
                    if (sec >= 30)
                    {
                        hour = (hour + (min + 1) / 60) % 24;
                        min = (min + 1) % 60;
                    } 
                    return string.Format("{0:00}:{1:00}", hour, min);
                });
        }
    }
}
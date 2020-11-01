using System;
using System.Linq;

namespace Lab9_RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice = ' ';
            Message message = new Message();
            String buffer;
            Console.WriteLine("*Text Processing With RegEx*");
            do
            {
                Console.WriteLine("\nВыберите пункт меню:\n" +
                    "1) Cодержится ли в сообщении заданное слово.\n" +
                    "2) Вывести все слова заданной длины.\n" +
                    "3) Удалить из сообщения все однобуквенные слова.\n" +
                    "4) Удалить из сообщения русские слова, которые начинаются на гласную букву.\n" +
                    "5) Заменить все английские слова на многоточие.\n" +
                    "6) Найти сумму всех имеющихся в сообщении чисел (целых и вещественных).\n" +
                    "7) Вывести все номера телефонов (xx-xx-xx, xxx-xxx или xxx-xx-xx), которые содержатся в сообщении.\n" +
                    "8) Вывести все даты, которые относятся к текущему году.\n" +
                    "9) Вывести все адреса web-сайтов, содержащиеся в сообщении.\n" +
                    "0) Преобразовать время в формате чч:мм:сс к формату чч:мм.\n" +
                    "E) Выход.\n");
                Console.Write("//> ");
                choice = Console.ReadLine().First();

                switch (choice)
                {
                    case '1':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            Console.Write("Введите искомое слово: ");
                            buffer = Console.ReadLine();
                            if (message.Contains(buffer))
                            {
                                Console.WriteLine("Да, оно есть в сообщении.");
                            } else
                            {
                                Console.WriteLine("Нет, его нет в сообщении.");
                            }
                            break;
                        }
                    case '2':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            int fixedLength;
                            Console.Write("Введите длину слов: ");
                            while (!int.TryParse(Console.ReadLine(), out fixedLength)) ;
                            if (message.GetWordsWithLength(fixedLength).Count == 0)
                            {
                                Console.WriteLine("Таких слов не найдено!");
                            }
                            else
                            {
                                Console.WriteLine("Найдены слова:");
                                foreach (String word in message.GetWordsWithLength(fixedLength))
                                {
                                    Console.WriteLine(word);
                                }
                            }
                            break;
                        }
                    case '3':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            message.DeleteSingleLetterWords();
                            Console.WriteLine("Результирующее сообщение: " + message.Value);
                            break;
                        }
                    case '4':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            message.DeleteRussianFirstVowelWords();
                            Console.WriteLine("Результирующее сообщение: " + message.Value);
                            break;
                        }
                    case '5':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            message.ReplaceEnglishWordsByEllipsis();
                            Console.WriteLine("Результирующее сообщение: " + message.Value);
                            break;
                        }
                    case '6':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            double sum = message.SumUpAllNumbers();
                            Console.WriteLine("искомая сумма: " + sum);
                            break;
                        }
                    case '7':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            if (message.GetPhoneNumbers().Count == 0)
                            {
                                Console.WriteLine("Номеров не найдено!");
                            }
                            else
                            {
                                Console.WriteLine("Найдены номера:");
                                foreach (String word in message.GetPhoneNumbers())
                                {
                                    Console.WriteLine(word);
                                }
                            }
                            break;
                        }
                    case '8':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            if (message.GetCurrentYearDates().Count == 0)
                            {
                                Console.WriteLine("Подходящих дат не найдено!");
                            }
                            else
                            {
                                Console.WriteLine("Найдены даты:");
                                foreach (String word in message.GetCurrentYearDates())
                                {
                                    Console.WriteLine(word);
                                }
                            }
                            break;
                        }
                    case '9':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            if (message.GetWebAdresses().Count == 0)
                            {
                                Console.WriteLine("Адресов web-сайтов не найдено!");
                            }
                            else
                            {
                                Console.WriteLine("Найдены адреса:");
                                foreach (String word in message.GetWebAdresses())
                                {
                                    Console.WriteLine(word);
                                }
                            }
                            break;
                        }
                    case '0':
                        {
                            Console.Write("Введите сообщение: ");
                            message.Value = Console.ReadLine();
                            message.RoundSecInTime();
                            Console.WriteLine("Результирующее сообщение: " + message.Value);
                            break;
                        }
                    default:
                        break;
                }
            } while (choice != 'E');
        }
    }
}
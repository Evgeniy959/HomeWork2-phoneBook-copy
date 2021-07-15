/*Задание.Телефонный справочник
Написать программу по созданию и редактированию телефонного справочника.
Должен хранится номер телефона и имя человека.
Программа должна уметь добавлять новый номер, редактировать старый, удалять и искать по номеру телефона кому он принадлежит.

*Продумать добавление типа/группы записи (семья, друзья, коллеги и т.п.)

Задание (добавить):
Доработать программу "Телефонный справочник" следующим образом:
добавить сохранение данных в файл перед закрытием
добавить импорт данных из файла при старте программы
реализовать ручной выбор сохранения данных в файл с вводом имени файла.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HomeWork2_phoneBook_copy2
{
    class Program
    {
        static void Main()
        {
            var exit = false;
            var phoneBook = new Dictionary<string, string>();
            //phoneBook = ExportFromFile();

            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Редактировать");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Найти");
                Console.WriteLine("5. Показать всё");
                Console.WriteLine("6.Загрузить из файла ");
                Console.WriteLine("7.Сохранить в новый файл");
                Console.WriteLine("0. Выход, cохранить в файл");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1. Добавить
                        AddRecord(phoneBook);
                        break;
                    case "2": // 2. Редактировать
                        Edit(phoneBook);
                        break;
                    /*case "3": // 3. Удалить
                        Delete(phoneBook);
                        break;
                    case "4": // 4. Найти
                        Find(phoneBook);
                        break;
                    case "5": // 5. Показать всё
                        PrintDictionary(phoneBook);
                        break;
                    case "6":
                        phoneBook = ExportFromFile();
                        break;
                    case "7":
                        AddFile();
                        break;*/
                    case "0": // 0. Выход
                        ImportToFile(phoneBook);
                        exit = true;
                        break;
                    default: // Неправильный ввод
                        Console.WriteLine("Повторите ввод");
                        Console.WriteLine();
                        break;
                }
            } while (!exit);
            Console.WriteLine("До свидания...");
        }
        static string DataName()
        {
            Console.Write("Введите имя - ");
            var name = Console.ReadLine();
            return name;
        }
        static string DataPhone()
        {
            Console.Write("Введите номер телефона - ");
            var phone = Console.ReadLine();
            return phone;
        }
        static string DataGroup()
        {
            Console.Write("Введите название группы - ");
            return Console.ReadLine();
        }
        static Dictionary<string, string> ExportFromFile()
        {
            var file = new StreamReader(Failname());
            var phoneBook = new Dictionary<string, string>();

            var str = string.Empty;
            while ((str = file.ReadLine()) != null)
            {
                var temp = SplitStr(str, '|');
                phoneBook.Add(temp.key, temp.value);
            }
            file.Close();
            return phoneBook;
        }
        static (string key, string value) SplitStr(string str, char delimiter)
        {
            var temp = str.Split(delimiter);
            var key = temp[0];
            var value = temp[1];
            return (key, value);
        }
        static void Edit(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var name = DataName();
            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (flag)
            {
                Console.Write("Введите новый номер телефона - ");
                var phone = Console.ReadLine();
                dictionary.Add(phone, name);
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Delete(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var name = DataName();
            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Find(Dictionary<string, string> dictionary)
        {
            var flag = false;
            var name = DataName();
            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    Console.WriteLine($"{element.Value} - {element.Key}");
                    flag = true;
                }
            }

            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        static void AddRecord(Dictionary<string, string> dictionary)
        {
            var flagAdd = false;
            var name = DataName();
            var phone = DataPhone();
            foreach (var element in dictionary)
            {
                if (element.Value == name && element.Key == phone)
                {
                    Console.WriteLine("Имя c данным номером уже существует");
                    flagAdd = true;
                }
            }
            if (!flagAdd)
            {
                dictionary.Add(phone, name);
            }
        }
        static void AddFile()
        {
            var phoneBook = new Dictionary<string, string>();
            Console.WriteLine("Введите данные которые хотите сохранить: ");
            AddRecord(phoneBook);
            ImportToFilePath(phoneBook);
        }
        static string Failname()
        {
            Console.WriteLine("Введите имя файла - ");
            string path = Console.ReadLine();
            return path;
        }
        static void ImportToFile(Dictionary<string, string> dictionary)
        {
            var file = new StreamWriter("it.phoneBook", true);
            foreach (var element in dictionary)
            {
                file.WriteLine($"{element.Key}|{element.Value}");
            }
            // file.Flush();
            file.Close();
        }
        static void ImportToFilePath(Dictionary<string, string> dictionary)
        {
            var file = new StreamWriter(Failname(), true);
            foreach (var element in dictionary)
            {
                file.WriteLine($"{element.Key}|{element.Value}");
            }
            // file.Flush();
            file.Close();
        }
        static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var element in dictionary)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }
    }
}



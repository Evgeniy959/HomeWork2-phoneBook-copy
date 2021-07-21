/*Задание.Телефонный справочник
Написать программу по созданию и редактированию телефонного справочника.
Должен хранится номер телефона и имя человека.
Программа должна уметь добавлять новый номер, редактировать старый, удалять и искать по номеру телефона кому он принадлежит.

*Продумать добавление типа/группы записи (семья, друзья, коллеги и т.п.)*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var exit = false;
            var phoneBook = new Dictionary<string, string>();

            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Редактировать");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Найти");
                Console.WriteLine("5. Показать всё");
                Console.WriteLine("0. Выход");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1. Добавить
                        AddRecord(phoneBook);
                        break;
                    case "2": // 2. Редактировать
                        Edit(phoneBook);
                        break;
                    case "3": // 3. Удалить
                        Delete(phoneBook);
                        break;
                    case "4": // 4. Найти
                        Find(phoneBook);
                        break;
                    case "5": // 5. Показать всё
                        PrintDictionary(phoneBook);
                        break;
                    case "0": // 0. Выход
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

        static void Delete(Dictionary<string, string> dictionary)
        {
            /*Console.Write("Введите имя - ");
            var name = Console.ReadLine();
            Console.Write("Введите номер телефона - ");
            var phone = Console.ReadLine();
            dictionary.Remove(name);
            dictionary.Remove(phone);*/

            //var flag = false;

            Console.Write("Введите имя - ");
            var name = Console.ReadLine();
            int counter = 0;

            foreach (var element in dictionary)
            {
                if (name == element.Value) { counter++; }
                //if (counter == 1) dictionary.Remove(element.Key);

                if (counter > 1 && element.Value == name) 
                {
                    foreach (var element1 in dictionary)
                    {
                        //Console.WriteLine($"{element1.Key}");
                        Console.WriteLine($"{element1.Value} - {element1.Key}");
                    }

                }
                //counter = 0;

                //dictionary.Remove(element.Value);

                //flag = true;
                if (counter == 1)
                {
                    foreach (var element2 in dictionary)
                    {
                        dictionary.Remove(element2.Key);

                    }
                }
                

            }

            if (counter == 0)//(!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
            //counter = 0;

        }

        static void Edit(Dictionary<string, string> dictionary)
        {
            var flag = false;

            Console.Write("Введите имя - ");
            var name = Console.ReadLine();

            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    Console.Write("Введите новый номер телефона - ");
                    var phone = Console.ReadLine();

                    dictionary.Remove(element.Key);
                    dictionary.Add(phone, name);

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

            Console.Write("Введите имя - ");
            var name = Console.ReadLine();

            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    Console.WriteLine($"{element.Value} - {element.Key}");
                    flag = true;
                }
                //else Console.WriteLine("Ничего не найдено");
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        static void AddRecord(Dictionary<string, string> dictionary)
        {
            Console.Write("Введите имя - ");
            var name = Console.ReadLine();
            Console.Write("Введите номер телефона - ");
            var phone = Console.ReadLine();
            dictionary.Add(phone, name);
            /*var flagAdd = false;
            Console.Write("Введите имя - ");
            var name = Console.ReadLine();
            Console.Write("Введите номер телефона - ");
            var phone = Console.ReadLine();
            foreach (var element in dictionary)
            {
                if (element.Value == name && element.Key == phone)
                {
                    Console.WriteLine("Имя c данным номером уже существует");                    
                    flagAdd = true;
                }
            }
            if (!flagAdd )
            {
                dictionary.Add(phone, name);
            }*/
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

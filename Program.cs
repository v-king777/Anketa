using System;

namespace Anketa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EnterUser());
        }

        // Ввод данных пользователя
        static (string Name, string LastName, int Age) EnterUser()
        {
            (string Name, string LastName, int Age) User;

            do
            {
                Console.Write("Введите имя: ");
                User.Name = Console.ReadLine().Replace(" ", "");

            } while (CheckStr(User.Name) == false);

            do
            {
                Console.Write("Введите фамилию: ");
                User.LastName = Console.ReadLine().Replace(" ", "");

            } while (CheckStr(User.LastName) == false);

            string strAge;
            int numAge;
            do
            {
                Console.Write("Введите возраст: ");
                strAge = Console.ReadLine().Replace(" ", "");

            } while (CheckNum(strAge, out numAge) == false);

            User.Age = numAge;

            return User;
        }

        // Проверка и преобразование строки в число
        static bool CheckNum(string str, out int num)
        {
            if (String.IsNullOrEmpty(str))
            {
                num = 0;
                Console.WriteLine("Напишите хоть что-нибудь!");
                return false;
            }

            if (int.TryParse(str, out int corrNum) == false || corrNum < 1)
            {
                num = 0;
                Console.WriteLine("Неверный ввод данных!");
                return false;
            }

            num = corrNum;
            return true;
        }

        // Проверка строки на вводимые символы
        static bool CheckStr(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                Console.WriteLine("Напишите хоть что-нибудь!");
                return false;
            }

            string lowStr = str.ToLower();

            for (int i = 0; i < lowStr.Length; i++)
            {
                if ((lowStr[i] < 97 || lowStr[i] > 122) &&
                    (lowStr[i] < 1072 || lowStr[i] > 1103))
                {
                    Console.WriteLine("Неверный ввод данных! Нужны буквы!");
                    return false;
                }
            }

            return true;
        }
    }
}

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
        static (string Name, string LastName, byte Age) EnterUser()
        {
            (string Name, string LastName, byte Age) User;

            Console.Write("Введите имя: ");
            User.Name = Console.ReadLine().Replace(" ", "");

            Console.Write("Введите фамилию: ");
            User.LastName = Console.ReadLine().Replace(" ", "");

            string strAge;
            byte numAge;
            do
            {
                Console.Write("Введите возраст цифрами: ");
                strAge = Console.ReadLine().Replace(" ", "");

            } while (CheckNum(strAge, out numAge) == false);

            User.Age = numAge;

            return User;
        }

        // Проверка и преобразование строки в число
        static bool CheckNum(string str, out byte num)
        {
            if (byte.TryParse(str, out byte corrNum) == false || corrNum == 0)
            {
                num = 0;
                Console.WriteLine("Неверный ввод данных!");
                return false;
            }

            num = corrNum;
            return true;
        }
    }
}

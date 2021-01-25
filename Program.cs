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
        static (string Name, string LastName, int Age, string HaveAPet, int Pets) EnterUser()
        {
            (string Name, string LastName, int Age, string HaveAPet, int Pets) User;

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

            do
            {
                Console.Write("Есть ли у Вас питомец? (да/нет) ");
                User.HaveAPet = Console.ReadLine().Replace(" ", "").ToLower();

            } while (CheckYesNo(User.HaveAPet) == false);

            if (User.HaveAPet == "да" || User.HaveAPet == "yes")
            {
                string strPet;
                int numPet;
                do
                {
                    Console.Write("Сколько у Вас питомцев? ");
                    strPet = Console.ReadLine().Replace(" ", "");

                } while (CheckNum(strPet, out numPet) == false);

                User.Pets = numPet;
            }
            else
            {
                User.Pets = 0;
            }

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

        // Проверка ввода да/нет
        static bool CheckYesNo(string str)
        {
            if (str != "да" && str != "нет" && str != "yes" && str != "no")
            {
                Console.WriteLine("Неверный ввод данных!");
                return false;
            }

            return true;
        }
    }
}

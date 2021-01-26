using System;

namespace Anketa
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = EnterUser();
            OutputOnDisplay(form);

            Console.ReadKey(true);
        }

        // Ввод данных пользователя
        static (string Name, string LastName, int Age, string HaveAPet, int Pets, string[] PetNames, int Colors, string[] FavColors) EnterUser()
        {
            (string Name, string LastName, int Age, string HaveAPet, int Pets, string[] PetNames, int Colors, string[] FavColors) User;

            // Имя
            do
            {
                Console.Write("Введите имя: ");
                User.Name = Console.ReadLine().Replace(" ", "");

            } while (CheckStr(User.Name) == false);

            // Фамилия
            do
            {
                Console.Write("Введите фамилию: ");
                User.LastName = Console.ReadLine().Replace(" ", "");

            } while (CheckStr(User.LastName) == false);

            // Возраст
            string strAge;
            int numAge;
            do
            {
                Console.Write("Введите возраст: ");
                strAge = Console.ReadLine().Replace(" ", "");

            } while (CheckNum(strAge, out numAge) == false);
            User.Age = numAge;

            // Наличие питомцев
            do
            {
                Console.Write("Есть ли у Вас питомцы? (да/нет) ");
                User.HaveAPet = Console.ReadLine().Replace(" ", "").ToLower();

            } while (CheckYesNo(User.HaveAPet) == false);

            // Если есть, то сколько и как зовут
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
                User.PetNames = EnterPetNames(User.Pets);
            }
            else
            {
                User.Pets = 0;
                User.PetNames = null;
            }

            // Сколько любимых цветов и каких
            string strColor;
            int numColor;
            do
            {
                Console.Write("Сколько у Вас любимых цветов? ");
                strColor = Console.ReadLine().Replace(" ", "");

            } while (CheckNum(strColor, out numColor) == false);
            User.Colors = numColor;
            User.FavColors = EnterFavColors(User.Colors);

            return User;
        }

        // Ввод кличек питомцев
        static string[] EnterPetNames(int num)
        {
            Console.WriteLine("Введите клички своих питомцев");
            string[] array = new string[num];

            for (int i = 0; i < num; i++)
            {
                do
                {
                    Console.Write("Питомец {0}: ", i + 1);
                    array[i] = Console.ReadLine().Replace(" ", "");

                } while (CheckStr(array[i]) == false);
            }

            return array;
        }

        // Ввод любимых цветов
        static string[] EnterFavColors(int num)
        {
            Console.WriteLine("Введите свои любимые цвета");
            string[] array = new string[num];

            for (int i = 0; i < num; i++)
            {
                do
                {
                    Console.Write("Цвет {0}: ", i + 1);
                    array[i] = Console.ReadLine().Replace(" ", "");

                } while (CheckStr(array[i]) == false);
            }

            return array;
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
                    (lowStr[i] < 1072 || lowStr[i] > 1105))
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

        // Вывод данных на экран
        static void OutputOnDisplay((string Name, string LastName, int Age, string HaveAPet, int Pets, string[] PetNames, int Colors, string[] FavColors) form)
        {
            Console.WriteLine("Ваше имя: {0}", form.Name);
            Console.WriteLine("Ваша фамилия: {0}", form.LastName);
            Console.WriteLine("Ваш возраст: {0}", form.Age);
            Console.WriteLine("Наличие питомцев: {0}", form.HaveAPet);

            if (form.HaveAPet == "да" || form.HaveAPet == "yes")
            {
                Console.WriteLine("Количество питомцев: {0}", form.Pets);
            }

            int count = 1;
            if (form.Pets > 0)
            {
                foreach (string str in form.PetNames)
                {
                    Console.WriteLine("Кличка питомца {0}: {1}", count++, str);
                }
            }

            Console.WriteLine("Количество любимых цветов: {0}", form.Colors);

            count = 1;
            foreach (string str in form.FavColors)
            {
                Console.WriteLine("Любимый цвет {0}: {1}", count++, str);
            }
        }
    }
}

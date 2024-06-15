namespace Home9_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задача 1. Обработка исключений. Среднее арифметическое положительных чисел из списка
            Console.WriteLine("Задача 1.");
            List<int> exmpList = new List<int>();
            Console.WriteLine("Введите список чисел:");
            string strList;
            // если будет сгенерировано исключение, то оно будет обработано как 
            // NoPositivNumberException или Other Exception обрабатываются все остальные исключения
            try
            {
                // получаем список контактов
                strList = Console.ReadLine();

                // преобразуем строку чисел разделенных пробелами в массив строк без пробелов
                string[] strArray = strList.Split(' ');

                // конвертирем строки в числа и добавляем в список
                foreach (string str in strArray)
                {
                    exmpList.Add(Convert.ToInt32(str));
                }

                Console.WriteLine();

                // вывод среднего арифметического положительных чисел из списка
                Console.WriteLine($"Среднее арифметическое положительных чисел: {AverageInt(exmpList)}");
            }
            // обработка исключения если списко не содержит положительных чисел
            catch (NoPositivNumbersException ex)
            {
                Console.WriteLine("NoPositivNumbersException: " + ex.Message);
            }
            // обработка всех остальных исключений
            catch (Exception ex)
            {
                Console.WriteLine("Other Exceptions: " + ex.Message);
            }


            // Задача 2. Обработка исключений. Список контактов, добавление и поиск по имени.
            Console.WriteLine("Задача 2.");

            // создаем объект класса ContactManager
            ContactsManager contactManager = new ContactsManager();

            // добавляем необходимые контакты
            contactManager.AddContact("Tom", "555-555-555");
            contactManager.AddContact("Bob", "434-342-112");
            contactManager.AddContact("Bob", "4567-789-999");
            contactManager.AddContact("Tom", "111-222-333");
            contactManager.AddContact("Bob", "543-323-444");
            contactManager.AddContact("Bob", "333-222-111");

            Console.WriteLine("Введите имя и телефон контакта для добавления: ");

            string contact = Console.ReadLine();

            contactManager.AddContact(contact.Split(' ')[0], contact.Split(' ')[1]);

            Console.Write("Введите имя контакта для поиска: ");
            string name = Console.ReadLine();

            List<Contact> bob = contactManager.FindContactByName(name);

            Console.WriteLine($"Контакты с именем {name}:");
            foreach (Contact item in bob)
            {
                Console.WriteLine($"{item.Name}: {item.PhoneNumber}");
            }

        }

        public static double AverageInt(List<int> objList)
        {
            var nullList = objList.Where(e => e >= 0);
            if (nullList.Count() == 0)
            {
                throw new NoPositivNumbersException("Список не содержит положительных чисел!");
            }
            return objList.Where(e => e >= 0).Average();
        }
    }
}

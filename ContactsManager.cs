using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home9_csharp
{
    public class ContactsManager
    {
        // свойство содержащее список контактов
        public List<Contact> contacts { get; set; } = new List<Contact>();

        // метод добавления нового контакта в список
        public void AddContact(string name, string phoneNumber)
        {
            // проверка введенных данных на null или на пустое поле
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(phoneNumber))
            {
                // генерируем исключение если вводд данных был не корректный
                throw new InvalidContactException("Ошибка: не ввседено имя или номер телефона контакта.");
            }
            else
            {
                // добавляем контакт в список контактов
                contacts.Add(new Contact { Name = name, PhoneNumber = phoneNumber });
            }
        }

        // метод поиска контакта по имени и если данных контактов много то будет выведен списко
        public List<Contact> FindContactByName(string name)
        {
            // генерируем исключение если ввод был не корректный
            if (String.IsNullOrEmpty(name))
            {
                throw new InvalidContactException("Ошибка: не введено имя контакта");
            }
            // возвращает список найденных контактов или пустой список если такого контакта нет
            return contacts.Where(c => c.Name == name).ToList();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_6
{
    public class Person
    {
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string Mail { get; set; }
        public long Phone { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }

        public Person(string fullname, string profession, string mail, long phone, double salary, int age)
        {
            FullName = fullname;
            Profession = profession;
            Mail = mail;
            Phone = phone;
            Salary = salary;
            Age = age;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Сотрудник {FullName}\nДолжность - {Profession}\nПочтовый ящик - {Mail}\n" +
                $"Телефон - {Phone}\nЗарплата - {Salary}\nВозраст - {Age}\n");
        }
    }
}

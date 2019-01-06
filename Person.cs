using System;
using System.Text;
using System.Threading.Tasks;

namespace CSLab
{
  public struct BirthDate
  {
  }

  public class Person
  {
    public string Name { 
      get; 
      set; 
    }
    public string Surname { 
      get; 
      set; 
    }

    public DateTime Birthday { 
      get; 
      set; 
    }

    // Функція, що передає або змінює рік народження
    public int BirthdayTimeYear
    {
      get { 
        return Birthday.Year; 
      }

      set { 
        Birthday = new DateTime(value, Birthday.Month, Birthday.Day); 
      }
    }

    // Конструктор без зовнішніх параметрів
    public Person()
    {
      Name = "Peter";
      Surname = "Griffin";
      Birthday = new DateTime(2000, 07, 10);
    }

    // Конструктор, що приймає параметри. Локальний та глобальний контекст зав'язані на Case-Insensitive.
    public Person(string name, string surname, DateTime birthday)
    {
      Name = name;
      Surname = surname;
      Birthday = birthday;
    }

    // Функція, що виводить на екран дані про людину
    public virtual void PrintFullInfo()
    {
      Console.WriteLine("----------------------");
      Console.WriteLine("Ім'я: " + Name);
      Console.WriteLine("Прізвище: " + Surname);
      Console.WriteLine("Дата народження: " + Birthday.ToShortDateString());
    }

    // Первизначені оператори порівняння 
    public static bool operator ==(Person first, Person second)
    {
      return (first.Name == second.Name && first.Surname == second.Surname &&
              first.Birthday == second.Birthday);
    }
    
    public static bool operator !=(Person first, Person second)
    {
      return !(first.Name == second.Name && first.Surname == second.Surname &&
              first.Birthday == second.Birthday);
    }

    public override int GetHashCode()  
    {  
      return 0;  
    }  

    public override bool Equals(object obj)
    {
      if ((Person)obj == this)
        return true;
      else 
        return false;
    }
  }
}
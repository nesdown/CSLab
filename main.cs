using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab
{
  class Program
  {
    static void Main(string[] args)
    {
      Student student1 = new Student();
      student1.Name = "Petro";
      student1.Surname = "Ivanov";
      student1.dataGroup = "IP-81";
      student1.Birthday = new DateTime(2001, 12, 10);
      student1.BirthdayTimeYear = 2001;
      student1.educationLevel = Student.Education.Bachelor;
      Console.Write(student1.ToString() + "\n");
      Console.Write("\n===========\n\n");

      Student student2 = new Student();
      student2.Name = "Bohdan";
      student2.Surname = "Glushko";
      student2.dataGroup = "IP-71";
      student2.Birthday = new DateTime(2000, 07, 10);
      student2.BirthdayTimeYear = 2000;
      student2.educationLevel = Student.Education.Bachelor;
      Console.Write(student2.ToString() + "\n");

      Console.Write("\n\nПеревіримо обєкти: \n");
      Console.Write(student1 == student2);

      Examination[] exams = new Examination[3]{
        new Examination(),
        new Examination(1, "ТЙіМС", "Гарко І.І.", 95, true, new DateTime(2019, 1, 14)),
        new Examination(3, "Філософія", "Куцик К.М.", 95, false, new DateTime(2017, 12, 23))
      };

      student1.AddExams(exams);

      Console.Write("\n\nРезультат у NSN:\n" + exams[1].NationalScaleName());
      Console.Write("\n\nРезультат у ECTS:\n" + exams[1].EctsScaleName());
      
      Console.Write("\n\nІтеруємо екзамени за балом 85.0: \n");
      foreach (Examination ex in student1.checkExams(85))
        Console.Write("\t-" + ex.Subject + "\n");

      Console.Write("\n\nІтеруємо екзамени за диф.: \n");
      foreach (Examination ex in student1.getCredits())
        Console.Write("\t-" + ex + "\n");
    }
  }
}
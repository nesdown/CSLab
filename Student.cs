using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab
{
  class Student : Person
  {
    public enum Education
    {
      Master,
      Bachelor,
      SecondEducation,
      PhD
    }

    private int bookNumber;

    public Education educationLevel { 
      get; 
      set; 
    }

    public string dataGroup {
      get;
      set; 
    }

    public Examination[] exams { 
      get; 
      set; 
    }

    public int recordBook
    {
      get { return bookNumber; }

      set
      {
        if (value < 99999 || value > 99999999)
        {
          throw new Exception("Номер залікової книги не є коректним!");
        }

        else
        {
          bookNumber = value;
        }
      }
    }

    public double average
    {
      get
      {
        double res = 0;
        for (int i = 0; i < exams.Length; ++i)
        {
          res += exams[i].Result;
        }
        res /= exams.Length;
        return res;
      }
    }

    public Student()
    {
      exams = new Examination[0];
    }

    public void AddExams(Examination[] allExams)
    {
      int examsLength;
      if (exams == null)
      {
        exams = new Examination[0];
        examsLength = 0;
      }

      else
        examsLength = exams.Length;

      int newLength = examsLength + allExams.Length;
      Examination[] newExams = new Examination[newLength];

      for (int i = 0; i < examsLength; i++)
        newExams[i] = exams[i];
      
      for (int i = examsLength; i < newLength; i++)
        newExams[i] = allExams[i - examsLength];
      
      exams = newExams;
    }

    public override string ToString()
    {
      return Name + " " + Surname + " " + dataGroup;
    }

    public override void PrintFullInfo()
    {
      string res = "";
      res += "Name:  " + Name + "\n";
      res += "Surname:  " + Surname + "\n";
      res += "Birthday:  " + Birthday.ToShortDateString() + "\n";
      res += "Education level:  " + educationLevel.ToString() + "\n";
      res += "Group:  " + dataGroup + "\n";
      res += "Record book № " + recordBook.ToString() + "\n";
      res += "Exams:  \n";
      if (exams == null) exams = new Examination[0];
      for (int i = 0; i < exams.Length; ++i)
      {
        res += (i + 1).ToString() + ".  " + exams[i].ToString() + "\n";
      }
      
      Console.Write(res);
    }

    // Ітератор, що перевіряє екзамени на результат
    public IEnumerable<Examination> checkExams(int result)
    {
      foreach (Examination exam in exams)
      {
        if (exam.Result >= result)
          yield return exam;
      }
    }

    // Ітератор, що перевіряє екзамени на диффер.
    public IEnumerable<Examination> getCredits()
    {
      foreach (Examination exam in exams)
        {
          if (!exam.IsDiffer)
            yield return exam;
        }
    }

    // Метод, що повертає відсортований список екзаменів
    public List<Examination> GetSortedExams()
    {
      var res = new List<Examination>(exams);
      res.Sort((a, b) => string.Compare(a.Subject, b.Subject));
      return res;
    }

  }
}
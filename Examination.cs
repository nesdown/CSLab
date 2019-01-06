using System;

namespace CSLab
{
  public class Examination : IMarkName
  {
    public short SemesterNumber { get; set; }
    public string Subject { get; set; }
    public string Tutor { get; set; }
    public float Result { get; set; }
    public bool IsDiffer { get; set; }
    public DateTime Date { get; set; }

    public Examination()
    {
      SemesterNumber = 3;
      Subject = "OOP Basics";
      Tutor = "Muha I. P.";
      Result = 100;
      IsDiffer = false;
      Date = new DateTime(2019, 01, 09);
    }

    public Examination(short SemesterNumber, string Subject, string Tutor,
      float Result, bool IsDiffer, DateTime Date)
    {
      this.SemesterNumber = SemesterNumber;
      this.Subject = Subject;
      this.Tutor = Tutor;
      this.Result = Result;
      this.IsDiffer = IsDiffer;
      this.Date = Date;
    }

    public override string ToString()
    {
      string result = "\nПредмет: " + this.Subject + '\n'
      + "Викладач: " + this.Tutor.Split(' ')[0] + '\n'
      + "Бал: " + this.Result.ToString() + '\n';
      return result.ToString();
    }

    public string NationalScaleName()
    {
      if (Result < 60)
        return "Недопущено";

      else if (Result < 65)
        return "Незадовільно";

      else if (Result < 75)
        return "Задовільно";

      else if (Result < 85)
        return "Добре";

      else if (Result < 95)
        return "Дуже добре";

      else
        return "Відмінно";
    }

    // Варіант на розгалуженнях
    public string EctsScaleName()
    {
      if (Result < 60)
        return "F";
      else if (Result < 65)
        return "E";
      else if (Result < 75)
        return "D";
      else if (Result < 85)
        return "C";
      else if (Result < 95)
        return "B";
      else
        return "A";
    }
  }
}
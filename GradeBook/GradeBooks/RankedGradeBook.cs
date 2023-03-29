using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Name = name;
            Type = Enums.GradeBookType.Ranked;


        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count() < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                double[] table = new double[Students.Count()];
                int i = 0;
                foreach (var student in Students)
                {
                    table[i] = student.AverageGrade;
                    i++;
                }
                bool change;
                do
                {
                    change = false;
                    for (int k = 0; k < table.Length - 1; k++)
                    {
                        double ele1 = table[k];
                        double ele2 = table[k + 1];
                        if (ele2 < ele1)
                        {
                            table[k] = ele2;
                            table[k + 1] = ele1;
                            change = true;
                        }
                    }
                } while (change);
                int pozycja = -1;
                for (int j = 0; j < Students.Count(); j++)
                {
                    if (table[j] == averageGrade) pozycja = j;
                }
                if (pozycja >= Students.Count() * 0.8)
                    return 'A';
                else if (pozycja >= Students.Count() * 0.6)
                    return 'B';
                else if (pozycja >= Students.Count() * 0.4)
                    return 'C';
                else if (pozycja >= Students.Count() * 0.2)
                    return 'D';
                else
                    return 'F';
            }
        }

        public virtual void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public virtual void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }


        public override char GetLetterGrade(double averageGrade)
        {
            var twentyPerc = (int)Math.Ceiling(Students.Count * 0.2);
            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (Students.Count < 5) 
            { throw new InvalidOperationException("There are less than 5 students."); }

            if (averageGrade >= grade[twentyPerc - 1])
                return 'A';
            if (averageGrade >= grade[(twentyPerc * 2) - 1])
                return 'B';
            if (averageGrade >= grade[(twentyPerc * 3) - 1])
                return 'C';
            if (averageGrade >= grade[(twentyPerc * 4) - 1])
                return 'D';
            else
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
            base.CalculateStudentStatistics(name);
        }
    }
    }


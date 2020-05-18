using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw InvalidOperationException();
            }

            var allGrades = Students.OrderByDescending(i => i.AverageGrade).Select(i => i.AverageGrade).ToList();
            var letterPercentage = (int)Math.Ceiling(Students.Count * 0.2);

            if (averageGrade >= allGrades[letterPercentage - 1])
                return 'A';

            return 'F';
        }

        private Exception InvalidOperationException()
        {
            throw new NotImplementedException();
        }
    }
}

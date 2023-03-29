using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {

        public StandardGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Name = name;
            Type = Enums.GradeBookType.Standard;
            IsWeight = IsWeight;

        }

    }
}
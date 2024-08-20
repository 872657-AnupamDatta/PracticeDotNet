using System.Diagnostics.CodeAnalysis;

namespace Linqs
{
    public class FluentSyntaxs
    {
        public List<Student> FindTeenAgers(List<Student> students)
        {
            List<Student> teenAgers = students.Where(student => student.Age > 12 && student.Age < 20).ToList<Student>();

            return teenAgers;
        }

        public List<Student> StudentsWithOddIDs(List<Student> students)
        {
            Console.WriteLine("Students with Odd IDs");
            List<Student> oddIDStudents = students.Where((s, i) =>
            { 
                if (i % 2!= 0)
                {
                    return false;
                }
                return true;
            }).ToList();

            return oddIDStudents;
        }

        public IEnumerable<IGrouping<string, Student>> GroupStudentsByState(List<Student> students)
        {
            IEnumerable<IGrouping<string, Student>> groupsByState = students.GroupBy(student => student.State);

            return groupsByState;
        }

        public List<JoinResultModel> UseOfJoinFluent(List<Student> studentList, IList<Standard> standardList)
        {
            var joinResult = studentList.Join(
                                standardList,
                                student => student.StandardID,
                                standard => standard.ID,
                                (s, st) => new JoinResultModel()
                                {
                                    StandardName = st.StandardName,
                                    StudentName = s.FullName
                                }
                            ).ToList();

            return joinResult;
        }

        #region All
        public bool CheckIfAllStudentsAreTeenagers(List<Student> students)
        {
            return students.All<Student>(student => student.Age > 12 && student.Age <= 18);
        }
        #endregion All

        #region Any
        public bool IsAnyOneAdult(List<Student> students)
        {
            return students.Any<Student>(s => s.Age > 18);
        }
        #endregion Any

        #region Contains
        // Checks if the element is present, for premitive types
        public bool UseOfContains<T>(List<T> items, T value)
        {
            return items.Contains<T>(value);
        }

        public bool UseOfContains(List<Student> students, Student student)
        {
            return students.Contains(student, new StudentComparer());
        }
        #endregion Contains
    }

    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if(x.ID == y.ID && 
                x.FullName.Equals(y.FullName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.GetHashCode();
        }
    }
}
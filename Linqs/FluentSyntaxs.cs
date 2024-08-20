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

        #region Aggregate
        public string CommaSeperatedNames(List<string> names)
        {
            // Aggregate(Func(TSource, TSource, TSource))
            string finalStr = names.Aggregate((s1, s2) => s1 + ", " + s2);
            return finalStr;
        }
        // Second overload
        #region Aggregate with Seed value
        public string AggregateWithSeedValue(List<Student> students)
        {
            // Aggregate(Func(TAccumulate, TSource, TAccumulate))
            // Aggregate(initial_value, (variableOfFinalResulttype, data_type_to_be_aggregated) => { ... })
            string finalStr = students.Aggregate<Student, string>("Names of students are: ", (str, student) => str + ", " + student.FullName);
            return finalStr;
        }
        public int AggregateWithSeedValue(List<int> numbers)
        {
            int finalRes = numbers.Aggregate(0, (totalValue, n) => totalValue + n);
            return finalRes;
        }
        public int AggregateAgeOfStudents(List<Student> students)
        {
            return students.Aggregate(0, (totalAge, s) => totalAge + s.Age);
        }
        #endregion Aggregate with Seed value

        #region Aggregate with Seed value and Result selector
        public string AggregateWithSeedValueAndResultSelector(List<Student> students)
        {
            return students.Aggregate<Student, string, string>(string.Empty, (str, s) => str + s.FullName + ",", res => res.Substring(0, res.Length - 1));
        }
        #endregion

        #endregion Aggregate

        #region Average
        public double AverageAgeOfStudents(List<Student> students) => students.Average(s => s.Age);
        #endregion

        #region Count
        public (int,int) GetCount(List<Student> students)
        {
            int numberOfStudetns = students.Count();
            int numberOfAdults = students.Count(s => s.Age >= 18);
            
            return (numberOfStudetns, numberOfAdults);
        }
        #endregion

        #region Max
        public int GetAgeOfEldestStudent(List<Student> students)
        {
            return students.Max(s => s.Age);
        }
        public int GetLargestEvenNumber(List<int> numbers)
        {
            return numbers.Max(n => {  
                if(n % 2 == 0) return n;
                return 0;
            });
        }
        #endregion

        #region Min
        public int GetAgeOfSmallestStudet(List<Student> students)
        {
            return students.Min(s => s.Age);
        }
        #endregion
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
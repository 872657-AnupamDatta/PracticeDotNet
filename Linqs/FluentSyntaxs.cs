using System.Diagnostics.CodeAnalysis;

namespace Linqs
{
    public class FluentSyntaxs
    {
        #region Where

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
                if (i % 2 != 0)
                {
                    return false;
                }
                return true;
            }).ToList();

            return oddIDStudents;
        }
        #endregion

        #region GroupBy

        public IEnumerable<IGrouping<string, Student>> GroupStudentsByState(List<Student> students)
        {
            IEnumerable<IGrouping<string, Student>> groupsByState = students.GroupBy(student => student.State);

            return groupsByState;
        }
        #endregion

        #region Join

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
        #endregion

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
        public (int, int) GetCount(List<Student> students)
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
            return numbers.Max(n =>
            {
                if (n % 2 == 0) return n;
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

        #region Sum
        public int GetTotalAgeOfStudents(List<Student> students)
        {
            return students.Sum(s => s.Age);
        }
        public int GetTotalAgeOfAdults(List<Student> students)
        {
            return students.Sum<Student>(s =>
            {
                if (s.Age >= 18) return s.Age;
                return 0;
            });
        }
        #endregion

        #region ElementAt
        public T GetElementAt<T>(IEnumerable<T> items, int index)
        {
            return items.ElementAt(index);
        }
        #endregion

        #region ElementAtOrDefault
        // It will return the element value at the specified index.
        // If the index is out of range then it will return default value of type
        public T GetElementAtOrDefault<T>(IEnumerable<T> items, int index)
        {
            return items.ElementAtOrDefault(index);
        }
        #endregion

        #region First & FirstOrDefault
        public T GetFirst<T>(IEnumerable<T> items) => items.First();
        public int GetFirstEvenNumber(List<int> numbers) => numbers.First<int>(n => n % 2 == 0);
        public T GetFirstOrDefault<T>(IEnumerable<T> items) => items.FirstOrDefault();
        public string GetFirstOddNumber(List<string> numbers) => numbers.FirstOrDefault(str => str.Contains("h", StringComparison.OrdinalIgnoreCase));
        #endregion

        #region Set Operators

        #region Distinct
        public void DemoDistinct()
        {
            List<int> numbers = new List<int>() { 2, 3, 30, 5, 2, 1 };
            List<int> distinctNumbers = numbers.Distinct().ToList();

            // display the two different lists
            Console.WriteLine("List with all elements");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\nList with distinct elements");
            foreach (int number in distinctNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public void DemoDistinct(List<Student> students)
        {
            Console.WriteLine("Demo of Distinct with complex class object");
            IList<Student> collection = students.Distinct(new StudentComparer()).ToList();
            foreach(Student student in collection)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Age: {2}", student.ID, student.FullName, student.Age);
            }
        }
        #endregion

        #region Except
        /// <summary>
        /// It shows the implementation of Except()
        /// </summary>
        public void DemoExcept()
        {
            IList<string> collection1 = new List<string>(){ "one", "two", "three" };
            IList<string> collection2 = new List<string>() { "two", "four", "five" };

            // getting a new collection which contains elements that are absent in collection2
            IList<string> collection3 = collection1.Except(collection2).ToList();

            foreach(string val in collection3)
            {
                Console.WriteLine(val);
            }
        }

        /// <summary>
        /// It shows the implementation of Except() for complex classes.
        /// </summary>
        /// <param name="students">Complex object list.</param>
        /// <param name="students2">Complex object list, whose elements we don't want.</param>
        public void DemoExcept(List<Student> students, List<Student> students2)
        {
            Console.WriteLine("Demo of Except with complex class object");
            IList<Student> collection = students.Except(students2, new StudentComparer()).ToList();

            foreach (Student student in collection)
            {
                Console.WriteLine("ID: {0}, Name: {1}, Age: {2}", student.ID, student.FullName, student.Age);
            }
        }
        #endregion

        #region Intersect
        /// <summary>
        /// It uses two collections and finds the common ones
        /// </summary>
        /// <param name="list1">first collection</param>
        /// <param name="List2">Second collection</param>
        public void DemoIntersect(List<int> list1, List<int> List2)
        {
            Console.WriteLine("Elements in List1 are : ");
            Utilities.DisplayItems(list1);
            Console.WriteLine("Elements in List2 are: ");
            Utilities.DisplayItems(List2);

            var commonList = list1.Intersect<int>(List2);
            Console.WriteLine("Elements those are common in both the collections are: ");
            Utilities.DisplayItems(commonList.ToList());
        }

        /// <summary>
        /// It uses two complex collections and finds the common ones.
        /// </summary>
        /// <param name="list1">first collection</param>
        /// <param name="list2">second collection</param>
        public void DemoIntersect(List<Student> list1, List<Student> list2)
        {
            var commonList = list1.Intersect(list2, new StudentComparer()).ToList();
            Utilities.DisplayStudentDetails(commonList);
        }
        #endregion Intersect

        #region Union
        /// <summary>
        /// Union operation is done on two data sets. It displays unique elements in both of the data sets.
        /// </summary>
        /// <param name="list1">First data set</param>
        /// <param name="list2">Second data set</param>
        public void DemoUnion<TSource>(ICollection<TSource> list1, ICollection<TSource> list2)
        {
            Console.WriteLine("Items in List1: ");
            Utilities.DisplayItems(list1);
            Console.WriteLine("Items in List2: ");
            Utilities.DisplayItems(list2);

            var resultLst = list1.Union(list2).ToList();
            Console.WriteLine("Unique elements in both the lists: ");
            Utilities.DisplayItems(resultLst);
        }

        /// <summary>
        /// Union operation is done on two data sets of type Student. It displays unique elements in both of the data sets.
        /// </summary>
        /// <param name="stuLst1">first collection of type Student</param>
        /// <param name="stuLst2">second collection of type Student</param>
        public void DemoUnion(List<Student> stuLst1, List<Student> stuLst2)
        {
            Console.WriteLine("Items in List1: ");
            Utilities.DisplayStudentDetails(stuLst1);
            Console.WriteLine("Items in List2: ");
            Utilities.DisplayStudentDetails(stuLst2);

            var resultLst = stuLst1.Union(stuLst2, new StudentComparer()).ToList();
            Console.WriteLine("Unique elements in both the Student lists: ");
            Utilities.DisplayStudentDetails(resultLst);
        }
        #endregion

        #endregion Set Operators
    }

    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x.ID == y.ID &&
                x.FullName.Equals(y.FullName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}

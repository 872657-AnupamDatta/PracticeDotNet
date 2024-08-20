using Linqs;
using System.Collections;

#region Populate data
List<Student> students = new List<Student>()
{
    new Student(){ ID = 1, FullName = "John", Age = 13, State = "West Bengal", StandardID = 2},
    new Student(){ ID = 2, FullName = "Moin", Age = 21, State = "Assam", StandardID = 1},
    new Student(){ ID = 3, FullName = "Bill", Age = 18, State = "West Bengal", StandardID = 2},
    new Student(){ ID = 4, FullName = "Ram", Age = 20, State = "Gujrat", StandardID = 3},
    new Student(){ ID = 5, FullName = "Ron", Age = 15, State = "Bihar", StandardID = 1},
    new Student(){ ID = 6, FullName = "Smith", Age = 18, State = "Sikkim", StandardID = 3},
};

IList<Standard> standards = new List<Standard>()
{
    new Standard() {ID = 1, StandardName = "Junior"},
    new Standard() {ID = 2, StandardName = "Mid"},
    new Standard() {ID = 3, StandardName = "High"}
};

var mixedDataList = new ArrayList();
mixedDataList.Add(1);
mixedDataList.Add(10);
mixedDataList.Add("Hi");
mixedDataList.Add("hello");
mixedDataList.Add(new Student { ID = 12, FullName = "test Student", Age = 15 });
#endregion

#region Common Variables declaration
List<Student> ascStudentsByname = [];
List<Student> desStudentsByAge = [];
List<JoinResultModel> joinResults = [];
#endregion Common Variables declaration

Utilities.DisplayBanner("Query Syntax");

#region Query Syntax
QuerySyntaxs querySyntaxs = new QuerySyntaxs();

#region Use of Where
// Get all teenAgers and Display them
List<Student> teenAgersQuery = querySyntaxs.FindTeenAgers(students);
Utilities.DisplayStudentDetails(teenAgersQuery);

// Get all Students with Even IDs
List<Student> evenIDStudents = querySyntaxs.StudentsWithEvenIDs(students);
Utilities.DisplayStudentDetails(evenIDStudents);
#endregion Use of Where

#region Use of OfType
Utilities.DisplaySubBanner("OfType");
// It filters out the collection based on the given type.
var queryResStr = from r in mixedDataList.OfType<string>() select r;
var queryResInt = from r in mixedDataList.OfType<int>() select r;
var quesryResStu = from r in mixedDataList.OfType<Student>() select r;

// Display all the items
Console.WriteLine("Datas of String type");
foreach (var item in queryResStr) { Console.WriteLine(item); }

Console.WriteLine("Datas of Int type");
foreach (var item in queryResInt) { Console.WriteLine(item); }

Console.WriteLine("Datas of Student type");
Utilities.DisplayStudentDetails(quesryResStu.ToList());

#endregion Use of OfType

#region Use of OrderBy
Utilities.DisplaySubBanner("orderby");
// Order the students in Ascending by their name
ascStudentsByname = (from s in students orderby s.FullName select s).ToList();
Console.WriteLine("Students in assending order by Full name");
Utilities.DisplayStudentDetails(ascStudentsByname);

Utilities.DisplaySubBanner("orderbydescending");
// Order the students in Descending by their Age
desStudentsByAge = (from s in students orderby s.Age descending select s).ToList();
Console.WriteLine("Students in Descending order by Age");
Utilities.DisplayStudentDetails(desStudentsByAge);
#endregion Use of OrderBy

#region Use of group by
Utilities.DisplaySubBanner("group by");
// group by returns IEnumerable<IGrouping<TKey, TSource>>
// Example of IEnumerable List. So the above can be think of as List<IGrouping<TKey, TSource>>
IEnumerable<IGrouping<int, Student>> studentsGroupedByAge = from s in students group s by s.Age;
foreach (var group in studentsGroupedByAge)
{
    Console.WriteLine("Grouped By: {0}", group.Key);
    foreach(Student s in group)
    {
        Console.WriteLine("Name: {0}", s.FullName);
    }
}
#endregion Use of group by

#region Use of Join
Utilities.DisplaySubBanner("Join");
joinResults = querySyntaxs.UseOfJoin(students, standards);
foreach(var res in joinResults)
{
    Console.WriteLine($"Student Name: {res.StudentName}, Standard Name: {res.StandardName}");
}
#endregion Use of Join

#endregion Query Syntax

Utilities.DisplayBanner("Fluent/Method Syntax");

#region Method Syntax/Fluent Syntax
FluentSyntaxs fluentSyntaxs = new FluentSyntaxs();
#region Use of Where
// Get all teenAgers and Display them
List<Student> teenAgersFluent = fluentSyntaxs.FindTeenAgers(students);
Utilities.DisplayStudentDetails(teenAgersFluent);

// Get all Students with Odd IDs
List<Student> oddIDStudents = fluentSyntaxs.StudentsWithOddIDs(students);
Utilities.DisplayStudentDetails(oddIDStudents);
#endregion Use of Where

#region Use of OfType
Utilities.DisplaySubBanner("OfType");
var fluentResStr = mixedDataList.OfType<string>().ToList();
var fluentResInt = mixedDataList.OfType<int>().ToList();
var fluentResStu = mixedDataList.OfType<Student>().ToList();

Console.WriteLine("Datas of int type");
Utilities.DisplayItems<int>(fluentResInt);

Console.WriteLine("Datas of String type");
Utilities.DisplayItems<string>(fluentResStr);

Console.WriteLine("Datas of Student type");
Utilities.DisplayStudentDetails(fluentResStu.ToList());
#endregion Use of OfType

#region Use of OrderBy
Utilities.DisplaySubBanner("OrderBy");
// Order the students in Ascending by their name
ascStudentsByname = students.OrderBy(s => s.FullName).ToList();
Console.WriteLine("Students in assending order by Full name");
Utilities.DisplayStudentDetails(ascStudentsByname);

Utilities.DisplaySubBanner("OrderByDescending");
// Order the students in Descending by their Age
desStudentsByAge = students.OrderByDescending(s => s.Age).ToList();
Console.WriteLine("Students in Descending order by Age");
Utilities.DisplayStudentDetails(desStudentsByAge);
#endregion Use of OrderBy

#region Use of ThenBy
Utilities.DisplaySubBanner("ThenBy");
// We use ThenBy after OrderBy, in Method syntax only, to sort the resultant collection we receive
// after OrderBy to sort again on the basic of another condition.
List<Student> studentsByNameAndAge = students.OrderBy(s => s.FullName).ThenBy(s => s.Age).ToList();
Console.WriteLine("Students fillterd using OrderBy and then ThenBy on basis of Name and Age respectively");
Utilities.DisplayStudentDetails(studentsByNameAndAge);
#endregion

#region Use of ThenByDescending
Utilities.DisplaySubBanner("ThenByDescending");
// We use ThenByDescending after OrderBy, in Method syntax only, to sort the resultant collection we receive
// after OrderBy to sort again on the basic of another condition.
List<Student> studentsByNameAndAgeDesc = students.OrderBy(s => s.FullName).ThenByDescending(s => s.Age).ToList();
Console.WriteLine("Students fillterd using OrderBy and then ThenByDescending on basis of Name and Age respectively");
Utilities.DisplayStudentDetails(studentsByNameAndAgeDesc);
#endregion

#region Use of GroupBy
Utilities.DisplaySubBanner("GroupBy");
IEnumerable<IGrouping<string, Student>> studentGroupsByStates = fluentSyntaxs.GroupStudentsByState(students);
// Iterate over each item inside the group
foreach(var group in studentGroupsByStates)
{
    Console.WriteLine($"Group: {group.Key}");
    foreach(Student s in group)
    {
        Console.WriteLine($"ID: {s.ID}, Name: {s.FullName}, Age: {s.Age}, State: {s.State}");
    }
}
#endregion Use of GroupBy

#region Use of Join
Utilities.DisplaySubBanner("Join");
joinResults = fluentSyntaxs.UseOfJoinFluent(students, standards);
foreach(var res in joinResults)
{
    Console.WriteLine($"Student Name- {res.StudentName}, Standard Name- {res.StandardName}");
}
#endregion Use of Join

#region Use of All
Utilities.DisplaySubBanner("All");
bool areAllTeenAgers = fluentSyntaxs.CheckIfAllStudentsAreTeenagers(students);
Console.WriteLine("Are all Students Teenagers? {0}", areAllTeenAgers);
#endregion Use of All

#endregion Method Syntax/Fluent Syntax

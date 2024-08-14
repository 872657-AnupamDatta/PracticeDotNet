using Linqs;
using System.Collections;

#region Populate data
List<Student> students = new List<Student>()
{
    new Student(){ ID = 1, FullName = "John", Age = 13},
    new Student(){ ID = 2, FullName = "Moin", Age = 21},
    new Student(){ ID = 3, FullName = "Bill", Age = 18},
    new Student(){ ID = 4, FullName = "Ram", Age = 20},
    new Student(){ ID = 5, FullName = "Ron", Age = 15},
};

var mixedDataList = new ArrayList();
mixedDataList.Add(1);
mixedDataList.Add(10);
mixedDataList.Add("Hi");
mixedDataList.Add("hello");
mixedDataList.Add(new Student { ID = 12, FullName = "test Student", Age = 15 });
#endregion

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

#endregion Method Syntax/Fluent Syntax

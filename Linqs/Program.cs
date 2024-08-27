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

List<Student> students2 = new List<Student>()
{
    new Student(){ ID = 4, FullName = "Ram", Age = 20, State = "Gujrat", StandardID = 3},
    new Student(){ ID = 6, FullName = "Smith", Age = 18, State = "Sikkim", StandardID = 3},
    new Student(){ ID = 6, FullName = "Smith", Age = 18, State = "Sikkim", StandardID = 3},
    new Student(){ ID = 7, FullName = "Derick", Age = 22, State = "Karnataka", StandardID = 3}
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

List<int> intDataList = new List<int>() { 1, 2, 3, 5, 6 };
List<int> intDataList2 = [3, 5, 6, 7];
List<string> stringDataList = new List<string>() { "Hi", "Hello", "good", "bad", "morning", "night" };
List<string> stringDataList2 = ["good", "bad", "unique"];
List<int> emptyIntList = [];
List<string> emptyStringList = [];
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

#region Use of Any
Utilities.DisplaySubBanner("Any");
bool isAnyAdult = fluentSyntaxs.IsAnyOneAdult(students);
Console.WriteLine("Is there anyone Adult? {0}", isAnyAdult);
#endregion Use of Any

#region Use of Contains
Utilities.DisplaySubBanner("Contains");
// With Premitive data types
Console.WriteLine($"is Interger data list contains 5? {fluentSyntaxs.UseOfContains(intDataList, 5)}");
Console.WriteLine($"is String data list contains \"night\"? {fluentSyntaxs.UseOfContains(stringDataList, "night")}");

// With Classes
Student std = new Student() { ID = 1, FullName = "John" };
StudentComparer stdCom = new StudentComparer();
Console.WriteLine($"Is new student is already in Student list? {fluentSyntaxs.UseOfContains(students, std)}");
#endregion Use of Contains

#region Use of Aggregate
Utilities.DisplaySubBanner("Aggregate");
Console.WriteLine($"Comma seperated values of stringDataList: {fluentSyntaxs.CommaSeperatedNames(stringDataList)}");
Console.WriteLine($"{fluentSyntaxs.AggregateWithSeedValue(students)}");
Console.WriteLine($"Aggregate value of numberlist: {fluentSyntaxs.AggregateWithSeedValue(intDataList)}");
Console.WriteLine($"Total Age of students: {fluentSyntaxs.AggregateAgeOfStudents(students)} years");
Console.WriteLine($"Names of all Students: {fluentSyntaxs.AggregateWithSeedValueAndResultSelector(students)}");
#endregion Use of Aggregate

#region Use of Average
Utilities.DisplaySubBanner("Average");
Console.WriteLine($"Average age of Students: {fluentSyntaxs.AverageAgeOfStudents(students)}");
#endregion Use of Average

#region Use of Count
Utilities.DisplaySubBanner("Count");
(int totalStudents, int totalAdults) = fluentSyntaxs.GetCount(students);
Console.WriteLine($"Total Students: {totalStudents} and Total Adults: {totalAdults}");
#endregion Use of Count

#region Use of Max
Utilities.DisplaySubBanner("Max");
Console.WriteLine("Age of eldest student is : {0}", fluentSyntaxs.GetAgeOfEldestStudent(students));
Console.WriteLine("Largest Even Number: {0}", fluentSyntaxs.GetLargestEvenNumber(intDataList));
#endregion Use of Max

#region Use of Min
Utilities.DisplaySubBanner("Min");
Console.WriteLine("Age of youngest student is : {0}", fluentSyntaxs.GetAgeOfSmallestStudet(students));
#endregion Use of Min

#region Use of Sum
Utilities.DisplaySubBanner("Sum");
Console.WriteLine("Total age of all students: {0}", fluentSyntaxs.GetTotalAgeOfStudents(students));
Console.WriteLine("Total age of Adult students: {0}", fluentSyntaxs.GetTotalAgeOfAdults(students));
#endregion Use of Sum

#region Use of ElementAt
Utilities.DisplaySubBanner("ElementAt");
Console.WriteLine($"Integer element at position 3 of integer list : {fluentSyntaxs.GetElementAt(intDataList, 2)}");
Console.WriteLine($"String element at position 3 of string list : {fluentSyntaxs.GetElementAt(stringDataList, 2)}");
// It throws out of range exception
//Console.WriteLine("Integer value returned from Empty list using ElementAt: {0}", fluentSyntaxs.GetElementAt(emptyIntList, 1));
#endregion Use of ElementAt

#region Use of ElementAtOrDefault
Utilities.DisplaySubBanner("ElementAtOrDefault");
Console.WriteLine($"Integer element at position 4 (index 3) of integer list: {fluentSyntaxs.GetElementAtOrDefault(intDataList, 3)}");
Console.WriteLine($"String element at position 4 (index 3) of string list: {fluentSyntaxs.GetElementAtOrDefault(stringDataList, 3)}");
Console.WriteLine($"Integer value at Position 10, i.e. out of range in integer list (Default Value): {fluentSyntaxs.GetElementAtOrDefault(intDataList, 9)}");
// default value for string 'null'
Console.WriteLine($"String value at position 10, i.e. out of range in string list (Default Value): {fluentSyntaxs.GetElementAtOrDefault(stringDataList, 9)}");
Console.WriteLine("string value returned from Empty list using ElementAtOrDefault: {0}", fluentSyntaxs.GetElementAtOrDefault(emptyStringList, 1));
#endregion Use of ElementAtOrDefault

#region Use of First() & FirstOrDefault()
Utilities.DisplaySubBanner("First & FirstOrDefault");
Console.WriteLine("First element of integer list: {0}", fluentSyntaxs.GetFirst<int>(intDataList));
Console.WriteLine("First element of string list: {0}", fluentSyntaxs.GetFirst<string>(stringDataList));
// will throw run time exception, as no element is present in the collection.
//Console.WriteLine("First element of empty integer list: ", fluentSyntaxs.GetFirst<int>(emptyIntList));
Console.WriteLine("First even number in integer list: {0}", fluentSyntaxs.GetFirstEvenNumber(intDataList));

Console.WriteLine("First element of integer list (using FirstOrDefault()): {0}", fluentSyntaxs.GetFirstOrDefault<int>(intDataList));
Console.WriteLine("First element of string list (using FirstOrDefault()): {0}", fluentSyntaxs.GetFirstOrDefault<string>(stringDataList));
Console.WriteLine("First element of empty integer list (using FirstOrDefault()): {0}", fluentSyntaxs.GetFirstOrDefault<int>(emptyIntList));
Console.WriteLine("First element of empty string list (using FirstOrDefault()): {0}", fluentSyntaxs.GetFirstOrDefault<string>(emptyStringList));
Console.WriteLine("First odd number in the integer list: {0}", fluentSyntaxs.GetFirstOddNumber(stringDataList));
Console.WriteLine("First odd number in the empty integer list: {0}", fluentSyntaxs.GetFirstOddNumber(emptyStringList));
#endregion

#region Use of Empty()
Utilities.DisplaySubBanner("Empty");
var emptIntLst = Enumerable.Empty<string>();
Console.WriteLine("No. of items inside emptIntLst: {0}", emptIntLst.Count());
Console.WriteLine("Type of emptIntLst: {0}", emptIntLst.GetType());
#endregion Use of Empty()

#region Use of Range()
Utilities.DisplaySubBanner("Range");
var intLst = Enumerable.Range(10, 10);
// iterate over the elements
for(int i = 0; i<intLst.Count(); i++)
{
    Console.WriteLine("value at {0} is {1}", i, intLst.ElementAt(i));
}
#endregion Use of Range()

#region Use of Repeat()
Utilities.DisplaySubBanner("Repeat");
var strLst = Enumerable.Repeat("Hi", 10);
for(int i =0; i < strLst.Count(); i++)
{
    Console.WriteLine("value at index {0} is {1}", i, strLst.ElementAt(i));
}
#endregion Use of Repeat()

#region Use of Distinct()
Utilities.DisplaySubBanner("Distinct");
fluentSyntaxs.DemoDistinct();
fluentSyntaxs.DemoDistinct(students2);
#endregion Use of Distinct()

#region Use of Except()
Utilities.DisplaySubBanner("Except");
fluentSyntaxs.DemoExcept();
fluentSyntaxs.DemoExcept(students, students2);
#endregion Use of Except()

#region Use of Intersect()
Utilities.DisplaySubBanner("Intersect");
fluentSyntaxs.DemoIntersect(intDataList, intDataList2);
fluentSyntaxs.DemoIntersect(students, students2);
#endregion Use of Intersect()

#region Use of Union
Utilities.DisplaySubBanner("Union");
fluentSyntaxs.DemoUnion(stringDataList, stringDataList2);
fluentSyntaxs.DemoUnion(students, students2);
#endregion Use of Union

#endregion Method Syntax/Fluent Syntax

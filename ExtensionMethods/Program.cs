// See https://aka.ms/new-console-template for more information
using ExtensionMethods;

#region Integer Extension methods

int i = 134;
bool isGreater = i.IsGreater(100);

Console.WriteLine($"is input greater? {isGreater}");

int j = 100;
bool isLesser = j.IsLesser(34);
Console.WriteLine($"Is input value lesser? {isLesser}");
#endregion

#region String Extension Methods
string myMsg = "Printing passed message";
myMsg.DisplayMsg();
#endregion

#region Extension Methods for classes
ClassA obj = new ClassA();
// Normal class method
obj.ShowName("Anupam");
// Call extension method
obj.CallShowName();
#endregion


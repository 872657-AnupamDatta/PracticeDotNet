using Delegates;

// See https://aka.ms/new-console-template for more information
#region User of Basic Delegate
MyDeligate del = ClassA.MethodA;    // Assigning value of Delegate
del("Hello Method A");              // Invoking the Delegate

del = ClassB.MethodB;
del("Hello Method B");

del = (string msg) => { Console.WriteLine("This is a Lamda function. Message Passed: " + msg); };
del("Hello Lamda");

#endregion

#region Pass Delegate as parameter
Utilities.CreateDivision("Pass delegate as parameter");
ClassC.InvokeDelegate(del);

del = ClassA.MethodA;
ClassC.InvokeDelegate(del);

del = ClassB.MethodB;
ClassC.InvokeDelegate(del);
#endregion

#region Multicast Delegate
// a Delegate which points to multiple methods is called Multicast Delegate
Utilities.CreateDivision("Multicast Delegate");
MyDeligate delA = ClassA.MethodA;
MyDeligate delB = ClassB.MethodB;
del = delA + delB;  // combines delA + delB
del("delA + delB");
MyDeligate delLamda = (string msg) => Console.WriteLine("Lamda expression. " + msg);
del += delLamda;     // combines delA + delB + delLamda
del("delA + delB + delLamda");

del -= delLamda; // removes delLamda from del
del("delLamda is removed");
del = del - delA; // removes delA
del("delA is removed");
#endregion

#region Generic Delegate
Utilities.CreateDivision("Generic Delegate");
GenericDeligate<string> genDelStr = ClassD.ReturnParamType;
genDelStr("Hello there!!!");
GenericDeligate<int> genDelInt = ClassD.ReturnParamType;
genDelInt(34);
GenericDeligate<Decimal> genDelDecimal = ClassD.ReturnParamType;
genDelDecimal(Decimal.MaxValue);
#endregion

#region In build delegate Func
// Func can take 0 to 16 parameter and the last one should be an out parameter.
// It is inside "System" namespace
Utilities.CreateDivision("Func delegate");
Func<int, int, int> add = ClassE.Sum;   // assigning the Func
int sum = add(2, 3);
Console.WriteLine("Sum result using Func delegate: " + sum);
// Func with lamda function.
Func<int, int, bool> greaterNumber = (int num1, int num2) => {  return num1 > num2; };
Console.WriteLine("first number is greater than second one? {0}", greaterNumber(4, 3));
#endregion

#region in-built delegate Action
// Action is similar to Func, only difference is, it does not return any value.
// Therefore it should be used with methods whose return type is void.
Utilities.CreateDivision("In-built delegate Action");
Action<int> actionDel = ClassF.PrintMessage;
actionDel(43);
Action<string> actionDel2 = ClassF.PrintMessage;
actionDel2("Hello there!!!");

// lamda Function
Action<int, int> actionDel3 = (int num1, int num2) => Console.WriteLine("sum of two numbers using Action delegate:: Sum = {0}", num1 + num2);
actionDel3(5, 4);
#endregion

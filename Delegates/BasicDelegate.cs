namespace Delegates
{
    public delegate void MyDeligate(string msg);
    public delegate void GenericDeligate<T>(T obj);

    public class ClassA
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("MethodA() is executed, with message: " + message);
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("MethodB() is executed, with message: " + message);
        }
    }

    public class ClassC
    {
        public static void InvokeDelegate(MyDeligate del)
        {
            del("Calling from InvokeDelegate.");
        }
    }

    public class ClassD
    {
        public static void ReturnParamType<T>(T obj) => Console.WriteLine($"Delegate is called using {obj.GetType()}");
    }

    public class ClassE
    {
        public static int Sum(int x, int y) => x + y;
    }

    public class ClassF
    {
        public static void PrintMessage<T>(T obj) => Console.WriteLine("Printing value using in-built Action delegate: {0}", obj);
    }
}

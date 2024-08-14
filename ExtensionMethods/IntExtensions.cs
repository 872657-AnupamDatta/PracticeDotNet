using System.Runtime.CompilerServices;

namespace ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsGreater(this int i, int value) => i > value;
        public static bool IsLesser(this int i, int value) => i < value;
    }

    public static class StringExtensions
    {
        public static void DisplayMsg(this string msg) => Console.WriteLine(msg);
    }

    public class ClassA
    {
        public void ShowName(string name) => Console.WriteLine("hi " + name);
    }

    public static class ExtensionOfClassA
    {
        public static void CallShowName(this ClassA obj) => obj.ShowName("New Name");
    }
}

namespace Linqs
{
    public class Utilities
    {
        public static void DisplayStudentDetails(List<Student> students)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.FullName}, Age: {student.Age}, State: {student.State}");
            }
        }

        public static void DisplayItems<TSource>(IEnumerable<TSource> items)
        {
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public static void DisplayBanner(string bannerName)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine($"==================== {bannerName} ==========================================");
            Console.WriteLine("==============================================================");
        }

        public static void DisplaySubBanner(string subBannerName)
        {
            Console.WriteLine($"==================== {subBannerName} ==========================================");
        }
    }
}

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
    }
}
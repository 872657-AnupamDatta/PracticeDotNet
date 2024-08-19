namespace Linqs
{
    public class Student
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string? State { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int ID { get; set; }
        public string StandardName { get; set; }
        public int StudentID { get; set; }
    }
}

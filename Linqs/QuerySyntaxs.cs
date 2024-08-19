namespace Linqs
{
    public class QuerySyntaxs
    {
        #region Where

        public List<Student> FindTeenAgers(List<Student> students)
        {
            var teenAgers = (from student in students where student.Age > 12 && student.Age < 20 select student).ToList();

            return teenAgers;
        }

        public List<Student> StudentsWithEvenIDs(List<Student> students)
        {
            Console.WriteLine("Students with Even IDs");
            var evenIDStudents = (from student in students where student.ID % 2 == 0 select student).ToList();
            return evenIDStudents;
        }
        #endregion Where

        #region Join
        public List<JoinResultModel> UseOfJoin(List<Student> studentList, IList<Standard> standardList)
        {
            List<JoinResultModel> joinResult = (from s in studentList
                             join st in standardList
                             on s.StandardID equals st.ID
                             select new JoinResultModel()
                             {
                                 StandardName = st.StandardName,
                                 StudentName = s.FullName,
                             }).ToList();
            return joinResult;
        }
        #endregion
    }
}

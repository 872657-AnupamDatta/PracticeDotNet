﻿namespace Linqs
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

        public IEnumerable<IGrouping<string, Student>> GroupStudentsByState(List<Student> students)
        {
            IEnumerable<IGrouping<string, Student>> groupsByState = students.GroupBy(student => student.State);

            return groupsByState;
        }

        public List<JoinResultModel> UseOfJoinFluent(List<Student> studentList, IList<Standard> standardList)
        {
            var joinResult = studentList.Join(
                                standardList,
                                student => student.StandardID,
                                standard => standard.ID,
                                (s, st) => new JoinResultModel()
                                {
                                    StandardName = st.StandardName,
                                    StudentName = s.FullName
                                }
                            ).ToList();

            return joinResult;
        }
    }
}
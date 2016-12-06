using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
    public class Student
    {
        public int StudentNr { get; set; }
        public string Name { get; set; }
    }

    public class Course
    {
        public int VakNr { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
    }

    public class Exam
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public decimal Score { get; set; }
    }

    public class TentamenCijfers
    {
        private static Student jan =        new Student() { StudentNr = 1, Name = "Jan" };
        private static Student piet =       new Student() { StudentNr = 2, Name = "Piet" };
        private static Student klaas =      new Student() { StudentNr = 3, Name = "Klaas" };
        private static Student katrijn =    new Student() { StudentNr = 4, Name = "Katrijn" };

        private static List<Student> students = new List<Student>() {
            jan, piet, klaas, katrijn
        };

        private static Course cSharp =  new Course() { VakNr = 1, Name = "C#", Teacher = "Joris" };
        private static Course math =    new Course() { VakNr = 2, Name = "Wiskunde", Teacher = "Jos" };
        private static Course coo =     new Course() { VakNr = 3, Name = "Computer Organisation", Teacher = "Sibbele" };
        private static Course se =      new Course() { VakNr = 4, Name = "Software Engineering", Teacher = "David" };
        private static Course python  = new Course() { VakNr = 5, Name = "Python", Teacher = "Wouter" };

        private static List<Course> courses = new List<Course>() {
            cSharp, math, coo, se, python
        };

        private static List<Exam> exams = new List<Exam>() {
            new Exam() { Student = jan,       Course = math,      Score = 3 },
            new Exam() { Student = piet,      Course = math,      Score = 5 },
            new Exam() { Student = jan,       Course = coo,       Score = 7 },
            new Exam() { Student = klaas,     Course = cSharp,    Score = 9 },
            new Exam() { Student = jan,       Course = cSharp,    Score = 5 },
            new Exam() { Student = jan,       Course = math,      Score = 6 },
            new Exam() { Student = katrijn,   Course = cSharp,    Score = 6 },
            new Exam() { Student = katrijn,   Course = coo,       Score = 6 },
            new Exam() { Student = piet,      Course = math,      Score = 8 },
            new Exam() { Student = piet,      Course = coo,       Score = 5 },
            new Exam() { Student = katrijn,   Course = se,        Score = 8 },
            new Exam() { Student = katrijn,   Course = se,        Score = 9.5m }
        };

        //Geef alle scores van een student, gebruik als argument de student naam
        [Test]
        public static void TestGetScoreByStudentName()
        {
            List<decimal> testlist1 = new List<decimal>() {3m, 7m, 5m, 6m};
            string studentNaam = "jan";

            Assert.AreEqual(testlist1, GetScoreByStudentName(studentNaam));

        }

        public static List<decimal> GetScoreByStudentName(string name) {
            List<decimal> resLijst = new List<decimal>();
            string resname = name.ToLower();

            foreach(Exam tentamen in exams)
            {
                if (tentamen.Student.Name.ToLower() == resname)
                {
                    resLijst.Add(tentamen.Score);
                }
            }
            return resLijst;
        }





        //Bepaal het hoogste behaalde resultaat van een student, gebruik als argument de student naam
        [Test]
        public static void TestGetHighestScoreByStudentName()
        {
            Assert.AreEqual(7m, GetHighestScoreByStudentName("jan"));
        }

        public static decimal GetHighestScoreByStudentName(string name)
        {
            string resname = name.ToLower();
            decimal maxgrade = 1;
            foreach(Exam tentamen in exams)
            {
                if (tentamen.Student.Name.ToLower() == resname)
                {
                    if (tentamen.Score > maxgrade)
                    {
                        maxgrade = tentamen.Score;
                    }
                }
            }
            return maxgrade;
        }

        //Welke studenten hebben alleen maar voldoendes gehaald?
        [Test]
        public static void TestGoodStudents()
        {
            List<Student> result = new List<Student>() {klaas,katrijn};
            Assert.AreEqual(result,GoodStudents());
        }

        public static List<Student> GoodStudents()
        {
            List <Student> badLeerlingen = new List<Student>();
            List<Student> goodLeerlingen = new List<Student>();
            
            foreach (Exam tentamen in exams)
            {
                if (tentamen.Score < 5.5m)
                {
                    badLeerlingen.Add(tentamen.Student);
                }
            }

            foreach (Exam tentamen in exams)
            {
                if (badLeerlingen.IndexOf(tentamen.Student) == -1)
                {
                    if (goodLeerlingen.IndexOf(tentamen.Student) == -1)
                    {
                        goodLeerlingen.Add(tentamen.Student);
                    }
                }
            }

           return goodLeerlingen;
        }

        //Voor welke vak zijn de meeste toetsen gedaan?
        [Test]
        public static void TestMostExamsByCourse()
        {
            Assert.AreEqual(math, MostExamsByCourse());
        }

        public static Course MostExamsByCourse()
        {
            string mostcoursename = string.Empty;
        
            List < string > vakken = new List<string>();
            List<int> counters = new List<int>();

            foreach(Exam tentamen in exams)
            {
                if (vakken.IndexOf(tentamen.Course.Name) == -1) vakken.Add(tentamen.Course.Name);
            }

            for (int it = 0; it < vakken.Count; it++)
            {
                int count = 0;
                foreach (Exam tentamen in exams)
                {

                    count = 0;

                    for (int i = 0; i < vakken.Count; i++)
                    {
                        if (tentamen.Course.Name == vakken[i])
                        {
                            count++;
                        }
                    }

                }
                counters.Add(count);
            }

            int max = -1;
            foreach(int num in counters)
            {
                if (max == -1)
                {
                    max = num;
                }
                else
                {
                    if (num > max) max = num; 
                }
            }


            mostcoursename = vakken[counters.IndexOf(max)];
            Course mostcourse = new Course();

            foreach (Exam tentamen in exams)
            {
                if(tentamen.Course.Name == mostcoursename)
                {
                    mostcourse = tentamen.Course;
                    break;
                }
            }

            return mostcourse;

        }

        //Bepaal voor iedere student zijn gemiddelde score 
        //Pittig
        [Test]
        public static void TestGetAverageScoreByStudent()
        {
            List < StudentAverage > gemiddeldesTest = new List<StudentAverage>();
            new StudentAverage() { Name = "Jan", Score = 5.25m };
            Assert.AreEqual(gemiddeldesTest, GetAverageScoreByStudent("Jan"));
        }

        public class StudentAverage
        {
            public String Name { get; set; }
            public decimal Score { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is StudentAverage)
                {
                    StudentAverage s = (StudentAverage)obj;
                    return Name == s.Name && Score == s.Score;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode() + Score.GetHashCode();
            }
        }

        public static List<StudentAverage> GetAverageScoreByStudent(string name)
        {
            List<StudentAverage> res = new List<StudentAverage>();
            string nameres = name.ToLower();

            decimal sum = 0m;
            decimal count = 0;

            foreach(Exam tentamen in exams)
            {
                if (tentamen.Student.Name.ToLower() == nameres)
                {
                    sum = sum + tentamen.Score;
                    count++;
                }
            }

            decimal resgem = sum / count;





            new StudentAverage() { Name = name, Score = resgem};
            return res;

        }

        //Pittig: Hoeveel herkansingen zijn er gedaan?
        //Een herkansing is een toest die nog een keer is gedaan door dezelfde student
        [Test]
        public static void TestNumberOfResits()
        {
            Assert.AreEqual(3, NumberOfResits());
        }

        public static int NumberOfResits()
        {
            int herkansingen = 0;
            foreach (Course c in courses)
            {
                foreach (Student s in students)
                {
                    int count = 0;
                    foreach (Exam e in exams)
                    {
                        if (s == e.Student && c.Name == e.Course.Name)
                        {
                            count++;
                        }
                    }
                    if (count >= 2)
                    {
                        herkansingen++;
                    }
                }
            }
            return herkansingen;
        }
    }
}

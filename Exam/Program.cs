using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exams
{

    static class Program
    {
       
        public static void Main()
        {
            
            var  stud = new Student(
                new Person("Bohdan", "Petrashchuk", new DateTime(2000, 03, 07)),
                Education.Вachelor,
                351
                
            );
            Console.WriteLine(stud.ToShortString());
            Console.WriteLine("Type Education:");

            
            foreach (Education element in Enum.GetValues(typeof(Education)))
                Console.WriteLine($"{element} = {stud[element]}");

            Console.WriteLine("");
            


            Console.WriteLine("Information about session this studpid student");

            
            stud.AddExams(
                new Exam("C#", 100, new DateTime(2020, 06, 10)),
                new Exam("WEB", 100, new DateTime(2020, 06, 12)),
                new Exam("ODOO", 90, new DateTime(2020, 06, 14)),
                new Exam("Magento2", 99, new DateTime(2020, 06, 18)),
                new Exam("PHP", 99, new DateTime(2020, 06, 20)));
          
            Console.WriteLine(stud);
            Console.WriteLine("");

            Console.ReadLine();
        }
        public class Person
        {
            public string Name { get; set; } 
            public string Surname { get; set; } 
            public DateTime Birthday { get; set; }

            public int BirthYear 
            {
                get => this.Birthday.Year;
                set => this.Birthday = new DateTime(value, this.Birthday.Month, this.Birthday.Day);
            }

            public Person(string name, string surname, DateTime birthday) 
            {
                this.Name = name;
                this.Surname = surname;
                this.Birthday = birthday;
            }

            public Person() 
            {
                this.Name = "";
                this.Surname = "";
                this.Birthday = new DateTime();
            }

           
            public override string ToString() => $"{this.Name} {this.Surname} [{this.Birthday:dd.MM.yy}]";

            
            public virtual string ToShortString() => $"{this.Name} {this.Surname}";
        }

        public enum Education 
        {
            Specialist,
            Вachelor,
            SecondEducation
        }

        public class Exam
        {
            public string Subject { get; set; }
            public int Mark { get; set; } 
            public DateTime Date { get; set; } 

            public Exam(string subject, int mark, DateTime date) 
            {
                this.Subject = subject;
                this.Mark = mark;
                this.Date = date;
            }

            public override string ToString() => $"{this.Subject}[{this.Date:dd.MM.yy}] = {this.Mark} ";
        }
        public class Student 
        {
            public Education Education { get; private set; } 
            public List<Exam> Exams { get; private set; } 
            public int GroupNumber { get; private set; } 
            public Person Person { get; private set; } 

            public bool this[Education ed] => this.Education == ed; 
                                                                   
            public double AverageMark
            {
                
                get
                {
                    return Exams.Any()
                        ? Exams.Where(x => !string.IsNullOrWhiteSpace(x.Subject)).Average(x => x.Mark): 0;
                }
            }

            public Student(Person person, Education education, int group_number) 
            {
                this.Person = person;
                this.Education = education;
                this.GroupNumber = group_number;
                this.Exams = new List<Exam>();
            }

            public Student() 
            {
                this.Person = new Person();
                this.GroupNumber = 0;
                this.Exams = new List<Exam>();
            
            }

            
            public void AddExams(params Exam[] exams)
            {
                this.Exams.AddRange(exams);
            }

            
            public override string ToString()
            {
                var sb = new StringBuilder($"{this.Person.ToShortString()}:");
                sb.AppendLine($"Date of Birthday: {this.Person.Birthday}");
                sb.AppendLine($"Group: {this.GroupNumber}");
                sb.AppendLine($"Education: {this.Education}");
                sb.AppendLine($"Avg mark: {this.AverageMark}");
                sb.AppendLine($"Exams: ");
                sb.AppendLine($"    Subject " + "Date" + "   Mark");

                foreach (var exam in this.Exams)
                    sb.AppendLine($"    {exam}");

                return sb.ToString();
            }

            
            public virtual string ToShortString()
            {   
                var sb = new StringBuilder($"{this.Person.ToShortString()}:");
              
                sb.AppendLine($"Date of Birthday: {this.Person.Birthday}");
                sb.AppendLine($"Group: {this.GroupNumber}");
                sb.AppendLine($"Education: {this.Education}");
                sb.AppendLine($"Avg mark: {this.AverageMark}");

                return sb.ToString();
            }
        }
    }
}
    



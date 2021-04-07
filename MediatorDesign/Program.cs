using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher engin = new Teacher(mediator);
            engin.Name = "Engin";
            mediator.Teacher = new Teacher(mediator);
            Student ahmet = new Student(mediator);
            ahmet.Name = "Ahmet";
            mediator.Students = new List<Student> { ahmet };
            
            mediator.Teacher = engin;
            mediator.Students.Add(ahmet);

            engin.RecieveQuestion("How much?", ahmet);

            engin.SendNewImageUrl("Image1.jpg");

            Console.ReadLine();
        }
    }
    public abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }
    public class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Öğretmen soruyu kabul etti from {0}, {1}", student.Name, question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Öğretmen image'ı güncelledi : {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerTheQuestion(string answer, Student student)
        {
            Console.WriteLine("Öğretmen soruyu cevapladı {0}, {1}", student.Name, answer);
        }
    }
    public class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("Öğrenci image'i aldı {0}", url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Öğrenci cevabı aldı {0}", answer);
        }
    }
    public class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }
        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }
        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}

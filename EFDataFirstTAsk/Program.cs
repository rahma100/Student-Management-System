using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstTAsk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new UniversityDBEntities();

            //Department department= new Department
            //{
            //    Name="IT",
            //    OfficeLocation="Building B"
            //};
            //context.Departments.Add(department);
            //context.SaveChanges();


            //teacher 

            //Teacher teacher = new Teacher
            //{
            //    FullName = "Ahmed",
            //    Email = "Ahmed@gmail.com",
            //    HireDate= DateTime.Now,
            //    DepartmentId=1
            //};
            //context.Teachers.Add(teacher);
            //context.SaveChanges();

            //Teacher teacher2 = new Teacher
            //{
            //    FullName = "Ali",
            //    Email = "Ali@gmail.com",
            //    HireDate = new DateTime(2025,9,1),
            //    DepartmentId = 2
            //};
            //context.Teachers.Add(teacher2);
            //context.SaveChanges();


            //Teacher teacher3 = new Teacher
            //{
            //    FullName = "Rahma",
            //    Email = "Rahma@gmail.com",
            //    HireDate = new DateTime(2024, 10, 1),
            //    DepartmentId = 1
            //};
            //context.Teachers.Add(teacher3);
            //context.SaveChanges();


            //----------------------------------------------------Course


            //Course course = new Course
            //{
            //    Title = "Machine learning",
            //    Credits = 3,

            //    DepartmentId = 1
            //};
            //context.Courses.Add(course);
            //context.SaveChanges();


            //Course course2 = new Course
            //{
            //    Title = "Deep learning",
            //    Credits = 3,

            //    DepartmentId = 1
            //};
            //context.Courses.Add(course2);
            //context.SaveChanges();

            //Course course3 = new Course
            //{
            //    Title = "NetWorking",
            //    Credits = 3,

            //    DepartmentId = 2
            //};
            //context.Courses.Add(course3);
            //context.SaveChanges();


            //----------------------------------------Teacher Course

            //TeacherCourse teacherCourse = new TeacherCourse
            //{
            //    TeacherId = 1,
            //    CourseId = 1
            //};
            //context.TeacherCourses.Add(teacherCourse);


            //TeacherCourse teacherCourse2 = new TeacherCourse
            //{
            //    TeacherId = 2,
            //    CourseId = 2
            //};
            //context.TeacherCourses.Add(teacherCourse2);

            //TeacherCourse teacherCourse3 = new TeacherCourse
            //{
            //    TeacherId = 3,
            //    CourseId = 3
            //};
            //context.TeacherCourses.Add(teacherCourse3);



            //context.SaveChanges();



            //--------------------------------------------------------------------Student

            //Student St1 = new Student
            //{
            //    FullName = "Jana",
            //    Email = "Jana@gmail.com",
            //    EnrollmentDate= DateTime.Now,
            //};
            //context.Students.Add(St1);

            //Student St2 = new Student
            //{
            //    FullName = "Sondos",
            //    Email = "Sondos@gmail.com",
            //    EnrollmentDate = DateTime.Now,
            //};
            //context.Students.Add(St2);

            //Student St3 = new Student
            //{
            //    FullName = "Salma",
            //    Email = "Salma@gmail.com",
            //    EnrollmentDate = new DateTime(2026,5,11),
            //};
            //context.Students.Add(St3);

            //Student St4 = new Student
            //{
            //    FullName = "Rana",
            //    Email = "rana@gmail.com",
            //    EnrollmentDate = new DateTime(2026, 7, 5),
            //};
            //context.Students.Add(St4);
            //context.SaveChanges();


            //-----------------------------------------Enroll

            //Enrollment EnSt1 = new Enrollment
            //{
            //    StudentId = 1,
            //    CourseId = 1,
            //    EnrollmentDate = new DateTime(2026, 7, 5),
            //    Grade=66
            //};
            //context.Enrollments.Add(EnSt1);

            //Enrollment EnSt2 = new Enrollment
            //{
            //    StudentId = 2,
            //    CourseId = 1,
            //    EnrollmentDate = new DateTime(2026, 7, 5),
            //    Grade = 80
            //};
            //context.Enrollments.Add(EnSt2);


            //Enrollment EnSt3 = new Enrollment
            //{
            //    StudentId = 3,
            //    CourseId = 2,
            //    EnrollmentDate = new DateTime(2026, 7, 5),
            //    Grade = 80
            //};
            //context.Enrollments.Add(EnSt3);


            //Enrollment EnSt4 = new Enrollment
            //{
            //    StudentId = 4,
            //    CourseId = 2,
            //    EnrollmentDate = new DateTime(2026, 7, 5),
            //    Grade = 90
            //};
            //context.Enrollments.Add(EnSt4);

            //context.SaveChanges();

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++Read 
            var courses = context.Courses
                .Include(c => c.Department)
                .Include(c => c.TeacherCourses.Select(tc => tc.Teacher))
                 .ToList();

            foreach (var course in courses)
            {
                Console.WriteLine("Course: " + course.Title);
                Console.WriteLine("Department: " + course.Department.Name);

                Console.WriteLine("Teachers:");

                foreach (var tc in course.TeacherCourses)
                {
                    Console.WriteLine("- " + tc.Teacher.FullName);
                }

                Console.WriteLine("--------------------");
            }


            //2
         
            var enrollment = context.Enrollments
                .Include(s => s.Student)
                .Include(s => s.Course);
                

            foreach (var student in enrollment) {
                Console.WriteLine("Studnet Name :"+ student.Student.FullName);
                Console.WriteLine("Studnet Course: "+ student.Course.Title);
                Console.WriteLine("Studnet Grade: " + student.Grade);
                Console.WriteLine("Studnet Dep: "+student.Course.Department.Name);


            }
            //3
            Console.WriteLine("++++++++++++++++++++++++++++++++3++++++++++++++++++++++++++++++++");

            var teacher = context.Teachers
               .Include(t => t.Department);

            foreach (var item in teacher) {
                Console.WriteLine(item.FullName);
                Console.WriteLine(item.Department.Name);
               
                
            }
            //4
            Console.WriteLine("++++++++++++++++++++++++++++++++4++++++++++++++++++++++++++++++++");

            var dep = context.Departments.ToList();

            foreach (var item in dep)
            {

               var  teacherCount = item.Teachers.Count;
                var courcesCount = item.Courses.Count;
                Console.WriteLine("Department: " + item.Name);
                Console.WriteLine("Techer Count : " + teacherCount);
                Console.WriteLine("Cources Count : " + courcesCount);

            }

            Console.WriteLine("Update ----------1--------------------------");

            var enrollmentUpdate = context.Enrollments
                .FirstOrDefault(
                e=>e.StudentId==1 &&e.CourseId==1
                );
            if (enrollmentUpdate != null)
            {
                enrollmentUpdate.Grade = 95;
                context.SaveChanges();
                Console.WriteLine("Grade Updated Successfully");
            }
            else
            {
                Console.WriteLine("Not Found ");
            }

            //2
            Console.WriteLine("Update ----------2-------------------------");

            var TeacherUpdate = context.Teachers
               .FirstOrDefault(e=>
                e.TeacherId==1
                );
               
            if (TeacherUpdate != null)
            {
                TeacherUpdate.DepartmentId = 2;
                context.SaveChanges();
                Console.WriteLine("Teacher Department  Updated Successfully");
            }
            else
            {
                Console.WriteLine("Not Found ");
            }


            var courseUpdate = context.Courses
                 .FirstOrDefault(c => c.CourseId == 1);

            if (courseUpdate != null)
            {
                courseUpdate.Credits = 4;

                context.SaveChanges();

                Console.WriteLine("Course credits updated.");
            }


            Console.WriteLine("Delete _______________________________________________");
            //1
            var StDel = context.Students
                .FirstOrDefault(s => s.StudentId == 1);
            if (StDel != null)
            {
                context.Enrollments.RemoveRange(StDel.Enrollments);
                context.Students.Remove(StDel);
                context.SaveChanges();
                Console.WriteLine("Deleted ");

            }
            else
            {
                Console.WriteLine("Not Found");
            }

            //2

            var DelCourse = context.Courses
                .FirstOrDefault(e => e.CourseId == 1);
            if (DelCourse != null) {
                bool hasStudent = DelCourse.Enrollments.Any();
                if (!hasStudent) {
                    context.TeacherCourses.RemoveRange(DelCourse.TeacherCourses);
                    context.Courses.Remove(DelCourse);
                    context.SaveChanges();
                    Console.WriteLine("Course Deleted");

                }
                else
                {
                    Console.WriteLine("Not found");
                }
            
            }



        }
    }
}

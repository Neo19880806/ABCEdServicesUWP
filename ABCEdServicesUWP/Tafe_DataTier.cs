using ABCEdServicesUWP.DBServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCEdServicesUWP
{
    class Tafe_DataTier
    {
        private IDBService proxy;
        public Tafe_DataTier()
        {

            proxy = new DBServiceRef.DBServiceClient(DBServiceClient.EndpointConfiguration.MybasicHttpBinding);

        }


        public async Task<int> insertStudent(string id, string name, DateTime dateEnrolled)
        {
            int rowsUpdated;
            try
            {
                rowsUpdated = await proxy.InsertAStudentAsync(new Student
                {
                    StudentID = id,
                    StduentName = name,
                    DateEnrolled = dateEnrolled
                });
            }
            catch (Exception)
            {
                rowsUpdated = -1;
            }

            return rowsUpdated;
        }



        public async Task<int> insertCourse(string id, string name, Decimal cost)
        {
            int rowsUpdated;
            try
            {
                rowsUpdated = await proxy.InsertACourseAsync(new Course
                {
                    CourseID = id,
                    CourseName = name,
                    Cost = cost
                });
            }
            catch (Exception)
            {
                rowsUpdated = -1;
            }

            return rowsUpdated;
        }


        public async Task<List<Student>> viewStudents()
        {
            List<Student> list = await proxy.GetAllStudentsAsync();
            return list;
        }

        public async Task<List<Course>> viewCourses()
        {
            List<Course> list = await proxy.GetAllCoursesAsync();
            return list;
        }


        public async Task<int> enroll(String courseID, String studentID)
        {

            int rowsUpdated;
            try
            {
                rowsUpdated = await proxy.InsertEnrolmentAsync(new Enrollment
                {
                    StudentID = studentID,
                    CourseID = courseID,
                    Grade = "NR"
                });
            }
            catch (Exception)
            {
                rowsUpdated = -1;
            }

            return rowsUpdated;
        }

        public async Task<List<Course>> getEnrollmentsForStudent(string studentID)
        {
            var list = await proxy.GetEnrollmentsForStudentAsync(studentID);
            return list;
        }

        public async Task<List<Student>> getStudentsEnrolledInCourse(string courseID)
        {
            var list = await proxy.getStudentsEnrolledInCourseAsync(courseID);
            return list;

        }
    }
}

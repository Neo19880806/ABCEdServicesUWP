using ABCEdServicesUWP.DBServiceRef;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ABCEdServicesUWP
{
    public sealed partial class frmViewEnrollments : ContentDialog
    {
        private List<Course> courseList;
        public frmViewEnrollments()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            courseList = await dt.viewCourses();


            foreach (Course c in courseList)
            {
                cbCourses.Items.Add(c.CourseID.ToString()); ;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private async void cbCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbStudents.Items.Clear();
            string id = cbCourses.SelectedItem.ToString();
            this.txtName.Text = (courseList.Where(c => c.CourseID == id).FirstOrDefault()).CourseName;
            this.txtCost.Text = (courseList.Where(c => c.CourseID == id).FirstOrDefault()).Cost.ToString("C");

            Tafe_DataTier dt = new Tafe_DataTier();
            var studList = await dt.getStudentsEnrolledInCourse(id);
            if (studList.Count() <= 0)
            {
                lbStudents.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else
            {
                foreach (var s in studList)
                {
                    this.lbStudents.Items.Add(s.StudentID + "-->" + s.StduentName);
                }
            }
        }
    }
}

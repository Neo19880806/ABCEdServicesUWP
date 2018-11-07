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
    public sealed partial class frmStudentTT : ContentDialog
    {
        private List<Student> studList;
        public frmStudentTT()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            studList = await dt.viewStudents();


            foreach (Student s in studList)
            {
                cbStudents.Items.Add(s.StudentID.ToString()); ;
            }
        }

        private async void cbStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbCourses.Items.Clear();
            string id = cbStudents.SelectedItem.ToString();
            txtName.Text = (studList.Where(s => s.StudentID == id).FirstOrDefault()).StduentName;
            txtDateEnrolled.Text = (studList.Where(s => s.StudentID == id).FirstOrDefault()).DateEnrolled.ToString("d");

            Tafe_DataTier dt = new Tafe_DataTier();
            var enrollmentList = await dt.getEnrollmentsForStudent(id);

            if (enrollmentList.Count() <= 0)
            {
                lbCourses.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else
            {
                foreach (var enroll in enrollmentList)
                {
                    lbCourses.Items.Add(enroll.CourseID);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

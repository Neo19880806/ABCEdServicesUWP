using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ABCEdServicesUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void controlsButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnStudentAdmin_Click(object sender, RoutedEventArgs e)
        {
            gridStudent.Visibility = Visibility.Visible;
            gridCourse.Visibility = Visibility.Collapsed;
        }

        private void btnCourseAdmin_Click(object sender, RoutedEventArgs e)
        {
            gridCourse.Visibility = Visibility.Visible;
            gridStudent.Visibility = Visibility.Collapsed;
        }

        private async void btnNewStudents_Click(object sender, RoutedEventArgs e)
        {
            await new frmNewStudents().ShowAsync();
        }

        private async void btnViewStudents_Click(object sender, RoutedEventArgs e)
        {
            await new frmStudents().ShowAsync();
        }

        private async void btnTimeTable_Click(object sender, RoutedEventArgs e)
        {
            await new frmStudentTT().ShowAsync();
        }

        private async void btnNewCourses_Click(object sender, RoutedEventArgs e)
        {
            await new frmNewCourses().ShowAsync();
        }

        private async void btnViewCourses_Click(object sender, RoutedEventArgs e)
        {
            await new frmCourses().ShowAsync();
        }

        private async void btnEnrollStudent_Click(object sender, RoutedEventArgs e)
        {
            await new frmEnroll().ShowAsync();
        }

        private async void btnViewEnrollments_Click(object sender, RoutedEventArgs e)
        {
            await new frmViewEnrollments().ShowAsync();
        }

        private async void btnDisplayBill_Click(object sender, RoutedEventArgs e)
        {
            await new frmBilling().ShowAsync();
        }
    }
}

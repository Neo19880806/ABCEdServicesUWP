using ABCEdServicesUWP.DBServiceRef;
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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ABCEdServicesUWP
{
    public sealed partial class frmStudents : ContentDialog
    {
        private List<Student> studList;
        public frmStudents()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            studList = await dt.viewStudents();

            foreach (Student s in studList)
            {
                lbStudents.Items.Add(s.StudentID.ToString() + "-->" + s.StduentName.ToString()); ;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

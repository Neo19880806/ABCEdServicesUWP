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
    public sealed partial class frmNewStudents : ContentDialog
    {
        private List<Student> studList;
        public frmNewStudents()
        {
            this.InitializeComponent();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            int rowsInserted = await dt.insertStudent(txtID.Text, txtName.Text, dtpEnrollment.Date.DateTime);
            if (rowsInserted > 0)
            {
                await new MessageDialog("Add Student", "New Student Information Saved").ShowAsync();
            }
            else
            {
                await new MessageDialog("Add Student", "New Student Information NOT Saved").ShowAsync();
            }
        }
    }
}

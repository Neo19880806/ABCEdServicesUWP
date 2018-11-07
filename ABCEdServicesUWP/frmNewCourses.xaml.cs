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
    public sealed partial class frmNewCourses : ContentDialog
    {
        private List<Student> studList;
        public frmNewCourses()
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

            if (this.validateData())
            {
                try
                {
                    int rowsInserted = await dt.insertCourse(txtID.Text, txtName.Text, Decimal.Parse(txtCost.Text));
                    if (rowsInserted > 0)
                    {
                        await new MessageDialog("Add Course", "New Course Information Saved").ShowAsync();
                    }
                    else
                    {
                        await new MessageDialog("Add Course", "New Course Information NOT Saved").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog("ERROR", ex.Message).ShowAsync();
                }
            }
        }

        private bool validateData()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
                return false;
            if (string.IsNullOrEmpty(txtID.Text))
                return false;
            if (string.IsNullOrEmpty(txtName.Text))
                return false;
            else
                return true;
        }
    }
}

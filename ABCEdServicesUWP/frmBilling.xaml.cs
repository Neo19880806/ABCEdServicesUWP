﻿using ABCEdServicesUWP.DBServiceRef;
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
    public sealed partial class frmBilling : ContentDialog
    {
        private List<Student> studList;
        private Tafe_DataTier dt;
        public frmBilling()
        {
            this.InitializeComponent();
            dt = new Tafe_DataTier();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            studList = await dt.viewStudents();
            foreach (Student s in studList)
            {
                cbStudents.Items.Add(s.StudentID.ToString()); ;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private async void cbStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbCourses.Items.Clear();
            string id = cbStudents.SelectedItem.ToString();
            this.txtName.Text = (studList.Where(s => s.StudentID == id)).FirstOrDefault().StduentName;

            dt = new Tafe_DataTier();
            List<Course> courseList = await dt.getEnrollmentsForStudent(id);

            Decimal total = 0.0M;
            if (courseList.Count() <= 0)
            {
                lbCourses.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else
            {
                foreach (var c in courseList)
                {
                    lbCourses.Items.Add(c.CourseName);
                    total = total + c.Cost;
                }
            }
            txtCost.Text = total.ToString("C");
        }
    }
}

using GravitonLibrary;
using GravitonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GravitonUI
{
    /// <summary>
    /// Create Cost Categories
    /// </summary>
    public partial class CostCategoryCreationForm : Window
    {
        public CostCategoryCreationForm()
        {
            InitializeComponent();
        }

        // Validates And Creates Cost Category
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateLoginForm())
            {
                CostCategoryModel model = new CostCategoryModel();
                model.category_name = NameInputTextBox.Text;
                model.category_alias = AliasInputTetxBox.Text;
                if(RevenueItemCheckBox.IsChecked == true)
                {
                    model.revenue = true;
                }
                else
                {
                    model.revenue = false;
                }
                GlobalConfig.Connection.CreateCategory(model);
            }
            else
            {
                MessageBox.Show("Please Fill in the Details Properly!");
            }
        }

        // Validate the login Form
        private bool ValidateLoginForm()
        {
            bool output = true;
            if(NameInputTextBox.Text.Length == 0)
            {
                output = false;
            }
            if(AliasInputTetxBox.Text.Length == 0)
            {
                output = false;
            }
            if(RevenueItemCheckBox.IsChecked == false && NonRevenueItemCheckBox.IsChecked == false)
            {
                output = false;
            }
            //if (NonRevenueItemCheckBox.IsChecked == null)
            //{
            //    output = false;
            //}
            return output;
        }
    }
}

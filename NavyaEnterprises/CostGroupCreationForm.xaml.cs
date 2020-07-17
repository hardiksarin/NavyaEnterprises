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
    /// Creates Groups
    /// </summary>
    public partial class CostGroupCreationForm : Window
    {
        private List<GroupModel> availableGroups = new List<GroupModel>();
        public CostGroupCreationForm()
        {
            GlobalConfig.InitializeConnections();
            InitializeComponent();
            LoadListData();
            WireUpLists();
        }

        //Load Group Data
        private void LoadListData()
        {
            availableGroups = GlobalConfig.Connection.GetGroups_All();
        }

        //Initialise the combo box to list of groups.
        private void WireUpLists()
        {
            UnderComboBox.ItemsSource = null;

            UnderComboBox.ItemsSource = availableGroups;
            UnderComboBox.DisplayMemberPath = "group_name";
        }

        //Validate And Create Groups
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                GroupModel model = new GroupModel();
                GroupModel selectedGroup = (GroupModel)UnderComboBox.SelectedItem;

                model.group_name = NameInputTextBox.Text;
                model.group_alias = AliasInputTetxBox.Text;
                model.under_group = selectedGroup.group_id;

                GlobalConfig.Connection.CreateGroup(model);
            }
            else
            {
                MessageBox.Show("Please Fill in the Details Properly!");
            }
        }

        // Validate the login Form
        private bool ValidateForm()
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
            if(UnderComboBox.SelectedItem == null)
            {
                output = false;
            }
            return output;
        }
    }
}

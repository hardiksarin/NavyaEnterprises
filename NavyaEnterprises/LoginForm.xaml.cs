using GravitonLibrary;
using GravitonLibrary.Models;
using GravitonUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavyaEnterprises
{
    /// <summary>
    /// Login Form for Graviton
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GlobalConfig.InitializeConnections();
            InitializeComponent();
        }

        //Validate and check Login Credentials
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateLoginForm())
            {
                LoginModel model = new LoginModel();
                List<LoginModel> outputs = new List<LoginModel>();

                model.email_id = UsernameInputBox.Text;
                model.password = PasswordInputBox.Password;
                model.access = "Admin";
                //Debug.WriteLine(model.password);
                outputs = GlobalConfig.Connection.CheckLogin(model);

                foreach (LoginModel login in outputs)
                {
                    if(login.email_id.Equals(model.email_id) && login.password.Equals(model.password))
                    {
                        this.Hide();
                        CostCategoryCreationForm form = new CostCategoryCreationForm();
                        form.Closed += (sender, e) => this.Close();
                        form.Show();
                    }
                }
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
            if(UsernameInputBox.Text.Length == 0)
            {
                output = false;
            }
            if(PasswordInputBox.Password.ToString().Length == 0)
            {
                output = true;
            }
            if(PasswordInputBox.Password.ToString().Length < 4)
            {
                output = false;
            }
            return output;
        }
    }
}

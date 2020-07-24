using GravitonLibrary;
using GravitonLibrary.Models;
using GravitonUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public BackgroundWorker worker;
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
                    if (login.email_id.Equals(model.email_id) && login.password.Equals(model.password))
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
            //getLoaderConnection();
        }

        // Validate the login Form
        private bool ValidateLoginForm()
        {
            bool output = true;
            if (UsernameInputBox.Text.Length == 0)
            {
                output = false;
            }
            if (PasswordInputBox.Password.ToString().Length == 0)
            {
                output = true;
            }
            if (PasswordInputBox.Password.ToString().Length < 4)
            {
                output = false;
            }
            return output;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (ValidateLoginForm())
            //{
            //    LoginModel model = new LoginModel();
            //    List<LoginModel> outputs = new List<LoginModel>();

            //    model.email_id = UsernameInputBox.Text;
            //    model.password = PasswordInputBox.Password;
            //    model.access = "Admin";
            //    //Debug.WriteLine(model.password);
            //    outputs = GlobalConfig.Connection.CheckLogin(model);

            //    foreach (LoginModel login in outputs)
            //    {
            //        if (login.email_id.Equals(model.email_id) && login.password.Equals(model.password))
            //        {
            //            this.Hide();
            //            CostCategoryCreationForm form = new CostCategoryCreationForm();
            //            form.Closed += (sender, e) => this.Close();
            //            form.Show();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please Fill in the Details Properly!");
            //}

            long sum = 0;
            long total = 100000;
            for (long i = 1; i <= total; i++)
            {
                sum += i;
                int percentage = Convert.ToInt32(((double)i / total) * 100);
                Dispatcher.Invoke(new System.Action(() =>
                {
                    worker.ReportProgress(percentage);
                }));
            }
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MyProgressBar.Visibility = Visibility.Collapsed;
            MyProgressLabel.Visibility = Visibility.Collapsed;
            LoginButton.IsEnabled = true;
        }

        //private void getLoaderConnection()
        //{
        //    MyProgressBar.Visibility = Visibility.Visible; //Make Progressbar visible
        //    MyProgressLabel.Visibility = Visibility.Visible; //Make TextBlock visible
        //    LoginButton.IsEnabled = false; //Disabling the button
        //    worker = new BackgroundWorker(); //Initializing the worker object
        //    worker.ProgressChanged += Worker_ProgressChanged; //Binding Worker_ProgressChanged method
        //    worker.DoWork += Worker_DoWork; //Binding Worker_DoWork method
        //    worker.WorkerReportsProgress = true; //telling the worker that it supports reporting progress
        //    worker.RunWorkerCompleted += Worker_RunWorkerCompleted; //Binding worker_RunWorkerCompleted method
        //    worker.RunWorkerAsync(); //Executing the worker
        //}
    }
}

using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data.SqlClient;


namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string sqlinst;
        public string DB;
        public string DBpass;
        static string constr = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Setting"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LOGINButton_Copy1_Click(object sender, RoutedEventArgs e)
        {
            //sqlinst = txtSqlInst.Text;
            //DB = txtDB.Text;
            //DBpass = txtDBPass.Text;
           var consucessful = "------- Connectivity Succeeded ✅ --------";

           
            try
            {
                con.Open();
                MessageBox.Show(consucessful);
               

            }
            catch(Exception exceptions) {
                
                MessageBox.Show("------ 404 CONNECTION ERROR --------"+exceptions.ToString());
            }
            con.Close();
        }

        private void SimpleButton4_Click(object sender, RoutedEventArgs e)
        {
            //  MainWindow = new MainWindow();
            this.Close();
        }

        private void SimpleButton2_Click(object sender, RoutedEventArgs e)
        {
            //this.WindowState = Properties.Settings.Default.X1State;
            // this.WindowState{m};
            // this.WindowState{ Height = 1024; width = 768; };
            //MainWindow = new MainWindow();
           // POS.MainWindow.wid

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (TxtLoginID.Text == "PLEASE LOGIN HERE . . ." && txtLoginPassword.Text == "ENTER PASSWORD. . .")
            //{
            //    TxtLoginID.Text = "";
            //    txtLoginPassword.Text = "";
            //}

           
            //else
            //{
            //    TxtLoginID.Text = "PLEASE LOGIN HERE . . .";
            //    txtLoginPassword.Text = "ENTER PASSWORD . . .";
            //}
        }

        private void TxtLoginID_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtLoginID.Text.Contains("PLEASE LOGIN HERE . . .") && txtLoginPassword.Text.Contains("ENTER PASSWORD. . ."))
            {
                TxtLoginID.Text = "";
                txtLoginPassword.Text = "";
            }
            else
            { };

            //else
            //{
            //    TxtLoginID.Text = "PLEASE LOGIN HERE . . .";
            //    txtLoginPassword.Text = "ENTER PASSWORD . . .";
            //}
        }

        private void TxtLoginPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtLoginID.Text.Contains("PLEASE LOGIN HERE . . .") && txtLoginPassword.Text.Contains("ENTER PASSWORD. . ."))
            {
                TxtLoginID.Text = "";
                txtLoginPassword.Text = "";
            }
            else { };



            //else
            //{
            //    TxtLoginID.Text = "PLEASE LOGIN HERE . . .";
            //    txtLoginPassword.Text = "ENTER PASSWORD . . .";
            //}
        }
    }
}

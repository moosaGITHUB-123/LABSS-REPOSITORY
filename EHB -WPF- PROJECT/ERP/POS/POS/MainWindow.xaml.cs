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
using System.Data;
using POS.DBClasses;
using System.Collections.ObjectModel;

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
            /////////   Testing  form  opening   //////
            Window_khizer fm = new Window_khizer();
            fm.Show();
            /////////   Testing  form  Closed   //////


            //sqlinst = txtSqlInst.Text;
            //DB = txtDB.Text;
            //DBpass = txtDBPass.Text;
    //         var consucessful = "------- Connectivity Succeeded ✅ --------";    Not in Use temporary


            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {


                    con.Open();
    //              MessageBox.Show(consucessful); Not in Use temporary
                    con.Close();
                }

            }
            catch (Exception ) {

                MessageBox.Show("------ 404 CONNECTION ERROR --------" .ToString());
            }
             
             
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void SimpleButton4_Click(object sender, RoutedEventArgs e)
        {
            //  MainWindow = new MainWindow();
            this.Close();
        }

        private void SimpleButton2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ///////////  Login  Sp Calling Below   ////////////

                con.Open();

                SqlCommand cmd = new SqlCommand("spLoginCheck", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoginUserName", SqlDbType.VarChar).Value = TxtLoginID.Text.Trim();
                cmd.Parameters.AddWithValue("@LoginUserPass", SqlDbType.VarChar).Value = txtLoginPassword.Text.Trim();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    string username = rd.GetString(0);
                    int usertype = rd.GetInt32(2);
                    string userType = rd.GetString(3);
                    Home hm = new Home();
                    hm.logginusername = username;
                    hm.logginusertype = userType;
                    hm.Show();
                    this.Close();

                }



            }


            catch (Exception) { }

        }

        private void SimpleButtonMove_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void LOGINButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            Home fm = new Home();
            fm.Show();

         }

        private void SwitchTheme_Checked(object sender, RoutedEventArgs e)
        { }


              public String ThemeChangeToWhite = "White";
    }

        ///////////  Theme  Sp Calling Below   ////////////
        //if (SwitchTheme.IsChecked == true)
        //{
        //    con.Open();
        //}
        //else { };

        //SqlCommand cmd = new SqlCommand("spLoginCheck", con);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@LoginUserName", SqlDbType.VarChar).Value = TxtLoginID.Text.Trim();
        //cmd.Parameters.AddWithValue("@LoginUserPass", SqlDbType.VarChar).Value = txtLoginPassword.Text.Trim();
        //SqlDataReader rd = cmd.ExecuteReader();
        //if (rd.Read())
        //{
        //    string username = rd.GetString(0);
        //    int usertype = rd.GetInt32(2);
        //    string userType = rd.GetString(3);
        //    Home hm = new Home();
        //    hm.logginusername = username;
        //    hm.logginusertype = userType;
        //    hm.Show();
        //    this.Close();

        //}
    }


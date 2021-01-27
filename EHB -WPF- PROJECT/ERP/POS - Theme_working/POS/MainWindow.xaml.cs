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
                using (SqlConnection con = new SqlConnection(constr))
                {


                    con.Open();
                    MessageBox.Show(consucessful);
                    con.Close();
                }

            }
            catch (Exception exceptions) {

                MessageBox.Show("------ 404 CONNECTION ERROR --------" + exceptions.ToString());
            }
            //////////   sp Thme Calling Below  ///////////
            try
            {
                if (SwitchTheme.IsChecked == true)
                {
                  
                        con.Open();
                        MessageBox.Show("Theme Changing Process Is Working");


                        string changeThemeColor = "Black";
                        SqlCommand cmd = new SqlCommand("spThemeControl", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ThemeName", SqlDbType.Char).Value = changeThemeColor; ////////idhar text box ya 
                    SqlDataAdapter sqlDa = new SqlDataAdapter("EXEC spThemeControl @ThemeName='"+ changeThemeColor+"'", con);

                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                 
                        con.Close();
                    var converter = new System.Windows.Media.BrushConverter();
                    var brush = (Brush)converter.ConvertFromString(dtbl.Rows[0]["ForeGroundColor"].ToString());
                    foreach (Button tb in FindVisualChildren<Button>(this))
                    {
                        tb.Foreground = brush;
                    }


                }
            }
            catch (Exception exceptions)
            {
                string exceptionss = exceptions.ToString();
                MessageBox.Show("Theme Problem Found kindly Use Current theme" .ToString());
                con.Close();
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
                   string username= rd.GetString(0);
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

            ///////////  Theme  Sp Calling Below   ////////////

            con.Open();

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
    } } 
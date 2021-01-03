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
            catch(Exception exceptions) {
                
                MessageBox.Show("------ 404 CONNECTION ERROR --------"+exceptions.ToString());
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
                if (TxtLoginID.Text.Trim() != "" && txtLoginPassword.Text.Trim()!="")
                {
                    using (con)
                    {
                        con.Open();
                        //DataTable dt = new DataTable();
                        SqlCommand cmd = new SqlCommand("UserLoginChecking", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.Add(new SqlParameter("@UserName", UserName));

                        using (SqlDataReader rdr = cmd.ExecuteReader()) {
                            while (rdr.Read()) {
                                MessageBox.Show("Readerssssssssss");
                            }

                        }

                    }
                }

                else
                {
                    MessageBox.Show("Information: Invalid login Id and Password!!!!!!!");
                }

                
            }catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void SimpleButtonMove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SimpleButtonMove_Click_1(object sender, RoutedEventArgs e)
        {
            //WindowChangeDatabase wcd1 = new WindowChangeDatabase();
            //wcd1.ShowDialog();
        }

        private void SimpleButtonMove_Click_2(object sender, RoutedEventArgs e)
        {
            WindowChangeDatabase wcd1 = new WindowChangeDatabase();
            wcd1.ShowDialog();
        }

        private void LOGINButton_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }


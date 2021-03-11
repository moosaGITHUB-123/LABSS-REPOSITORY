using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POS
{
    /// <summary>
    /// Interaction logic for Window_khizer.xaml
    /// </summary>
    public partial class Window_khizer : Window
    {
        static string constr = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Setting"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        private object CategoryShortName;

        public object CategoryFullName { get; private set; }

        public Window_khizer()
        {
            InitializeComponent();



        } 



        private void Window_khizar_ContentRendered(object sender, EventArgs e)
        {
            MessageBox.Show(">> Menu Making Process Started . . . . . ");

            //MenuItem HR = new MenuItem();
            //HR.Header = "HR";
            //mainmenu.Items.Add(HR);

            //MenuItem Inventory = new MenuItem;
            //Inventory = "INVENTORY";
            //mainmenu.Items.Add(Inventory);





        }

        private void textBox_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dropDownButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_Copy_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();

                string querymaster = "Exec spProductCategory @Type=1, @SelectedCategoryID=0,@CategoryFullName='" + CategoryFullName + "',@CategoryShortName='" + CategoryShortName + "' ";
                SqlCommand cmd = new SqlCommand(querymaster, con);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                dt.Dispose();
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] != null)
                    {
                        using (SqlConnection conn = new SqlConnection(constr))
                        {
                            conn.Open();
                            string query = "Exec spProductCategory @Type=5, @SelectedCategoryID=" + Convert.ToInt32(dt.Rows[0][0]);
                            SqlCommand cmd2 = new SqlCommand(query, conn);

                            DataTable dt1 = new DataTable();
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                            // this will query your database and return the result to your datatable
                            da1.Fill(dt1);

                            da1.Dispose();
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();


            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

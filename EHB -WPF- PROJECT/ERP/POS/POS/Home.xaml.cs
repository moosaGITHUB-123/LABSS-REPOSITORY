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
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace POS
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        static string constr = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Setting"].ConnectionString;
        public string logginusername = "";
        public string logginusertype = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //lblUserName.Content = logginusername;
            //lblUserType.Content = logginusertype;
            btnEdgeLine1.Visibility = Visibility.Collapsed;
            btnEdgeLine2.Visibility = Visibility.Collapsed;
            btnEdgeLine3.Visibility = Visibility.Collapsed;
            btnEdgeLine4.Visibility = Visibility.Collapsed;
            btnEdgeLine5.Visibility = Visibility.Collapsed;
            

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {

                con.Open();
                MessageBox.Show("Theme Changing Process Is Working");


                string changeThemeColor = "Black";
                SqlCommand cmd = new SqlCommand("spThemeControl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThemeName", SqlDbType.Char).Value = changeThemeColor; ////////idhar text box ya 
                SqlDataAdapter sqlDa = new SqlDataAdapter("EXEC spThemeControl @ThemeName='" + changeThemeColor + "'", con);

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
            private void BtnQuickAccess1_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEdgeLine1.Visibility = Visibility.Visible;
            btnEdgeLine2.Visibility = Visibility.Collapsed;
            btnEdgeLine3.Visibility = Visibility.Collapsed;
            btnEdgeLine4.Visibility = Visibility.Collapsed;
            btnEdgeLine5.Visibility = Visibility.Collapsed;
         
        }

        private void BtnQuickAccess2_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEdgeLine2.Visibility = Visibility.Visible;
            btnEdgeLine1.Visibility = Visibility.Collapsed;
            btnEdgeLine3.Visibility = Visibility.Collapsed;
            btnEdgeLine4.Visibility = Visibility.Collapsed;
            btnEdgeLine5.Visibility = Visibility.Collapsed;
        }

        private void BtnQuickAccess3_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEdgeLine3.Visibility = Visibility.Visible;
            btnEdgeLine2.Visibility = Visibility.Collapsed;
            btnEdgeLine1.Visibility = Visibility.Collapsed;
            btnEdgeLine4.Visibility = Visibility.Collapsed;
            btnEdgeLine5.Visibility = Visibility.Collapsed;
        }

        private void BtnQuickAccess4_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEdgeLine4.Visibility = Visibility.Visible;
            btnEdgeLine2.Visibility = Visibility.Collapsed;
            btnEdgeLine3.Visibility = Visibility.Collapsed;
            btnEdgeLine1.Visibility = Visibility.Collapsed;
            btnEdgeLine5.Visibility = Visibility.Collapsed;
        }

        private void BtnQuickAccess5_MouseEnter(object sender, MouseEventArgs e)
        {
            btnEdgeLine5.Visibility = Visibility.Visible;
            btnEdgeLine2.Visibility = Visibility.Collapsed;
            btnEdgeLine3.Visibility = Visibility.Collapsed;
            btnEdgeLine4.Visibility = Visibility.Collapsed;
            btnEdgeLine1.Visibility = Visibility.Collapsed;
        }
    }
}

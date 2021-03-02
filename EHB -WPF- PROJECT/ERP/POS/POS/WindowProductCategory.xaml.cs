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
using System.Collections.ObjectModel;
using POS.DBClasses;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Core;


namespace POS
{
    /// <summary>
    /// Interaction logic for WindowProductCategory.xaml
    /// </summary>
    public partial class WindowProductCategory : Window
    {
        static string constr = ConfigurationManager.ConnectionStrings["POS.Properties.Settings.Setting"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);

        public WindowProductCategory()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
                try
                {
                    ///////////  Login  Sp Calling Below   ////////////

                    con.Open();
                    
                    SqlCommand cmd = new SqlCommand("spProductCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", SqlDbType.VarChar).Value = 1;
                    cmd.Parameters.AddWithValue("@SelectedCategoryID", SqlDbType.VarChar).Value = 0;
                    cmd.Parameters.AddWithValue("@CategoryFullName", SqlDbType.VarChar).Value = CategoryFullName.Text;
                    cmd.Parameters.AddWithValue("@CategoryShortName", SqlDbType.VarChar).Value = CategoryShortName.Text;
                    cmd.Parameters.AddWithValue("@CategoryDescription", SqlDbType.VarChar).Value = CategoryDescription.Text.Trim();
                    cmd.Parameters.AddWithValue("@CategoryParentID", SqlDbType.VarChar).Value = int.Parse(CategoryParent.Text.Trim());
//------------------------------------------------------
                    cmd.Parameters.AddWithValue("@recordStatusID", SqlDbType.VarChar).Value = 1;
                    cmd.Parameters.AddWithValue("@recordStatusCause", SqlDbType.VarChar).Value = "NO CAUSE";
                    cmd.Parameters.AddWithValue("@recordLastModifiedBy", SqlDbType.VarChar).Value = 0;
                    cmd.Parameters.AddWithValue("@recordLastModifiedDate", SqlDbType.VarChar).Value = "2021-01-01 00:00:00.000";
                    cmd.Parameters.AddWithValue("@recordEntryBy", SqlDbType.VarChar).Value = 0;
                    cmd.Parameters.AddWithValue("@recordEntryDate", SqlDbType.VarChar).Value = "2021-01-01 00:00:00.000";
                SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                    
                    DataTable dt = new DataTable();
                    DataColumn CategoryID = new DataColumn("id",typeof(int));
                    DataColumn CategoryFullName = new DataColumn("Full Name",typeof(string));
                    DataColumn CategoryShortName = new DataColumn("Short Name",typeof(string));
                    DataColumn CategoryDescription = new DataColumn("Description",typeof(string));

                    dt.Columns.Add(CategoryID);
                    dt.Columns.Add(CategoryID);
                    dt.Columns.Add(CategoryFullName);
                    dt.Columns.Add(CategoryShortName);
                    dt.Columns.Add(CategoryDescription);


                    }

                con.Close();

                }


                catch (Exception ex) { MessageBox.Show(ex.ToString()); }; ;

            
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            //----------
            CategoryID.Content = "";
            CategoryFullName.Text = "";
            CategoryShortName.Text = "";
            CategoryDescription.Text = "";
            Status.Text = "";
            StatusReason.Text = "";

            CategoryParent.Items.Add("1");
            CategoryParent.SelectedIndex = 1;
            Status.Items.Add("1");
            Status.SelectedIndex = 1;
            //-------------
        }
    }
}

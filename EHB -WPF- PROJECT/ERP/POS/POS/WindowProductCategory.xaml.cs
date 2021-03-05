using System.Windows;
using System.Configuration;
using System.Data.SqlClient;


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

            int id = EntityDBClass.Create("spProductCategory", new string[] {"@Type","@CategoryFullName","@CategoryParentID","@CategoryShortName","@CategoryDescription"
            }, new string[] { "1", TxtCategoryFullName.Text.ToString(), CmbCategoryParent.SelectedValue.ToString(), TxtCategoryShortName.Text.ToString(), TxtCategoryDescription.Text.ToString() });



        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            //----------
            lblCategoryID.Content = "";
            TxtCategoryFullName.Text = "";
            TxtCategoryShortName.Text = "";
            TxtCategoryDescription.Text = "";
            CmbStatus.Text = "";
            TxtRecordStatusCause.Text = "";

            CmbCategoryParent.Items.Add("1");
            CmbCategoryParent.SelectedIndex = 1;
            CmbStatus.Items.Add("1");
            CmbStatus.SelectedIndex = 1;
            //-------------
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con3 = new SqlConnection(constr))
            {


                //  con3.Open();

                ////  SqlCommand cmd3 = new SqlCommand("spProductCategory", con3);
                ////  cmd3.CommandType = CommandType.StoredProcedure;
                ////  cmd3.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = 2;
                //    string query = "Exec spProductCategory @Type=2" ;
                //   SqlCommand cmd3 = new SqlCommand(query, con3);

                //  DataTable dt3 = new DataTable();

                //  SqlDataReader rd = cmd3.ExecuteReader();
                //  if (rd.Read())
                //  {

                //      // this will query your database and return the result to your datatable
                //      //rd.Fill(dt3);

                //      //da3.Dispose();
                //      //con3.Close();

                //con3.Open();

                //SqlCommand cmd = new SqlCommand("ProductCategory", con3);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CategoryID", SqlDbType.VarChar).Value = null;
                //cmd.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = 0;
                //SqlDataReader rd3 = cmd.ExecuteReader();
                //DataTable dt3 = new DataTable();
                //if (rd3.Read())
                //{

                    
                //}
                //con3.Close();

                
            }
        }
    }
}

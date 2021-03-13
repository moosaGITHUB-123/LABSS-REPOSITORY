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
using System.Data;
using System.Data.SqlClient;
using POS.DBClasses;

namespace POS
{
    /// <summary>
    /// Interaction logic for WindowProductCategoryNew.xaml
    /// </summary>
    public partial class WindowProductCategoryNew : Window
    {
        public WindowProductCategoryNew()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = EntityDBClass.Select("spProductCategory" , new string[] { "@Type" }, new string[] { "9" });
            IList<ProductCategory> items = dt.AsEnumerable().Select(row =>
    new ProductCategory
    {
        CategoryID = row.Field<int>("CategoryID"),
        CategoryParentID = row.Field<string>("CategoryParentID")==DBNull.Value?0 : row.Field<string>("CategoryParentID"),
        CategoryFullName = row.Field<string>("CategoryFullName"),
        CategoryShortName = row.Field<string>("CategoryShortName"),
        CategoryDescription = row.Field<string>("CategoryDescription"),
        recordStatusID = row.Field<int>("recordStatusID"),
        recordStatusCause = row.Field<string>("recordStatusCause"),
        recordLastModifiedBy = row.Field<int>("recordLastModifiedBy"),
        recordLastModifiedDate = row.Field<DateTime>("recordLastModifiedDate"),
        recordEntryBy = row.Field<int>("recordEntryBy"),
        recordEntryDate = row.Field<DateTime>("recordEntryDate"),
        recordStatusName = row.Field<string>("recordStatusName"),

    }).ToList();
        }
    }
}

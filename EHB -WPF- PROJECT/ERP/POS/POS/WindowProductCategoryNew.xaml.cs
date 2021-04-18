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
using System.Collections.ObjectModel;
using System.Windows.Forms;

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



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainCrudButtons.IsShowNew = true;
            MainCrudButtons.IsShowEdit = true;
            MainCrudButtons.IsShowSave = true;
            MainCrudButtons.IsShowDelete = true;


            DataTable dt = EntityDBClass.Select("spProductCategory", new string[] { "@Type" }, new string[] { "9" });

            ObservableCollection<ProductCategory> test = new ObservableCollection<ProductCategory>();
            foreach (DataRow row in dt.Rows)
            {
                var obj = new ProductCategory()
                {
                    CategoryID = (int)row["CategoryID"],
                    CategoryParentID = row["CategoryParentID"] == DBNull.Value ? "" : (string)row["CategoryParentID"],
                    CategoryFullName = row["CategoryFullName"] == DBNull.Value ? "" : (string)row["CategoryFullName"],
                    CategoryShortName = row["CategoryShortName"] == DBNull.Value ? "" : (string)row["CategoryShortName"],
                    CategoryDescription = row["CategoryDescription"] == DBNull.Value ? "" : (string)row["CategoryDescription"],
                    recordStatusID = row["recordStatusID"] == DBNull.Value ? 0 : (int)row["recordStatusID"],
                    recordStatusCause = row["recordStatusCause"] == DBNull.Value ? "" : (string)row["recordStatusCause"],
                    recordLastModifiedBy = row["recordLastModifiedBy"] == DBNull.Value ? 0 : (int)row["recordLastModifiedBy"],
                    recordLastModifiedDate = row["recordLastModifiedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["recordLastModifiedDate"],
                    recordEntryBy = row["recordEntryBy"] == DBNull.Value ? 0 : (int)row["recordEntryBy"],
                    recordEntryDate = row["recordEntryDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["recordEntryDate"],
                    recordStatusName = row["recordStatusName"] == DBNull.Value ? "" : (string)row["recordStatusName"],

                };
                test.Add(obj);

            }

            var ParentCategory = test.Where(x => x.CategoryParentID == "").ToList<ProductCategory>();

            foreach (var pcat in ParentCategory)
            {
               CategoryTree.Items.Add(pcat.CategoryFullName);
            }


        }




        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
                if (MainCrudButtons.Edit)
                {
                    //Edit
                }
                else if (MainCrudButtons.New)
                {
                    WindowProductModifier i = new WindowProductModifier();
                    i.ShowDialog();
                }
                else if (MainCrudButtons.Save)
                {
                    //save

                }
                else if (MainCrudButtons.Delete)
                {
                    //Delete
                }
            }

        }
    
}

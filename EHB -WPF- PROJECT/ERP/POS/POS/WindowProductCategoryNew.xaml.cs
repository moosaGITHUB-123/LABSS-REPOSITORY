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
                    CategoryParentID = row["CategoryParentID"] ==DBNull.Value? "": (string)row["CategoryParentID"],
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

                //if (!Page.IsPostBack)
                //{
                //    AccordionPane ap1 = new AccordionPane();
                //    ap1.HeaderContainer.Controls.Add(new LiteralControl("Using Markup"));
                //    ap1.ContentContainer.Controls.Add(new
                //    LiteralControl("Adding panes using markup is really simple."));
                //    AccordionPane ap2 = new AccordionPane();
                //    ap2.HeaderContainer.Controls.Add(new LiteralControl("Using Code"));
                //    ap2.ContentContainer.Controls.Add(new
                //    LiteralControl("Adding panes using code is really flexible."));
                //    acc1.Panes.Add(ap1);
                //    acc1.Panes.Add(ap2);
                //}

                //
                //NewNode n = new NewNode();
                //n.ShowDialog();
                //TreeNode nod = new TreeNode();
                //nod.Name = n.NewNodeName.ToString();
                //nod.Text = n.NewNodeText.ToString();
                //nod.Tag = n.NewNodeTag.ToString();
                //n.Close();
                //treeView1.SelectedNode.Nodes.Add(nod);
                //treeView1.SelectedNode.ExpandAll();

                //MyTreeView.Items.Add();

                //var totalCategories = 20;
                //foreach (var categoryChilds in ParentCategory)
                //{
                //    CategoryTree.Items.Add();
                //}

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

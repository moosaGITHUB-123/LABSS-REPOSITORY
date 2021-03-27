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

        public DateTime recordLastModifiedDate { get; private set; }
        public int recordEntrydBy { get; private set; }
        public DateTime recordEntryDate { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //lblUserName.Content = logginusername;
            //lblUserType.Content = logginusertype;
            btnEdgeLine1.Visibility = Visibility.Collapsed;
            btnEdgeLine2.Visibility = Visibility.Collapsed;
            btnEdgeLine3.Visibility = Visibility.Collapsed;
            btnEdgeLine4.Visibility = Visibility.Collapsed;
            btnEdgeLine5.Visibility = Visibility.Collapsed;

            ////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////
            ///


            using (SqlConnection con = new SqlConnection(constr))
            {

                con.Open();
                MessageBox.Show("APPLICATION Menu Making Process Is Working");


                // string Module = "White";
                SqlCommand cmd = new SqlCommand("spMenuGenerator", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ThemeName", SqlDbType.Char).Value = changeThemeColor; ////////idhar text box ya 
                SqlDataAdapter sqlDa = new SqlDataAdapter("EXEC spMenuGenerator" , con);

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

              
               


                if (dtbl != null && dtbl.Rows.Count > 0)
                {
                    ObservableCollection<MenuGenerator> test = new ObservableCollection<MenuGenerator>();
                    int i = 0;
                    foreach (var row in dtbl.Rows)
                    {
                        //string parent = ;
                        //string child = "";
                        //string grandchild = "";

                        //MenuItem HomeWindowMod = new MenuItem();
                        //HomeWindowMod.Header = "";
                        //HomeWindowMod.Height = 30;
                        //this.HomeWindowMenu.Items.Add(HomeWindowMod);
                        //int CheckUserType = 1;
                        //if (CheckUserType == 1)

                        //{
                        //    MenuItem HomeWindowModMenu = new MenuItem();
                        //    HomeWindowModMenu.Header = "Employe info";
                        //    HomeWindowModMenu.Height = 30;
                        //    HomeWindowMod.Items.Add(HomeWindowModMenu);

                        //}


                        var obj = new MenuGenerator()
                        {
                            ModuleID = Convert.ToInt32(dtbl.Rows[i]["ModuleID"]),
                            Parent = (string)dtbl.Rows[i]["Parent"],
                            ModuleMenuID = Convert.ToInt32(dtbl.Rows[i]["ModuleMenuID"]),
                            Child = (string)dtbl.Rows[i]["Child"],
                            ModuleSubMenuID = Convert.ToInt32(dtbl.Rows[i]["ModuleSubMenuID"]),
                            GrandChild = (string)dtbl.Rows[i]["GrandChild"]
                        };
                         
                            
                            //******  Module DropDown Making Started  *****//
                             MenuItem HomeWindowMod = new MenuItem();
                             HomeWindowMod.Header ="";
                             HomeWindowMod.Height = 30;
                             this.HomeWindowMenu.Items.Add(HomeWindowMod);
                             int CheckUserType = 1;
                             if (CheckUserType == 1)
                                {
                                    MenuItem HomeWindowModMenu = new MenuItem();
                                    HomeWindowModMenu.Header = "";
                                    HomeWindowModMenu.Height = 30;
                                    HomeWindowMod.Items.Add(HomeWindowModMenu);

                                }
                            //******  Module DropDown Making End  *********//

                        test.Add(obj);

                        

                        i++;
                    }
                }
                con.Close();







            }
        } 
        

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////////////////////
            ///////////////  THEME COLOR CHANGING BELOW   ////////////////////
            /////////////////////////////////////////////////////////////////
            

            using (SqlConnection con = new SqlConnection(constr))
            {

                con.Open();
                MessageBox.Show("Theme Changing Process Is Working");

               
                string changeThemeColor = "White";
                SqlCommand cmd = new SqlCommand("spThemeControl", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThemeName", SqlDbType.Char).Value = changeThemeColor; ////////idhar text box ya 
                SqlDataAdapter sqlDa = new SqlDataAdapter("EXEC spThemeControl @ThemeName='" + changeThemeColor + "'", con);

                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                if (dtbl != null && dtbl.Rows.Count > 0)
                {
                    ObservableCollection<ThemeControl> test = new ObservableCollection<ThemeControl>();
                    int i = 0;
                    foreach (var row in dtbl.Rows)
                    {

                        var obj = new ThemeControl()
                        {
                            ThemeControlTypeID = Convert.ToInt32(dtbl.Rows[i]["ThemeControlTypeId"]),
                            ThemecontrolTypeName = (string)dtbl.Rows[i]["ThemecontrolTypeName"],
                            ThemeName = (string)dtbl.Rows[i]["ThemeName"],
                            ForegroundColor = (string)dtbl.Rows[i]["ForeGroundColor"],
                            BackgroundColor = (string)dtbl.Rows[i]["BackGroundColor"],
                            ShadowColor = (string)dtbl.Rows[i]["ShadowColor"],

                        };
                        test.Add(obj);
                        i++;
                    }


                //    con.Close();


                    ///=================================================
                    ////////  Button Color  /////////

                    ThemeControl ButtonColors = test.Where(x => x.ThemecontrolTypeName == "Button").FirstOrDefault();
                    var converter = new System.Windows.Media.BrushConverter();
                    if (ButtonColors != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(ButtonColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(ButtonColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(ButtonColors.ShadowColor.ToString());
                        foreach (Button tb in FindVisualChildren<Button>(this))
                        {
                            tb.Foreground = brushFore;
                            tb.Background = brushBack;

                        }
                    }

                    ///=================================================
                    /////////  Stack Panel ////////////
                    ThemeControl StackpanelColors = test.Where(x => x.ThemecontrolTypeName == "StackPanel").FirstOrDefault();

                    if (StackpanelColors != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(StackpanelColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(StackpanelColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(StackpanelColors.ShadowColor.ToString());
                        foreach (StackPanel tb in FindVisualChildren<StackPanel>(this))
                        {

                           tb.Background = brushBack;
                            

                        }
                    }
                    
                    ThemeControl MenuColors = test.Where(x => x.ThemecontrolTypeName == "Menu").FirstOrDefault();
          
                    if (MenuColors != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(MenuColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(MenuColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(LabelColor.ShadowColor.ToString());
                        foreach (Menu tb in FindVisualChildren<Menu>(this))
                        {
          
                            tb.Background = brushBack;
                            tb.Foreground = brushFore;
          
                        }
                    }
          
                    ///=================================================
                    /////////  TextBox Color  //////////
                    ThemeControl TextBoxColor = test.Where(x => x.ThemecontrolTypeName == "TextBox").FirstOrDefault();

                    if (TextBoxColor != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(TextBoxColor.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(TextBoxColor.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(TextBoxColor.ShadowColor.ToString());
                        foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                        {

                            tb.Background = brushBack;
                            tb.Foreground = brushFore;

                        }
                    }

                    ///=================================================
                    /////////  TextBlock Color  //////////
                    ThemeControl TextBlockColor = test.Where(x => x.ThemecontrolTypeName == "TextBlock").FirstOrDefault();

                    if (TextBlockColor != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(TextBlockColor.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(TextBlockColor.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(TextBlockColor.ShadowColor.ToString());
                        foreach (TextBlock tb in FindVisualChildren<TextBlock>(this))
                        {
                            tb.Foreground = brushFore;
                            tb.Background = brushBack;
                        }
                    }
                    ///=================================================
                    /////////  Border Color  //////////
                    ThemeControl BorderColors = test.Where(x => x.ThemecontrolTypeName == "Border").FirstOrDefault();

                    if (BorderColors != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(BorderColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(BorderColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(DockPanelColor.ShadowColor.ToString());
                        foreach (Border tb in FindVisualChildren<Border>(this))
                        {

                            tb.Background = brushBack;

                        }
                    }
                    //////=====================================================
                    /////////  Layout Panel Colors  ////////// making some issue in this
                    ThemeControl LayoutPanelColors = test.Where(x => x.ThemecontrolTypeName == "LayoutPanel").FirstOrDefault();

                    if (LayoutPanelColors != null)
                    {
                        //var brushFore = (Brush)converter.ConvertFromString(LayoutPanelColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(LayoutPanelColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(DockPanelColor.ShadowColor.ToString());
                        foreach (LayoutPanel tb in FindVisualChildren<LayoutPanel>(this))
                        {

                            tb.Background = brushBack;
                            //tb.Foreground = brushFore;

                        }

                    }

                    ///=================================================
                    /////////  DockLayout Manager Colors  ////////// making some issue in this
                    ThemeControl DockLayoutManagerColors = test.Where(x => x.ThemecontrolTypeName == "DockLayoutManager").FirstOrDefault();

                    if (DockLayoutManagerColors != null)
                    {
                        //var brushFore = (Brush)converter.ConvertFromString(DockLayoutManagerColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(DockLayoutManagerColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(DockPanelColor.ShadowColor.ToString());
                        foreach (DockLayoutManager tb in FindVisualChildren<DockLayoutManager>(this))
                        {

                            tb.Background = brushBack;

                        }
                    }
                    ///=================================================
                    /////////  Label Colors  ////////// 
                    ThemeControl LabelColors = test.Where(x => x.ThemecontrolTypeName == "Label").FirstOrDefault();

                    if (LabelColors != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(LabelColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(LabelColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(DockPanelColor.ShadowColor.ToString());
                        foreach (Label tb in FindVisualChildren<Label>(this))
                        {

                            tb.Background = brushBack;
                            tb.Foreground = brushFore;

                        }
                    }

                    ///=================================================
                    /////////  Grid Colors  ////////// making some issue in this
                    ThemeControl GridColors = test.Where(x => x.ThemecontrolTypeName == "Grid").FirstOrDefault();

                    if (GridColors != null)
                    {
                        //var brushFore = (Brush)converter.ConvertFromString(GridColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(GridColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(DockPanelColor.ShadowColor.ToString());
                        foreach (Grid tb in FindVisualChildren<Grid>(this))
                        {

                            tb.Background = brushBack;

                        }
                    }
                    
                    /////////  Simple Button Colors  ////////// making some issue in this
                    ThemeControl SimpleButtonColors = test.Where(x => x.ThemecontrolTypeName == "SimpleButton").FirstOrDefault();

                    if (SimpleButtonColors != null)
                    {
                        var brushFore = (Brush)converter.ConvertFromString(SimpleButtonColors.ForegroundColor.ToString());
                        var brushBack = (Brush)converter.ConvertFromString(SimpleButtonColors.BackgroundColor.ToString());
                        //var brushShade = (Brush)converter.ConvertFromString(DockPanelColor.ShadowColor.ToString());
                        foreach (SimpleButton tb in FindVisualChildren<SimpleButton>(this))
                        {

                            tb.Background = brushBack;
                            tb.Foreground = brushFore;

                        }
                    }
                }
            }



        }
            public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject
                        child = VisualTreeHelper.GetChild(depObj, i);
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

            //////////////////////////////////////////////////////////////////
            ///////////////  THEME COLOR CHANGING ABOVE   ////////////////////
            /////////////////////////////////////////////////////////////////


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

        void dynamicmenu()
        {

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

        private void btnQuickAccess6_Click(object sender, RoutedEventArgs e)
        {
            WindowProductCategory fm = new WindowProductCategory();
            fm.Show();

        }

        private void btnQuickAccess7_Click(object sender, RoutedEventArgs e)
        {
            WindowProductCategoryNew fm = new WindowProductCategoryNew();
            fm.Show();
        }

        private void btnQuickAccess8_Click(object sender, RoutedEventArgs e)
        {
            WindowProductModifier fm = new WindowProductModifier();
            fm.Show();

        }

        private void btnQuickAccess9_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

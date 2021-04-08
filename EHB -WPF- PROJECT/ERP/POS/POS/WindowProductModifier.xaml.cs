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
    /// Interaction logic for WindowProductModifier.xaml
    /// </summary>
    public partial class WindowProductModifier : Window
    {
        public WindowProductModifier()
        {
            InitializeComponent();
        }

        //public string ComboValue { get; private set; }
        //public string ComboValue2 { get; private set; }
        //public int ID { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int SpTypeChanger = 1; SpTypeChanger <= 14; SpTypeChanger++)
            {

                
                DataTable dt = EntityDBClass.Select("spProductComboBoxLoad", new string[] { "@Type" }, new string[] { SpTypeChanger.ToString() });

                //----------------------------------------//
                if (SpTypeChanger == 1)
                {
                    CboBrand.ItemsSource = dt;
                }
                if (SpTypeChanger == 2)
                {
                    CboFlavour.ItemsSource = dt;
                }
                if (SpTypeChanger == 3)
                {
                    CboSize.ItemsSource = dt;
                }
                if (SpTypeChanger == 4)
                {
                    CboShape.ItemsSource = dt;
                }
                if (SpTypeChanger == 5)
                {
                    //CboArticle.ItemsSource = dt;
                }
                if (SpTypeChanger == 6)
                {
                   // CboDesign.ItemsSource = dt;
                }
                if (SpTypeChanger == 7)
                {
                 //   CboPublisher.ItemsSource = dt;
                }
                if (SpTypeChanger == 8)
                {
                //    CboFlavour.ItemsSource = dt;
                }
                if (SpTypeChanger == 9)
                {
                    CboPackaging.ItemsSource = dt;
                }
                if (SpTypeChanger == 10)
                {
                    CboAddChrgs.ItemsSource = dt;
                }
                if (SpTypeChanger == 11)
                {
                    CboTaxCategory.ItemsSource = dt;
                }
                if (SpTypeChanger == 12)
                {
                    CboAddTaxChrgs.ItemsSource = dt;
                }
                if (SpTypeChanger == 13)
                {
                 //   CboFlavour.ItemsSource = dt;
                }
               
                //------------ Combo Restarter Above ----------//

            }

        }
    }
}

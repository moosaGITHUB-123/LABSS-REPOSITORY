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

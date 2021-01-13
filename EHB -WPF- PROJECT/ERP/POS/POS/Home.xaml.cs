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
            lblUserName.Content = logginusername;
            lblUserType.Content = logginusertype;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}

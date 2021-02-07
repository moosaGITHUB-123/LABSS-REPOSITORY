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
    /// Interaction logic for Window_khizer.xaml
    /// </summary>
    public partial class Window_khizer : Window
    {
        public Window_khizer()
        {
            InitializeComponent();



        } 

        private void Window_khizar_ContentRendered(object sender, EventArgs e)
        {
            MessageBox.Show(">> Menu Making Process Started . . . . . ");

            //MenuItem HR = new MenuItem();
            //HR.Header = "HR";
            //mainmenu.Items.Add(HR);

            //MenuItem Inventory = new MenuItem;
            //Inventory = "INVENTORY";
            //mainmenu.Items.Add(Inventory);





        }
    }
}

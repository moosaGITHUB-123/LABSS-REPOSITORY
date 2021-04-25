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
    /// Interaction logic for TopDateTimeBar.xaml
    /// </summary>
    public partial class TopDateTimeBar : Window
    {
        public TopDateTimeBar()
        {
            InitializeComponent();
            LblDate_TopBar.Content = DateTime.Now.ToString();
            LblDate_TopBar.Content = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");

        }
    }
}

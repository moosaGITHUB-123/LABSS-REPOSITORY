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
using DevExpress;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Core;
using System.Xaml;
using DevExpress.Xpf.Editors;
using DevExpress.XtraEditors;
using DevExpress.Xpf.DocumentViewer;
namespace POS
{
    /// <summary>
    /// Interaction logic for NewLogin.xaml
    /// </summary>
    public partial class NewLogin : Window
    {
        public NewLogin()
        {
            InitializeComponent();
        }

      
        private void BtnNewLogin_Click(object sender, RoutedEventArgs e)
        {
           
            NewMainWindow fm = new NewMainWindow();
            fm.Show();
           
        }
    }
}

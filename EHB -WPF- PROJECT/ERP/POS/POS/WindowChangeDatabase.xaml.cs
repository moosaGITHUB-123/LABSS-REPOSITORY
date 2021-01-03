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
    /// Interaction logic for WindowChangeDatabase.xaml
    /// </summary>
    public partial class WindowChangeDatabase : Window
    {
        public WindowChangeDatabase()
        {
            InitializeComponent();

           
           
        }

        private void SimpleButton4_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLoginSetDB_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = string.Format("DataSource={0};Initial Catalog=(1);User ID=(2);Password=(3);", cboLoginServer.Text, txtLoginDB.Text, txtLoginDBUser.Text, txtLoginDBPass.Text); 
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test Connection Succedded . . . . ", "Messege", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messege", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLoginSavetDB_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = string.Format("DataSource={0};Initial Catalog=(1);User ID=(2); Password=(3);", cboLoginServer.Text, txtLoginDB.Text, txtLoginDBUser.Text, txtLoginDBPass.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("con", connectionString);
                    MessageBox.Show("CONNECTION SUCCESSFULLY SAVED . . . ", "Messege", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Messege", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            cboLoginServer.Items.Add(".");
            cboLoginServer.Items.Add("(local)");
            cboLoginServer.Items.Add(@".\SQLEXPRESS");
            cboLoginServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboLoginServer.SelectedIndex = 3;
        }
    }
}

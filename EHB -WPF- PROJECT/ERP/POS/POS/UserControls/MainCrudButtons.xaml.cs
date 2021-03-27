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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.UserControls
{
    /// <summary>
    /// Interaction logic for MainCrudButtons.xaml
    /// </summary>
    public partial class MainCrudButtons : UserControl
    {


        public bool IsShowEdit = false;
        public bool IsShowDelete = false;
        public bool IsShowNew = false;
        public bool IsShowSave = false;

        public bool Edit = false;
        public bool Delete = false;
        public bool New = false;
        public bool Save = false;



        public MainCrudButtons()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            Delete = false;
            New = false;
            Save = true;

    }
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            Delete = false;
            New = true;
            Save = false;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsShowEdit)
            {
                BtnEdit.Visibility = Visibility.Collapsed;
            }

            if (!IsShowDelete)
            {
                BtnDelete.Visibility = Visibility.Collapsed;
            }
            if (!IsShowNew)
            {
                BtnNew.Visibility = Visibility.Collapsed;
            }
            if (!IsShowSave)
            {
                BtnSave.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Edit = true;
            Delete = false;
            New = false;
            Save = false;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Edit = false;
            Delete = true;
            New = false;
            Save = false;
        }
    }
}

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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            
        }

        private void Window_ContentRendered(object sender, EventArgs e) 
        {
            //    int startposition = 100;
            //    int endposition = 10;
            //Label AddLabel(int i, int Start, int End)
            //{
            //    Label I = new Label();
            //    I.Name = "LabelFromVideo".ToString();
            //    I.Content = "LabelFromVideo-2".ToString();
            //    //I.Foreground = Color.Add.Foreground;
            //    //I.Background = Color.Green;
            //    //I.Font = new Font("Serif",24, FontStyle.Bold);
            //    I.Width = 20;
            //    I.Height = 100;
            //    //I.Location = new Point(Start, End);


                     MenuItem MenuUI = new MenuItem();
                     MenuUI.Header = "POS TOUCH FOR TAB";
                     MenuUI.Height = 50;
                   //  this.HomeMenu.Items.Add(MenuUI);
                     int UserTypeId = 1;

             if (UserTypeId == 1)

            {
                MenuItem MenuSubUI = new MenuItem();
                MenuSubUI.Header = "Sub Menu Ha YE 1";
                MenuSubUI.Height = 50;
                MenuUI.Items.Add(MenuSubUI);
                MenuItem MenuUIStatus = new MenuItem();
                MenuUIStatus.Header = 50;
                MenuUIStatus.Height = 50;
                MenuUI.Items.Add(MenuUIStatus);
                
            };

            


           

        }



    }
    }
//}

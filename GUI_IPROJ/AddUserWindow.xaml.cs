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

namespace GUI_IPROJ
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow(AddUserVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();

            mainWindow.Show();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
            CheckBox clickedCheckBox = (CheckBox)sender;

            
            foreach (CheckBox checkBox in new CheckBox[] { Option1CheckBox, Option2CheckBox })
            {
                if (checkBox != clickedCheckBox)
                {
                    checkBox.IsChecked = false;
                }
            }

            
            if (Option1CheckBox.IsChecked == true)
            {
                
            }
            else if (Option2CheckBox.IsChecked == true)
            {
                
            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_IPROJ.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace GUI_IPROJ
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void message()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4!", "Error!");
        }

        [RelayCommand]
        public void AddNewStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted Successfuly!", "DELETED! \a ");
            }
            else
            {
                MessageBox.Show("Please Select User!", "Error!");
            }
        }
        [RelayCommand]
        public void EditStudent()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();

                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);

            }

            else
            {
                MessageBox.Show("Please Select the User!", "Error!");
            }
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<User>();
                BitmapImage image1 = new BitmapImage(new Uri("\\Model\\Images\\1.png", UriKind.Relative));
                users.Add(new User(23, "Nishan", "Madushanka", "12/12/1999", 3.2, image1));
            BitmapImage image2 = new BitmapImage(new Uri("\\Model\\Images\\2.png", UriKind.Relative));
            users.Add(new User(24, "Chathuranga", "Hewavitharana", "12/12/1999", 3.0, image2));
            BitmapImage image3 = new BitmapImage(new Uri("\\Model\\Images\\3.png", UriKind.Relative));
            users.Add(new User(24, "Thambara ", "Dahanayake", "12/12/1999", 3.1, image3));
            BitmapImage image4 = new BitmapImage(new Uri("\\Model\\Images\\4.png", UriKind.Relative));
            users.Add(new User(21, "Lakshan", "Miyuranga", "12/12/1999", 3.8, image4));

        }
    }
}

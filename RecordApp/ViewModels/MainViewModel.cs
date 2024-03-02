using RecordApp.Commands;
using RecordApp.Models;
using RecordApp.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using SharedData;

namespace RecordApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ICommand ShowWindowCommand { get; set; }

        public MainViewModel()
        {
            UserManager userManager = new();

            Users = UserManager.GetUsers();

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var mainWindow = obj as Window;

            AddUser addUserWin = new();

            addUserWin.Owner = mainWindow;

            addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            addUserWin.Show();
        }
    }
}

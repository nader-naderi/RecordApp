using RecordApp.Commands;
using RecordApp.Models;
using System.Windows;
using System.Windows.Input;
using SharedData;

namespace RecordApp.ViewModels
{
    public class AddUserViewModel
    {
        public ICommand AddUserCommand { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public AddUserViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        }

        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            var curWin = obj as Window;

            UserManager.AddUser(new User() { Name  = Name, Email = Email });

            curWin.Close();
        }
    }
}

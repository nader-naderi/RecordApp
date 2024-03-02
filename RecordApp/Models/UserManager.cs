using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using SharedData;

namespace RecordApp.Models
{
    public class UserManager
    {
        private static ObservableCollection<User> _DatabaseUser = new ObservableCollection<User>();
        private static APIClient _apiClient = new();

        public UserManager()
        {
            // Load users from the API on initialization
            LoadUsers();
        }

        public static ObservableCollection<User> GetUsers()
        {
            return _DatabaseUser;
        }

        public static async void AddUser(User user)
        {
            await _apiClient.AddNewUserAsync(user.Name, user.Email);
            _DatabaseUser.Add(user);
        }

        public async void LoadUsers()
        {
            _DatabaseUser.Clear();
            var users = await _apiClient.GetAllUsersAsync();

            foreach (var user in users)
                _DatabaseUser.Add(user);
        }
    }
}

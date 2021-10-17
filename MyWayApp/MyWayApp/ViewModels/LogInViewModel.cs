using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayApp.Services;
using MyWayApp.Models;
using MyWayApp.Views;
using Xamarin.Essentials;
using System.Linq;

namespace MyWayApp.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public LogInViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        private string serverStatus;
        public string ServerStatus
        {
            get { return serverStatus; }
            set
            {
                serverStatus = value;
                OnPropertyChanged("ServerStatus");
            }
        }

        public async void OnSubmit()
        {
            ServerStatus = "conecting to service...";
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.ServerStatusPage());
            MyWayAPIProxy proxy = MyWayAPIProxy.CreateProxy();
            Client user = await proxy.LoginAsync(Email, Password);
            if (user == null)
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
                await App.Current.MainPage.DisplayAlert("שגיאה", "התחברות נכשלה, בדוק שם משתמש וסיסמה ונסה שוב", "בסדר");
            }
            else
            {
                ServerStatus = "קורא נתונים...";
                App theApp = (App)App.Current;
                theApp.CurrentUser = user;
          
            }
        }
       
    }
}

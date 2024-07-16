using Practic_App.core;
using Practic_App.MVVM.Model;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.Model.Data.UW;
using Practic_App.MVVM.View.Login;
using Practic_App.MVVM.ViewModel.Login;
using System.Windows;
using System.Windows.Input;

namespace Practic_App.MVVM.ViewModel
{
    public class MainViewModel: ObservableObject
    {
        private bool _isLoggedIn;
        private bool _isAdmin;
        private User _user;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public UnitOfWork DataWorker { get; set; }

        public ICommand CloseApplicationCommand { get; }
        public ICommand MinimizeApplicationCommand { get; }

        public RelayCommand LoginWindowCommand { get; }
        public RelayCommand RegisterWindowCommand { get; }

        public RelayCommand LogOutCommand { get; }

        public RelayCommand VacancyListCommand { get; }
        public RelayCommand AddVacancyCommand { get; }
        public RelayCommand DeleteVacancyCommand { get; }
        
        public RelayCommand OpenUserProfileCommand { get; }

        public VacancyListViewModel VacancyLV { get; set; }
        public AddVacancyViewModel AddVacancyV { get; set; }
        public DeleteVacancyViewModel DeleteVacancyV { get; set; }


        private object _currentView;
        public object CurrentView { 
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            } 
        }

        public MainViewModel()
        {
            try
            {
                DataWorker = new UnitOfWork(new ApplicationDataContext());
                User = new User();

                LogOutCommand = new RelayCommand(o => { IsLoggedIn = false; IsAdmin = false; User = null; CurrentView = VacancyLV; });

                RegisterWindowCommand = new RelayCommand(OpenRegister);
                LoginWindowCommand = new RelayCommand(OpenLogin);

                CloseApplicationCommand = new RelayCommand(CloseApplication);
                MinimizeApplicationCommand = new RelayCommand(MinimizeApplication);

                DeleteVacancyCommand = new RelayCommand(o => { CurrentView = DeleteVacancyV; });
                VacancyListCommand = new RelayCommand(o => { CurrentView = VacancyLV; });
                AddVacancyCommand = new RelayCommand(o => { CurrentView = AddVacancyV; });
                OpenUserProfileCommand = new RelayCommand(OpenUserProfile);

                VacancyLV = new VacancyListViewModel(this, DataWorker);
                AddVacancyV = new AddVacancyViewModel(VacancyLV.Vacancies, DataWorker);
                DeleteVacancyV = new DeleteVacancyViewModel(VacancyLV.Vacancies, DataWorker);

                CurrentView = VacancyLV;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenRegister(object parameter)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoginWindow)
                {
                    window.Close();
                    break;
                }
            }

            RegisterWindow registerWindow = new RegisterWindow(new RegisterViewModel(DataWorker));
            registerWindow.Show();
        }

        private void OpenLogin(object parameter) {
            LoginWindow loginWindow = new LoginWindow(new LoginViewModel(DataWorker, RegisterWindowCommand));
            loginWindow.Show();
        }

        private void CloseApplication(object parameter)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeApplication(object parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void OpenUserProfile(object parameter)
        {
            CurrentView = new UserProfileViewModel(User,DataWorker,this);
        }
        
    }
}

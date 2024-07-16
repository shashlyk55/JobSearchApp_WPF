using Practic_App.core;
using Practic_App.MVVM.Model;
using Practic_App.MVVM.Model.Data.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Practic_App.MVVM.ViewModel
{
    public class UserProfileViewModel : ObservableObject
    {
        public UnitOfWork DataWorker { get; set; }
        public MainViewModel MainViewModel { get; set; }

        private User profileOwner;
        public User ProfileOwner
        {
            get { return profileOwner; }
            set
            {
                profileOwner = value;
                OnPropertyChanged();
            }
        }

        private List<Vacancy> responsedVacancies;
        public List<Vacancy> ResponsedVacancies
        {
            get { return responsedVacancies; }
            set
            {
                responsedVacancies = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SelectVacancyCommand { get; }

        private Vacancy selectedVacancy;
        public Vacancy SelectedVacancy
        {
            get { return selectedVacancy; }
            set
            {
                selectedVacancy = value;
                OnPropertyChanged();
            }
        }

        private List<Vacancy> canceledVacancies;
        public List<Vacancy> CanceledVacancies
        {
            get { return canceledVacancies; }
            set
            {
                canceledVacancies = value;
                OnPropertyChanged();
            }
        }

        private List<Vacancy> acceptedVacancies;
        public List<Vacancy> AcceptedVacancies
        {
            get { return acceptedVacancies; }
            set
            {
                acceptedVacancies = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SaveUserDataCommand { get; }

        public UserProfileViewModel(User currentUser, UnitOfWork dataWorker, MainViewModel mainViewModel)
        {
            DataWorker = dataWorker;
            MainViewModel = mainViewModel;
            ProfileOwner = currentUser;
            GetResponsedVacancies();
            GetCanceledVacancies();
            GetAcceptedVacancies();
            SelectVacancyCommand = new RelayCommand(ShowSelectedVacancy);
            SaveUserDataCommand = new RelayCommand(SaveUserData);
        }

        private void GetResponsedVacancies()
        {
            ResponsedVacancies = new List<Vacancy>();

            // Получаем все отклики пользователя
            var userResponses = DataWorker.Responses.GetData()
                .Where(response => response.UserId == ProfileOwner.Id && !response.IsCanceled && !response.IsAccepted); // Фильтрация по ID пользователя

            var vacancies = DataWorker.Vacancies.GetData();

            // Используем Join, чтобы получить вакансии, на которые откликнулся пользователь
            var responsedVacancies = userResponses
                .Join(vacancies,
                      r => r.VacancyId,
                      jp => jp.Id,
                      (r, jp) => jp) // Получаем соответствующие вакансии
                .ToList();

            ResponsedVacancies = responsedVacancies;
        }
        private void GetCanceledVacancies()
        {
            CanceledVacancies = new List<Vacancy>();

            // Получаем все отклики пользователя
            var canceledUserResponses = DataWorker.Responses.GetData()
                .Where(response => response.UserId == ProfileOwner.Id && response.IsCanceled); // Фильтрация по ID пользователя

            var vacancies = DataWorker.Vacancies.GetData();

            // Используем Join, чтобы получить вакансии, на которые откликнулся пользователь
            var responsedVacancies = canceledUserResponses
                .Join(vacancies,
                      response => response.VacancyId,
                      vacancy => vacancy.Id,
                      (response, vacancy) => vacancy) // Получаем соответствующие вакансии
                .ToList();

            CanceledVacancies = responsedVacancies;

        }
        private void GetAcceptedVacancies()
        {
            AcceptedVacancies = new List<Vacancy>();

            // Получаем все отклики пользователя
            var canceledUserResponses = DataWorker.Responses.GetData()
                .Where(response => response.UserId == ProfileOwner.Id && response.IsAccepted); // Фильтрация по ID пользователя

            var vacancies = DataWorker.Vacancies.GetData();

            // Используем Join, чтобы получить вакансии, на которые откликнулся пользователь
            var responsedVacancies = canceledUserResponses
                .Join(vacancies,
                      response => response.VacancyId,
                      vacancy => vacancy.Id,
                      (response, vacancy) => vacancy) // Получаем соответствующие вакансии
                .ToList();

            AcceptedVacancies = responsedVacancies;

        }
        private void ShowSelectedVacancy(object parameter)
        {
            Vacancy? vacancyParm = parameter as Vacancy;

            if (vacancyParm != null)
            {
                MainViewModel.CurrentView = new VacancyViewModel(new Vacancy(vacancyParm), DataWorker, MainViewModel);
            }
        }
        private void SaveUserData(object parameter)
        {
            try
            {
                User? user = parameter as User;

                if (user != null)
                {
                    User? checkUser = DataWorker.Users.GetData().FirstOrDefault(u =>
                    (u.Login == user.Login ||
                    u.Email == user.Email ||
                    u.Phone == user.Phone) &&
                    u.Id != user.Id
                    );

                    if (checkUser != null)
                    {
                        MessageBox.Show("Пользователь с таким логином,\nтелефоном или эл.почтой уже зарегистрирован!");
                        return;
                    }

                    if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Login) ||
                    string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) ||
                    string.IsNullOrEmpty(user.Phone))
                        throw new Exception("Поля не должны быть пустыми!");
                    if (!Regex.IsMatch(user.UserName, "^[A-Za-zА-Яа-я]+$"))
                        throw new Exception("Имя пользователя должно содержать только буквы!");
                    if (!Regex.IsMatch(user.Login, "^[A-Za-z0-9]+$"))
                        throw new Exception("Логин должен содержать только\nлатинские буквы и цифры!");
                    if (!Regex.IsMatch(user.Email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                        throw new Exception("Некорректная эл. почта!");
                    if (!Regex.IsMatch(user.Phone, "^\\+\\d{12}$"))
                        throw new Exception("Неверный формат номера телефона!");
                    if (user.UserName.Length >= 50)
                        throw new Exception("Слишком длинное имя пользователя(макс. 50 символов)!");
                    if (user.Login.Length >= 50)
                        throw new Exception("Слишком длинный логин(макс. 50 символов)!");
                    if (user.Email.Length >= 50)
                        throw new Exception("Слишком длинный адрес эл. почты(макс. 50 символов)!");

                    ProfileOwner.Login = user.Login;
                    ProfileOwner.Email = user.Email;
                    ProfileOwner.Phone = user.Phone;
                    ProfileOwner.UserName = user.UserName;
                    ProfileOwner.Biography = user.Biography;

                    if (!DataWorker.Users.ChangeData(user.Id, ProfileOwner))
                    {
                        throw new Exception();
                    }

                    MainViewModel.CurrentView = MainViewModel.VacancyLV;
                }
                else
                {
                    MessageBox.Show("Не удалось сохранить данные!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении профиля:\n{ex.Message}");
            }
        }


    }
}

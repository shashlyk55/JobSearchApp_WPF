using Microsoft.IdentityModel.Tokens;
using Practic_App.core;
using Practic_App.MVVM.Model;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.Model.Data.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practic_App.MVVM.ViewModel
{
    public class VacancyViewModel: ObservableObject
    {
        public UnitOfWork DataWorker { get; set; }
        public MainViewModel MainViewModel { get; set; }

        public RelayCommand SaveVacancyCommand { get; }
        public RelayCommand RespondToVacancyCommand { get; }
        public RelayCommand CancelRespondCommand { get; }

        private Vacancy _selectedVacancy;
        public Vacancy SelectedVacancy
        {
            get { return _selectedVacancy; }
            set
            {
                _selectedVacancy = value;
                OnPropertyChanged();
            }
        }

        private List<User> responsedUsers;
        public List<User> ResponsedUsers
        {
            get { return responsedUsers; }
            set
            {
                responsedUsers = value;
                OnPropertyChanged();
            }
        }

        private List<User> rejectedUsers;
        public List<User> RejectedUsers
        {
            get { return rejectedUsers; }
            set
            {
                rejectedUsers = value;
                OnPropertyChanged();
            }
        }

        private List<User> acceptedUsers;
        public List<User> AcceptedUsers
        {
            get { return acceptedUsers; }
            set
            {
                acceptedUsers = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SelectUserCommand { get; }

        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        public VacancyViewModel(Vacancy selectedVacancy, UnitOfWork dataWorker, MainViewModel mainViewModel)
        {
            DataWorker = dataWorker;
            MainViewModel = mainViewModel;
            SelectedVacancy = selectedVacancy;
            GetResponsedUsers();
            GetRejectedUsers();
            GetAcceptedUsers();
            SaveVacancyCommand = new RelayCommand(SaveVacancy);
            RespondToVacancyCommand = new RelayCommand(RespondToVacancy);
            CancelRespondCommand = new RelayCommand(CancelRespond);
            SelectUserCommand = new RelayCommand(ShowSelectedUser);
        }

        private void GetResponsedUsers()
        {
            ResponsedUsers = new List<User>();
            var users = DataWorker.Users.GetData();
            var responses = DataWorker.Responses.GetData().Where(response => response.VacancyId == SelectedVacancy.Id && !response.IsCanceled && !response.IsAccepted);

            var userWithResponses = users
            .Join(responses, user => user.Id, response => response.UserId,
                  (user, response) => user)
            .Distinct() // Чтобы избежать дубликатов, если у одного пользователя несколько ответов
            .ToList();

            ResponsedUsers = userWithResponses.ToList();
        }

        private void GetRejectedUsers()
        {
            RejectedUsers = new List<User>();
            var users = DataWorker.Users.GetData();
            var responses = DataWorker.Responses.GetData().Where(response => response.VacancyId == SelectedVacancy.Id && response.IsCanceled);

            var userWithResponses = users
            .Join(responses, user => user.Id, response => response.UserId,
                  (user, response) => user)
            .Distinct() // Чтобы избежать дубликатов, если у одного пользователя несколько ответов
            .ToList();

            RejectedUsers = userWithResponses.ToList();
        }

        private void GetAcceptedUsers()
        {
            AcceptedUsers = new List<User>();
            var users = DataWorker.Users.GetData();
            var responses = DataWorker.Responses.GetData().Where(response => response.VacancyId == SelectedVacancy.Id && response.IsAccepted);

            var userWithResponses = users
            .Join(responses, user => user.Id, response => response.UserId,
                  (user, response) => user)
            .Distinct() // Чтобы избежать дубликатов, если у одного пользователя несколько ответов
            .ToList();

            AcceptedUsers = userWithResponses.ToList();
        }

        private void RespondToVacancy(object parameter)
        {
            try
            {
                if (!MainViewModel.IsLoggedIn) 
                {
                    MessageBox.Show("Авторизируйтесь прежде чем сделать это действие!");
                    return;
                }

                int currentUserId = MainViewModel.User.Id;
                Response response = new Response { UserId = currentUserId, VacancyId = SelectedVacancy.Id };

                var responses = DataWorker.Responses.GetData();
                var responsesOnUserId = responses.Where(r => r.UserId == currentUserId);
                var responsesOnVacancyId = responsesOnUserId.Where(r => r.VacancyId == SelectedVacancy.Id);

                if (DataWorker.Responses.GetData().Where(r => r.VacancyId == SelectedVacancy.Id && r.UserId == currentUserId && r.IsCanceled).ToList().Count != 0)
                {
                    MessageBox.Show("Данный вам отказ не позволяет \nпроизводить операции с этой вакансией!");
                    return;
                }

                if (responsesOnVacancyId.IsNullOrEmpty()) 
                {
                    response.VacancyId = SelectedVacancy.Id;
                    response.UserId = currentUserId;

                    if (response != null && DataWorker.Responses.AddData(response))
                    {
                        MessageBox.Show("Отклик произведен успешно!");
                    }
                }
                else
                {
                    MessageBox.Show("Вы отвечали на данную вакансию!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Отклик не произведен!\n" + ex.Message);
            }
        }

        private void CancelRespond(object parameter)
        {
            try
            {
                if (!MainViewModel.IsLoggedIn)
                {
                    MessageBox.Show("Авторизируйтесь прежде чем сделать это действие!");
                    return;
                }
                int currentUserId = MainViewModel.User.Id;
                Response response = new Response { UserId = MainViewModel.User.Id, VacancyId = SelectedVacancy.Id };

                var responses = DataWorker.Responses.GetData();
                var responsesOnUserId = responses.Where(r => r.UserId == currentUserId);
                var responsesOnVacancyId = responsesOnUserId.Where(r => r.VacancyId == SelectedVacancy.Id);

                if(responsesOnVacancyId.IsNullOrEmpty())
                {
                    MessageBox.Show("Вы не давали отклик на эту вакансию!");
                    return;
                }
                if(DataWorker.Responses.GetData().Where(r => r.VacancyId == SelectedVacancy.Id && r.UserId == currentUserId && r.IsCanceled).ToList().Count != 0)
                {
                    MessageBox.Show("Данный вам отказ не позволяет \nпроизводить операции с этой вакансией!");
                    return;
                }
                if (DataWorker.Responses.GetData().Where(r => r.VacancyId == SelectedVacancy.Id && r.UserId == currentUserId && r.IsAccepted).ToList().Count != 0)
                {
                    MessageBox.Show("Вакансия уже одобрена! Вы не можете\nпроизводить операции с этой вакансией!");
                    return;
                }
                if (DataWorker.Responses.RemoveData(responsesOnVacancyId.ToArray()[0]))
                {
                    MessageBox.Show("Отклик отменен!");
                    return;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Отклик не отменен!\n" + ex.Message);
            }
        }

        private void SaveVacancy(object parameter)
        {
            try
            {
                Vacancy? vacancy = parameter as Vacancy;

                if (vacancy != null)
                {
                    if(string.IsNullOrEmpty(vacancy.Location) || string.IsNullOrEmpty(vacancy.CompanyName) || 
                        string.IsNullOrEmpty(vacancy.Description) || string.IsNullOrEmpty(vacancy.Title) || 
                        string.IsNullOrEmpty(vacancy.Industry))
                    {
                        throw new Exception("Поля не должны быть пустыми!");
                    }
                    Vacancy? selectedVacancy = MainViewModel.VacancyLV.Vacancies.FirstOrDefault(v => v.Id == vacancy.Id);
                    if (selectedVacancy != null)
                    {
                        Vacancy? checkedVacancy = DataWorker.Vacancies.GetData().FirstOrDefault(v =>
                        v.Id != vacancy.Id &&
                        v.Industry == vacancy.Industry && v.Salary == vacancy.Salary &&
                        v.Location == vacancy.Location && v.CompanyName == vacancy.CompanyName &&
                        v.Description == vacancy.Description && v.Title == vacancy.Title);

                        if(checkedVacancy == null )
                        {
                            if (vacancy.Salary < 0)
                                throw new Exception("Некорректно задана зарплата!");

                            selectedVacancy.Title = vacancy.Title;
                            selectedVacancy.Description = vacancy.Description;
                            selectedVacancy.CompanyName = vacancy.CompanyName;
                            selectedVacancy.Salary = vacancy.Salary;
                            selectedVacancy.Location = vacancy.Location;

                            if (!DataWorker.Vacancies.ChangeData(vacancy.Id, selectedVacancy))
                            {
                                throw new Exception();
                            }
                        }
                        else
                        {
                            throw new Exception("Вакансия с таким набором данных уже существует!");
                        }
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
                MessageBox.Show($"Произошла ошибка при сохранении вакансии:\n{ex.Message}");
            }
        }
        private void ShowSelectedUser(object parameter)
        {
            User? userParm = parameter as User;

            if (userParm != null)
            {
                MainViewModel.CurrentView = new UserViewModel(new User(userParm), SelectedVacancy, DataWorker, MainViewModel);
            }
        }

    }
}

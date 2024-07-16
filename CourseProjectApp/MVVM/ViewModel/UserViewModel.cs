using Microsoft.EntityFrameworkCore.Metadata;
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
    public class UserViewModel: ObservableObject
    {
        public UnitOfWork DataWorker { get; set; }
        public MainViewModel MainViewModel { get; set; }
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

        public RelayCommand RejectUserFromVacancyCommand { get; }
        public RelayCommand CancelRejectUserFromVacancyCommand { get; }
        public RelayCommand AcceptUserOnVacancyCommand { get; }
        public RelayCommand BackCommand { get; }

        public UserViewModel(User selectedUSer, Vacancy selectedVacancy, UnitOfWork dataWorker, MainViewModel mainViewModel)
        {
            DataWorker = dataWorker;
            MainViewModel = mainViewModel;
            SelectedUser = selectedUSer;
            SelectedVacancy = selectedVacancy;

            RejectUserFromVacancyCommand = new RelayCommand(RejectUserFromVacancy);
            CancelRejectUserFromVacancyCommand = new RelayCommand(CancelRejectUserFromVacancy);
            AcceptUserOnVacancyCommand = new RelayCommand(AcceptUserOnVacancy);
            BackCommand = new RelayCommand(Back);
        }
        private void Back(object parameter)
        {
            MainViewModel.CurrentView = new VacancyViewModel(SelectedVacancy, DataWorker, MainViewModel);
        }
        private void RejectUserFromVacancy(object parameter)
        {
            if(SelectedVacancy != null && SelectedUser != null)
            {
                Response tempResponse = DataWorker.Responses.GetData().Where(response => response.VacancyId == SelectedVacancy.Id && response.UserId == SelectedUser.Id).ToList()[0];
                tempResponse.IsCanceled = true;
                tempResponse.IsAccepted = false;

                if(DataWorker.Responses.ChangeData(tempResponse.Id, tempResponse))
                {
                    MessageBox.Show("Пользователю отказано!");
                }
                else
                {
                    MessageBox.Show("Ошибка при выполнении операции!");
                }
            }
        }
        private void CancelRejectUserFromVacancy(object parameter)
        {
            if (SelectedVacancy != null && SelectedUser != null)
            {
                Response tempResponse = DataWorker.Responses.GetData().Where(response => response.VacancyId == SelectedVacancy.Id && response.UserId == SelectedUser.Id).ToList()[0];
                tempResponse.IsCanceled = false;
                tempResponse.IsAccepted = false;

                if (DataWorker.Responses.ChangeData(tempResponse.Id, tempResponse))
                {
                    MessageBox.Show("Операция отменена!");
                }
                else
                {
                    MessageBox.Show("Ошибка при выполнении операции!");
                }

            }
        }
        private void AcceptUserOnVacancy(object parameter)
        {
            if (SelectedVacancy != null && SelectedUser != null)
            {
                Response tempResponse = DataWorker.Responses.GetData().Where(response => response.VacancyId == SelectedVacancy.Id && response.UserId == SelectedUser.Id).ToList()[0];
                tempResponse.IsCanceled = false;
                tempResponse.IsAccepted = true;

                if (DataWorker.Responses.ChangeData(tempResponse.Id, tempResponse))
                {
                    MessageBox.Show("Пользователь принят!");
                }
                else
                {
                    MessageBox.Show("Ошибка при выполнении операции!");
                }

            }
        }

    }
}

using Microsoft.Win32;
using Practic_App.core;
using Practic_App.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.Model.Data.UW;
using System.Text.RegularExpressions;
using Microsoft.Xaml.Behaviors.Media;

namespace Practic_App.MVVM.ViewModel
{
    public class AddVacancyViewModel: ObservableObject
    {
        public UnitOfWork DataWorker { get; set; }

        private List<Vacancy> Vacancies { get; set; }

        public RelayCommand CreateVacancyCommand { get; }

        private Vacancy _newVacancy;
        public Vacancy NewVacancy
        {
            get { return _newVacancy; }
            set {
                _newVacancy = value;
                OnPropertyChanged();
            }
        }

        public AddVacancyViewModel(List<Vacancy> vacancies, UnitOfWork dataWorker)
        {
            DataWorker = dataWorker;
            CreateVacancyCommand = new RelayCommand(AddVacancy);
            NewVacancy = new Vacancy();
            Vacancies = vacancies;
        }

        private void AddVacancy(object parameter)
        {
            try
            {
                Vacancy? vacancy = parameter as Vacancy;

                if (vacancy != null)
                {
                    if (string.IsNullOrEmpty(vacancy.Location) || string.IsNullOrEmpty(vacancy.CompanyName) ||
                    string.IsNullOrEmpty(vacancy.Description) || string.IsNullOrEmpty(vacancy.Title) || 
                    string.IsNullOrEmpty(vacancy.Industry))
                        throw new Exception("Поля не должны быть пустыми!");

                    if (vacancy.CompanyName.Length > 50)
                        throw new Exception("Слишком длинное навзание компании!(макс. 50 симв.)");
                    if (vacancy.Location.Length > 75)
                        throw new Exception("Слишком длинный адрес!(макс. 75 симв.)");
                    if (vacancy.Title.Length > 50)
                        throw new Exception("Слишком длинное название вакансии!(макс. 50 симв.)");
                    if (vacancy.Salary <= 0)
                        throw new Exception("Некорректно задана зарплата!");

                    if (DataWorker.Vacancies.GetData().FirstOrDefault(v =>
                    v.Industry == vacancy.Industry && v.Salary == vacancy.Salary &&
                    v.Location == vacancy.Location && v.CompanyName == vacancy.CompanyName &&
                    v.Description == vacancy.Description && v.Title == vacancy.Title) != null)
                        throw new Exception("Такая вакансия уже существует!");

                    if (DataWorker.Vacancies.AddData(vacancy))
                    {
                        vacancy.DataAdded = DateTime.Now;
                        Vacancies.Add(vacancy);
                        NewVacancy = new Vacancy();
                        MessageBox.Show("Вакансия успешно добавлена!");
                    }
                    else
                        MessageBox.Show("Не удалось добавить вакансию!");
                }
                else
                    MessageBox.Show("Не удалось добавить вакансию!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении вакансии: {ex.Message}");
            }
        }

        
    }
}

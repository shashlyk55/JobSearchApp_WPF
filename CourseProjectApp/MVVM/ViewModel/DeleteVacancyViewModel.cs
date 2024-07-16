using Practic_App.core;
using Practic_App.MVVM.Model;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.Model.Data.UW;
using System.Collections.ObjectModel;
using System.Windows;

namespace Practic_App.MVVM.ViewModel
{
    public class DeleteVacancyViewModel: ObservableObject
    {
        public UnitOfWork DataWorker { get; set; }

        public RelayCommand DeleteVacancyCommand { get; }

        private List<Vacancy> vacancies;
        public List<Vacancy> Vacancies {
            get { return vacancies; }
            set {
                vacancies = value;
                OnPropertyChanged("Vacancies");
            }
        }

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

        public DeleteVacancyViewModel(List<Vacancy> vacancies, UnitOfWork dataWorker)
        {
            DataWorker = dataWorker;
            Vacancies = vacancies;

            DeleteVacancyCommand = new RelayCommand(DeleteVacancy);
        }

        private void DeleteVacancy(object parameter)
        {
            if (SelectedVacancy != null)
            {
                Vacancies.Remove(SelectedVacancy);
                DataWorker.Vacancies.RemoveData(SelectedVacancy);

                MessageBox.Show("Вакансия успешно удалена!");
            }
            else
            {
                MessageBox.Show("Ошибка удаления вакансии");
            }
        }
    }
}

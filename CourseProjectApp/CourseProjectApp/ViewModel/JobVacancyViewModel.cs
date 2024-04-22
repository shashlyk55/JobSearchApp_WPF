using CourseProjectApp.Commands;
using CourseProjectApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProjectApp.ViewModel
{
    public class JobVacancyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<JobVacancyModel> jobVacancies;
        public ObservableCollection<JobVacancyModel> JobVacancies
        {
            get { return jobVacancies; }
            set
            {
                jobVacancies = value;
                OnPropertyChanged(nameof(JobVacancies));
            }
        }

        public ObservableCollection<IndustryModel> Industries { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Команда для загрузки вакансий
        public ICommand LoadJobVacanciesCommand { get; set; }

        // Конструктор
        public JobVacancyViewModel()
        {
            // Инициализация команды загрузки вакансий
            LoadJobVacanciesCommand = new RelayCommand(LoadJobVacancies);
            // Инициализация команд
            AddCommand = new RelayCommand(AddJob);
            DeleteCommand = new RelayCommand(DeleteJob, CanDeleteJob);
            EditCommand = new RelayCommand(EditJob, CanEditJob);
            ApplyFilterCommand = new RelayCommand(ApplyFilter);

            // Заполнения combobox с отраслями
            Industries = new ObservableCollection<IndustryModel>()
            {
                new IndustryModel(1,"ИТ"),
                new IndustryModel(2,"Транспорт"),
                new IndustryModel(3,"Общепит")
            };
            //LoadIndustries();
        }

        /*private void LoadIndustries()
        {
            var industries = _industryRepository.GetIndustries();
            Industries.Clear();
            foreach (var industry in industries)
            {
                Industries.Add(industry);
            }
        }*/

        // Метод для загрузки вакансий
        private void LoadJobVacancies()
        {
            // Здесь будет логика загрузки вакансий из источника данных (например, из API сервиса)
            // После загрузки данных обновляем список вакансий
            // Пример:
            // JobVacancies = new ObservableCollection<JobVacancyModel>(apiService.GetJobVacancies());
            JobVacancies = new ObservableCollection<JobVacancyModel>();
        }

        // Свойства и команды...

        // Команда для добавления вакансии
        public ICommand AddCommand { get; set; }

        // Команда для удаления вакансии
        public ICommand DeleteCommand { get; set; }

        // Команда для изменения вакансии
        public ICommand EditCommand { get; set; }

        // Методы для выполнения действий по командам
        private void AddJob()
        {
            // Логика добавления вакансии
        }

        private void DeleteJob(object parameter)
        {
            // Логика удаления вакансии
        }

        private bool CanDeleteJob(object parameter)
        {
            // Логика проверки возможности удаления вакансии
            return true;
        }

        private void EditJob(object parameter)
        {
            // Логика изменения вакансии
        }

        private bool CanEditJob(object parameter)
        {
            // Логика проверки возможности изменения вакансии
            return true;
        }

        // Свойства для фильтрации по цене
        private string minPriceFilter;
        public string MinPriceFilter
        {
            get { return minPriceFilter; }
            set
            {
                minPriceFilter = value;
                OnPropertyChanged(nameof(MinPriceFilter));
            }
        }

        private string maxPriceFilter;
        public string MaxPriceFilter
        {
            get { return maxPriceFilter; }
            set
            {
                maxPriceFilter = value;
                OnPropertyChanged(nameof(MaxPriceFilter));
            }
        }

        // Команда для применения фильтра
        public ICommand ApplyFilterCommand { get; set; }

        // Метод для применения фильтрации
        private void ApplyFilter()
        {
            // Логика применения фильтрации по цене
            // Можно использовать MinPriceFilter и MaxPriceFilter для получения введенных пользователем значений
        }
    }
}

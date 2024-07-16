using Practic_App.core;
using Practic_App.MVVM.Model;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.Model.Data.UW;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Practic_App.MVVM.ViewModel
{
    public class VacancyListViewModel: ObservableObject
    {
        public MainViewModel MainViewModel { get; set; }
        public UnitOfWork DataWorker { get; set; }

        public RelayCommand SelectVacancyCommand { get; }

        private Vacancy _selectedVacancy;
        public Vacancy SelectedVacancy { 
            get { return _selectedVacancy; } 
            set {
                _selectedVacancy = value;
                OnPropertyChanged();
            }
        }

        private List<Vacancy> _vacancies;
        public List<Vacancy> Vacancies
        {
            get
            {
                return _vacancies;
            }
            set
            {
                _vacancies = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SearchVacancyCommand { get; }

        private string _searchQuery;
        public string SearchQuery
        {
            get
            {
                return _searchQuery;
            }
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand FilterCommand { get; }
        private int minSalary = 0;
        public int MinSalary
        {
            get { return minSalary; }
            set
            {
                if (value == 5)
                {
                    OnPropertyChanged();
                    return;
                }
                minSalary = value;
                OnPropertyChanged();
            }
        }
        private int maxSalary = 0;
        public int MaxSalary
        {
            get { return maxSalary; }
            set
            {
                if(value == 5)
                {
                    OnPropertyChanged();
                    return;
                }
                maxSalary = value;
                OnPropertyChanged();
            }
        }

        private string selectedIndustry = "Все";
        public string SelectedIndustry
        {
            get { return selectedIndustry; }
            set
            {
                int lastIndex = value.LastIndexOf(' ');
                value = value.Substring(lastIndex + 1);

                selectedIndustry = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SortCommand { get; }
        private string selectedSortOption;
        public string SelectedSortOption
        {
            get { return selectedSortOption; }
            set
            {
                int lastIndex = value.LastIndexOf(' ');
                value = value.Substring(lastIndex + 1);

                selectedSortOption = value;
                OnPropertyChanged();
            }
        }

        public VacancyListViewModel(MainViewModel mainViewModal, UnitOfWork dataWorker) {
            DataWorker = dataWorker;
            MainViewModel = mainViewModal;

            Vacancies = DataWorker.Vacancies.GetData();
            SelectVacancyCommand = new RelayCommand(ShowSelectedVacancy);
            SearchVacancyCommand = new RelayCommand(SearchVacancy);
            FilterCommand = new RelayCommand(Filter);
            SortCommand = new RelayCommand(Sort);
        }

        private void ShowSelectedVacancy(object parameter)
        {
            Vacancy? vacancyParm = parameter as Vacancy;

            if (vacancyParm != null)
            {
                MainViewModel.CurrentView = new VacancyViewModel(new Vacancy(vacancyParm), DataWorker, MainViewModel);
            }
        }

        private void SearchVacancy(object parameter)
        {
            if (SearchQuery != null)
            {
                Vacancies.Clear();
                Vacancies = DataWorker.Vacancies.GetData().Where(vacancy => vacancy.Title.ToLower().Contains(SearchQuery.ToLower())).ToList();
            }
            if(SearchQuery == null || SearchQuery == "")
            {
                Vacancies.Clear();
                Vacancies = DataWorker.Vacancies.GetData();
            }
        }
        private void Filter(object parameter)
        {
            
            if (SelectedIndustry == "Все")
            {
                if (MinSalary == 0 && MaxSalary == 0)
                {
                    Vacancies.Clear();
                    Vacancies = DataWorker.Vacancies.GetData();
                    return;
                }
                else
                {
                    Vacancies.Clear();
                    Vacancies = DataWorker.Vacancies.GetData().Where(vacancy => vacancy.Salary <= maxSalary && vacancy.Salary >= minSalary).ToList();
                    return;
                }
            }
            else
            {
                if (MinSalary == 0 && MaxSalary == 0)
                {
                    Vacancies.Clear();
                    Vacancies = DataWorker.Vacancies.GetData().Where(vacancy => vacancy.Industry == SelectedIndustry).ToList();
                    return;
                }
                else
                {
                    Vacancies.Clear();
                    Vacancies = DataWorker.Vacancies.GetData().Where(vacancy => vacancy.Salary <= maxSalary && vacancy.Salary >= minSalary && vacancy.Industry == SelectedIndustry).ToList();
                    return;
                }
            }
        }
        private void Sort(object parameter)
        {
            switch (SelectedSortOption)
            {
                case ("Добавлен(убыв.)"):
                    Vacancies = Vacancies.OrderByDescending(vacancy => vacancy.DataAdded).ToList();
                    break;
                case ("Добавлен(возр.)"):
                    Vacancies = Vacancies.OrderBy(vacancy => vacancy.DataAdded).ToList();
                    break;
                case ("Зарплата(убыв.)"):
                    Vacancies = Vacancies.OrderByDescending(vacancy => vacancy.Salary).ToList();
                    break;
                case ("Зарплата(возр.)"):
                    Vacancies = Vacancies.OrderBy(vacancy => vacancy.Salary).ToList();
                    break;
                case ("Название"):
                    Vacancies = Vacancies.OrderBy(vacancy => vacancy.Title).ToList();
                    break;
            }
        }
    }
}

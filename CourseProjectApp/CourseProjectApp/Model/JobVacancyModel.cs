using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectApp.Model
{
    public class JobVacancyModel
    {
        public string Title { get; set; }           // Название вакансии
        public string Company { get; set; }         // Название компании
        public byte[] CompanyLogo { get; set; }     // Логотип компании
        public string Location { get; set; }        // Адрес работы
        public string Salary { get; set; }          // Зарплата
        public string Description { get; set; }     // Описание вакансии
        public DateTime DateAdded { get; set; }     // Дата добавления
        public string Industry { get; set; }        // Отрасль вакансии
    }

}

using Practic_App.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Practic_App.MVVM.Model.Data
{
    public class Response: ObservableObject
    {
        private int id;
        private int vacancyId;
        private int userId;
        private bool isCanceled = false;
        private bool isAccepted = false;
        private Vacancy vacancy;
        private User user;
        [Key]
        public int Id 
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); } 
        }
        public int VacancyId
        {
            get { return vacancyId; }
            set { vacancyId = value; OnPropertyChanged("VacancyId"); }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged("UserId"); }
        }
        public bool IsCanceled
        {
            get { return isCanceled; }
            set { isCanceled = value; OnPropertyChanged("IsCanceled"); }
        }
        public bool IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; OnPropertyChanged("IsAccepted"); }
        }
        public Vacancy Vacancy
        {
            get { return vacancy; }
            set { vacancy = value; OnPropertyChanged("Vacancy"); }
        }
        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }
        public Response() { }
        public Response(int id, int vacancyId, int userId, bool isCanceled, Vacancy vacancy, User user)
        {
            Id = id;
            VacancyId = vacancyId;
            UserId = userId;
            IsCanceled = isCanceled;
            Vacancy = vacancy;
            User = user;
        }
        public Response(Response response)
        {
            this.Id = response.Id;
            this.IsCanceled = response.IsCanceled;
            this.vacancyId = response.VacancyId;
            this.UserId = response.UserId;
        }
    }
}

using Practic_App.core;
using Practic_App.MVVM.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practic_App.MVVM.Model
{
    public class Vacancy : ObservableObject
    {
        private int id;
        private string title;
        private string companyName;
        private string description;
        private string location;
        private decimal salary;
        private DateTime dataAdded;
        private string industry;

        private List<Response> responses;

        [Key]
        public int Id
        {   get { return id; } 
            set 
            { 
                id = value; 
                OnPropertyChanged("Id"); 
            } 
        }
        [Column(TypeName = "nvarchar(150)")]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        [Column(TypeName = "nvarchar(100)")]
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }
        [Column(TypeName = "nvarchar(150)")]
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                OnPropertyChanged("Salary");
            }
        }
        [Column(TypeName = "Date")]
        public DateTime DataAdded
        {
            get { return dataAdded; }
            set
            {
                dataAdded = value;
                OnPropertyChanged("DateAdded");
            }
        }
        [Column(TypeName = "nvarchar(100)")]
        public string Industry
        {
            get { return industry; }
            set 
            {
                int lastIndex = value.LastIndexOf(' ');
                value = value.Substring(lastIndex + 1);

                industry = value; 
                OnPropertyChanged("Industry"); 
            }
        }
        public List<Response> Responses
        {
            get { return responses; }
            set { responses = value; OnPropertyChanged("Responses"); }
        }
        public Vacancy() { }
        public Vacancy(int id, string title, string companyName, string description, string location, decimal salary, DateTime dateAdded, string industry)
        {
            this.id = id;
            this.title = title;
            this.companyName = companyName;
            this.description = description;
            this.location = location;
            this.salary = salary;
            this.dataAdded = dateAdded;
            this.industry = industry;
        }
        public Vacancy(Vacancy vacancy)
        {
            Id = vacancy.Id;
            Title = vacancy.Title;
            CompanyName = vacancy.CompanyName;
            Description = vacancy.Description;
            Location = vacancy.Location;
            Salary = vacancy.Salary;
            DataAdded = vacancy.DataAdded;
            Industry = vacancy.Industry;
            Responses = vacancy.Responses;
        }
    }
}

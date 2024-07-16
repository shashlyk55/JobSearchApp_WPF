using Practic_App.core;
using Practic_App.MVVM.Model.Data;
using Practic_App.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practic_App.MVVM.Model
{
    public class User: ObservableObject
    {
        private int id;
        private string login;
        private string email;
        private string password;
        private string phone;
        private bool isAdmin;
        private string userName;
        private string biography = "";

        private List<Response> responses;

        [Key]
        public int Id { 
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        [Column(TypeName = "nvarchar(100)")]
        public string Login { 
            get { return login; } 
            set { login = value; OnPropertyChanged("Login"); }
        }
        [Column(TypeName = "nvarchar(100)")]
        public string Email {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }
        [Column(TypeName = "nvarchar(50)")]
        public string Password { 
            get { return password; }
            set { password = value; OnPropertyChanged("Password");}
        }
        [Column(TypeName = "nvarchar(50)")]
        public string Phone { 
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; OnPropertyChanged("IsAdmin"); }
        }
        [Column(TypeName = "nvarchar(100)")]
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged("UserName"); }
        }
        public string Biography
        {
            get { return biography; }
            set { biography = value;OnPropertyChanged("Biography"); }
        }

        public List<Response> Responses
        {
            get { return responses; }
            set {  responses = value; OnPropertyChanged("Responses"); }
        }
        
        
        public User() { }
        public User(User user)
        {
            this.id = user.Id;
            this.login = user.Login;
            this.userName = user.UserName;
            this.email = user.Email;
            this.phone = user.Phone;
            this.password = user.Password;
            this.biography = user.Biography;
            this.IsAdmin = user.IsAdmin;
        }
    }
}

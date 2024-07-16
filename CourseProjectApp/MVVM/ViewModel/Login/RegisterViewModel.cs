using Practic_App.core;
using Practic_App.MVVM.Model;
using Practic_App.MVVM.Model.Data.UW;
using Practic_App.MVVM.View.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Practic_App.MVVM.ViewModel.Login
{
    public class RegisterViewModel: ObservableObject
    {
        public UnitOfWork DataWorker { get; set; }

        private User registerData = new User();
        public User RegisterData
        {
            get { return registerData; } 
            set
            {
                if(value.Phone != null && value.Phone.Length == 13)
                {
                    OnPropertyChanged(nameof(RegisterData));
                    return;
                }
                registerData = value;
                OnPropertyChanged(nameof(RegisterData));
            }
        }

        public RelayCommand RegisterCommand { get; set; }

        public RegisterViewModel(UnitOfWork unitOfWork)
        {
            DataWorker = unitOfWork;
            RegisterCommand = new RelayCommand(Register);

            RegisterData = new User();
        }

        private void Register(object parameter)
        {
            try
            {
                if (string.IsNullOrEmpty(RegisterData.UserName) || string.IsNullOrEmpty(RegisterData.Login) || 
                    string.IsNullOrEmpty(RegisterData.Email) || string.IsNullOrEmpty(RegisterData.Password) || 
                    string.IsNullOrEmpty(RegisterData.Phone))
                    throw new Exception("Поля не должны быть пустыми!");
                if (!Regex.IsMatch(RegisterData.UserName, "^[A-Za-zА-Яа-я]+$")) 
                    throw new Exception("Имя пользователя должно содержать только буквы!");
                if(!Regex.IsMatch(RegisterData.Login, "^[A-Za-z0-9]+$")) 
                    throw new Exception("Логин должен содержать только\nлатинские буквы и цифры!");
                if (!Regex.IsMatch(RegisterData.Email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                    throw new Exception("Некорректная эл. почта!");
                if (!Regex.IsMatch(RegisterData.Phone, "^\\+\\d{12}$"))
                    throw new Exception("Неверный формат номера телефона!");
                if (RegisterData.Password.Length >= 25)
                    throw new Exception("Слишком длинный пароль(макс. 25 символов)!");
                if (RegisterData.UserName.Length >= 50)
                    throw new Exception("Слишком длинное имя пользователя(макс. 50 символов)!");
                if (RegisterData.Login.Length >= 50)
                    throw new Exception("Слишком длинный логин(макс. 50 символов)!");
                if (RegisterData.Email.Length >= 50)
                    throw new Exception("Слишком длинный адрес эл. почты(макс. 50 символов)!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            try
            {
                User? checkUser = DataWorker.Users.GetData().FirstOrDefault(u => 
                    u.Login == RegisterData.Login || 
                    u.Email == RegisterData.Email ||
                    u.Phone == RegisterData.Phone
                );

                if (checkUser != null)
                {
                    MessageBox.Show("Пользователь с таким логином,\nтелефоном или эл.почтой уже зарегистрирован!");
                    return;
                }

                DataWorker.Users.AddData(RegisterData);
                MessageBox.Show("Аккаунт успешно создан!");

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is RegisterWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка регистрации!");
            }
        }
    }
}

using Practic_App.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_App.MVVM.Model.Data.Repositories
{
    public class UserRepository: IDataRepository<User>
    {
        private readonly ApplicationDataContext dbContext;

        public UserRepository(ApplicationDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddData(User data)
        {
            try
            {
                dbContext.Users.Add(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeData(int id, User newData)
        {
            try
            {
                User user = dbContext.Users.Find(id);

                if (user != null)
                {
                    user.Login = newData.Login;
                    user.Email = newData.Email;
                    user.Phone = newData.Phone;
                    user.Password = newData.Password;
                    user.Biography = newData.Biography;
                    user.UserName = newData.UserName;

                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<User> GetData()
        {
            try
            {
                return dbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        public bool RemoveData(User data)
        {
            try
            {
                dbContext.Users.Remove(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

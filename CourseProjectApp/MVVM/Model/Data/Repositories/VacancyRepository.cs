using Practic_App.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_App.MVVM.Model.Data.Repositories
{
    public class VacancyRepository : IDataRepository<Vacancy>
    {
        private readonly ApplicationDataContext dbContext;

        public VacancyRepository(ApplicationDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool AddData(Vacancy data)
        {
            try
            {
                data.DataAdded = DateTime.Now;
                dbContext.Vacancies.Add(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangeData(int id, Vacancy newData)
        {
            try
            {
                Vacancy vacancy = dbContext.Vacancies.Find(id);

                if (vacancy != null)
                {
                    vacancy.Title = newData.Title;
                    vacancy.CompanyName = newData.CompanyName;
                    vacancy.Description = newData.Description;
                    vacancy.Location = newData.Location;
                    vacancy.Salary = newData.Salary;
                    vacancy.DataAdded = newData.DataAdded;
                    vacancy.Industry = newData.Industry;
                    vacancy.Responses = newData.Responses;

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

        public List<Vacancy> GetData()
        {
            try
            {
                return dbContext.Vacancies.ToList();
            }
            catch (Exception ex)
            {
                return new List<Vacancy>();
            }
        }

        public bool RemoveData(Vacancy data)
        {
            try
            {
                dbContext.Vacancies.Remove(data);
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

using Practic_App.core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_App.MVVM.Model.Data.Repositories
{
    public class ResponseRepository : IDataRepository<Response>
    {
        private readonly ApplicationDataContext dbContext;

        public ResponseRepository(ApplicationDataContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool AddData(Response data)
        {
            try
            {
                dbContext.Responses.Add(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangeData(int id, Response newData)
        {
            try
            {
                Response response = dbContext.Responses.Find(id);

                if (response != null)
                {
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

        public List<Response> GetData()
        {
            try
            {
                return dbContext.Responses.ToList();
            }
            catch (Exception ex)
            {
                return new List<Response>();
            }
        }

        public bool RemoveData(Response data)
        {
            try
            {
                dbContext.Responses.Remove(data);
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

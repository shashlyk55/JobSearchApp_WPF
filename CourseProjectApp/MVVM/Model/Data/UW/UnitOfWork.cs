using Practic_App.core.Repositories;
using Practic_App.MVVM.Model.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_App.MVVM.Model.Data.UW
{
    public class UnitOfWork
    {
        private readonly ApplicationDataContext _context;

        public UnitOfWork(ApplicationDataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Vacancies = new VacancyRepository(_context);
            Responses = new ResponseRepository(_context);
        }

        public IDataRepository<User> Users { get; private set; }
        public IDataRepository<Vacancy> Vacancies { get; private set; }
        public IDataRepository<Response> Responses { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

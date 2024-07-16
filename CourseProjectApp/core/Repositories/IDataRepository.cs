using Practic_App.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practic_App.core.Repositories
{
    public interface IDataRepository<T>
    {
        bool AddData(T data);
        bool RemoveData(T data);
        bool ChangeData(int id, T newData);
        List<T> GetData();
    }
}

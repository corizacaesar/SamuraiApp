using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface ISamuraiProject<T>
    {
        Task<T> GetSamuraiWithPedang(int id);
        Task<T> GetSamuraiWithPedangElement(int id);
        Task<T> InsertSamuraiWithPedang(T obj);
    }
}

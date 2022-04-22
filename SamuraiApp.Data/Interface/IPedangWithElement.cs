using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface IPedangWithElement<T>
    {
        Task<T> InsertPedangWithElement(T obj);
    }
}

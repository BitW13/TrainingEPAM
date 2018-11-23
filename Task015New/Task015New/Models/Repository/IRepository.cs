using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task015New.Models.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetElementById(int id);

        T GetElement(T item);

        void Create(T item);

        void Delete(int id);

        void Update(T item);
    }
}

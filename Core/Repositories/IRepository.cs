using Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T1,T2> where T1:AbstractDomain<T2>
    {
        public List<T1> FindAll();
        public T1? FindById(T2 id);
        public T1 Save(T1 entity);

        public T1 Update(T1 entity);

        public void Delete(T1 entity);
    }
}

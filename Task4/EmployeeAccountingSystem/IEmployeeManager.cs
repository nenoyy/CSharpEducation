using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
  internal interface IEmployeeManager<T> where T : Employee
  {
    public void Add(T employee);
    public T Get(string name);
    public void Update(T employee);
  }
}

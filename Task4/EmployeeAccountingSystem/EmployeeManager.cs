using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeAccountingSystem
{
  public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
  {
    Dictionary<string, T> employees = new Dictionary<string, T>();
    public void Add(T employee)
    {
      if (employees.ContainsKey(employee.Name))
        throw new ArgumentException("такой сотрудник уже существует");
      employees.Add(employee.Name, employee);
    }

    public T Get(string name)
    {
      if(employees.TryGetValue(name, out T employee)) 
        return employee;
      throw new ArgumentException("нет такого сотрудника");
    }

    public void Update(T employee)
    {
      if(employees.TryGetValue(employee.Name, out T oldEmployee))
      {
        employees[employee.Name] = employee;
      }
      else
      {
        throw new ArgumentException("нет такого сотрудника");
      }
    }
  }
}

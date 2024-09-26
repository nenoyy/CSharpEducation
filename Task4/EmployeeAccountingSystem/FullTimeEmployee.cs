using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
  public class FullTimeEmployee : Employee
  {
    public FullTimeEmployee(string name, decimal baseSalary)
        : base(name, baseSalary)
    {
      this.Name = name;
      this.BaseSalary = baseSalary;
    }
    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }
  }
}

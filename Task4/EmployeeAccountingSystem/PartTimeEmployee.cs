using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
  public class PartTimeEmployee : Employee
  {
    public int workingHours;
    public PartTimeEmployee(string name, decimal baseSalary, int workingHours)
        : base(name, baseSalary)
    {
      this.Name= name;
      this.BaseSalary= baseSalary;
      this.workingHours = workingHours;
    }
    public override decimal CalculateSalary()
    {
      return BaseSalary * workingHours;
    }
  }
}

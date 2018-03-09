using System;
using System.Collections.Generic;
using System.Text;

namespace Dtos
{
    public class DtoMontlyEmployee : DtoEmployee
    {
        public override double AnnualSalary { get { return MonthlySalary * 12; }  }
    }
}
